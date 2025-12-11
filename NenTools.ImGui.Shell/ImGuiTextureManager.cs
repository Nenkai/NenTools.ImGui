using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

using NenTools.ImGui.Hooks;
using NenTools.ImGui.Abstractions;

namespace NenTools.ImGui.Shell;

public class ImGuiTextureManager : IImGuiTextureManager
{
    private readonly IBackendHook _backendHook;
    private readonly ILogger? _logger;

    private readonly SemaphoreSlim _loadSemaphore = new SemaphoreSlim(8); // Limit to 8 concurrent loads
    private readonly SemaphoreSlim _updateSemaphore = new SemaphoreSlim(8);

    public ImGuiTextureManager(IBackendHook backendHook, ILoggerFactory? loggerFactory = null)
    {
        _backendHook = backendHook;
        _logger = loggerFactory?.CreateLogger<ImGuiTextureManager>();
    }

    public IQueuedImGuiImage QueueImageLoad(string filePath, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath, nameof(filePath));

        _logger?.LogTrace("Loading {filePath}", filePath);

        ImGuiImageState res = new ImGuiImageState();
        _ = Task.Run(async () =>
        {
            bool acquired = false;
            await _loadSemaphore.WaitAsync(ct);
            acquired = true;

            Image<Rgba32>? image = null;
            try
            {
                image = await Image.LoadAsync<Rgba32>(filePath, ct);
                ct.ThrowIfCancellationRequested();

                ImGuiImage imGuiImage = LoadImageBytes(image);
                _logger?.LogTrace("Loaded {filePath} ({width}x{height})", filePath, imGuiImage.Width, imGuiImage.Height);

                res.Image = imGuiImage;
                res.IsLoaded = true;
            }
            catch (OperationCanceledException)
            {
                // Pass
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Failed to load queued image");
            }
            finally
            {
                image?.Dispose();

                if (acquired)
                    _loadSemaphore.Release();
            }
        }, ct);

        return res;
    }

    public IImGuiImage LoadImage(string filePath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath, nameof(filePath));

        Image<Rgba32>? image = null;
        try
        {
            image = Image.Load<Rgba32>(filePath);
            _logger?.LogTrace("Loaded {filePath} ({width}x{height})", filePath, image.Width, image.Height);

            return LoadImageBytes(image);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            image?.Dispose();
        }
    }

    private ImGuiImage LoadImageBytes(Image<Rgba32> image)
    {
        ArgumentNullException.ThrowIfNull(image, nameof(image));

        int size = image.Width * image.Height * 4;
        byte[] data = ArrayPool<byte>.Shared.Rent(size);
        image.CopyPixelDataTo(data);

        ulong texId = _backendHook.LoadTexture(data.AsSpan(0, size), (uint)image.Width, (uint)image.Height);
        if (data is not null)
            ArrayPool<byte>.Shared.Return(data);

        return new ImGuiImage(this, texId, (uint)image.Width, (uint)image.Height);
    }

    public IImGuiImage LoadImage(Span<byte> rgba32Bytes, uint width, uint height)
    {
        if (rgba32Bytes.Length != width * height * 4)
            throw new ArgumentException("The provided bytes does not match the specified dimensions.");

        ulong texId = _backendHook.LoadTexture(rgba32Bytes, width, height);
        return new ImGuiImage(this, texId, width, height);
    }

    public void FreeImage(IImGuiImage image)
    {
        ArgumentNullException.ThrowIfNull(image, nameof(image));

        ImGuiImage imGuiImage = (ImGuiImage)image;
        if (_backendHook.IsTextureLoaded(image.TexId))
            _backendHook.FreeTexture(image.TexId);

        imGuiImage.Disposed = true;
        imGuiImage.TexId = 0;
    }

    public void QueueUpdateImage(IImGuiImage image, string filePath, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath, nameof(filePath));

        _logger?.LogTrace("Loading {filePath}", filePath);

        ImGuiImageState res = new ImGuiImageState();
        _ = Task.Run(async () =>
        {
            bool acquired = false;
            await _updateSemaphore.WaitAsync(ct);
            acquired = true;

            Image<Rgba32>? imagePixels = null;
            try
            {
                imagePixels = await Image.LoadAsync<Rgba32>(filePath, ct);
                ct.ThrowIfCancellationRequested();

                UpdateImage(image, imagePixels);
            }
            catch (OperationCanceledException)
            {
                // Pass
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Failed to load queued image");
            }
            finally
            {
                imagePixels?.Dispose();

                if (acquired)
                    _updateSemaphore.Release();
            }
        }, ct);
    }

    public void UpdateImage(IImGuiImage image, string filePath)
    {
        ArgumentNullException.ThrowIfNull(image, nameof(image));
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath, nameof(filePath));

        Image<Rgba32>? imagePixels = null;
        try
        {
            imagePixels = Image.Load<Rgba32>(filePath);
            _logger?.LogTrace("Loaded {filePath} ({width}x{height})", filePath, image.Width, image.Height);

            UpdateImage(image, imagePixels);
        }
        finally
        {
            imagePixels?.Dispose();
        }
    }

    public void UpdateImage(IImGuiImage image, Span<byte> imageData)
    {
        ArgumentNullException.ThrowIfNull(image, nameof(image));

        uint expectedSize = image.Width * image.Height * 4;
        if (imageData.Length != expectedSize)
            throw new ArgumentException($"Image buffer is expected to match image dimensions ({image.Width}x{image.Height} * 4 = {expectedSize} bytes), but provided buffer was {imageData.Length} bytes.");

        _backendHook.UpdateTexture(image.TexId, imageData, image.Width, image.Height);
    }

    private void UpdateImage(IImGuiImage image, Image<Rgba32> newImagePixels)
    {
        if (newImagePixels.Width > image.Width || newImagePixels.Height > image.Height)
            throw new Exception($"Can not update image as source dimensions ({newImagePixels.Width}x{newImagePixels.Height}) exceed current image's ({image.Width}x{image.Height}).");

        int size = newImagePixels.Width * newImagePixels.Height * 4;

        byte[]? data = null;
        try
        {
            data = ArrayPool<byte>.Shared.Rent(size);
            newImagePixels.CopyPixelDataTo(data);

            UpdateImage(image, data.AsSpan(0, size));
        }
        finally
        {
            if (data is not null)
                ArrayPool<byte>.Shared.Return(data);
        }
    }
}
