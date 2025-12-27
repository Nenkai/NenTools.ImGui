using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using NenTools.ImGui.Implementation;
using NenTools.ImGui.Interfaces;
using NenTools.ImGui.Interfaces.Shell.Fonts;

namespace NenTools.ImGui.Shell.Fonts;

public class ImGuiFontManager : IImGuiFontManager
{
    private readonly IImGui _imGui;
    private readonly ILogger? _logger;

    public IReadOnlyDictionary<string, IImGuiFontInstance> Fonts => _fonts;
    private readonly Dictionary<string, IImGuiFontInstance> _fonts = [];

    public ImGuiFontManager(IImGui imGui, ILoggerFactory? loggerFactory = null)
    {
        _imGui = imGui;
        _logger = loggerFactory?.CreateLogger<ImGuiFontManager>();
    }

    public unsafe IImGuiFontInstance AddFontTTF(string owner, string fontName, string path, float sizePixels, uint* glyphRanges, ImFontOptions? options = default)
    {
        using IDisposableHandle<IImFontConfig> config = VerifyArgumentsAndCreateConfig(owner, fontName, path, sizePixels, options);
        IImFont font = _imGui.ImFontAtlas_AddFontFromFileTTF(_imGui.GetIO().Fonts, path, sizePixels, config.Value, ref Unsafe.AsRef<uint>(glyphRanges));

        ImGuiFontInstance fontInstance = new ImGuiFontInstance
        {
            Owner = owner,
            Name = fontName,
            Path = path,
            Font = font,
            IsMerged = config.Value.MergeMode,
        };

        Register(fontInstance);
        return fontInstance;
    }

    public unsafe IImGuiFontInstance AddFontTTF(string owner, string fontName, string path, float sizePixels, uint[]? glyphRanges = null, ImFontOptions? options = default)
    {
        if (glyphRanges is null)
            return AddFontTTF(owner, fontName, path, sizePixels, _imGui.ImFontAtlas_GetGlyphRangesDefault(_imGui.GetIO().Fonts), options);

        ArgumentOutOfRangeException.ThrowIfZero(glyphRanges.Length, "glyphRanges.Length");

        int newArrLength = glyphRanges.Length;
        if (glyphRanges[^1] != 0)
            newArrLength++;

        uint[] newGlyphRangeArray = new uint[newArrLength];
        glyphRanges.AsSpan().CopyTo(newGlyphRangeArray);

        using IDisposableHandle<IImFontConfig> config = VerifyArgumentsAndCreateConfig(owner, fontName, path, sizePixels, options);

        IImFont font;
        fixed (uint* arr = &newGlyphRangeArray[0])
            font = _imGui.ImFontAtlas_AddFontFromFileTTF(_imGui.GetIO().Fonts, path, sizePixels, config.Value, ref newGlyphRangeArray[0]);

        ImGuiFontInstance fontInstance = new ImGuiFontInstance
        {
            Owner = owner,
            Name = fontName,
            Path = path,
            Font = font,
            IsMerged = config.Value.MergeMode,
        };
        fontInstance.SetGlyphRanges(glyphRanges);

        Register(fontInstance);
        return fontInstance;
    }

    public IImGuiFontInstance? GetFont(string name)
    {
        if (_fonts.TryGetValue(name, out IImGuiFontInstance? font))
            return font;

        return null;
    }

    public bool RemoveFont(string name)
    {
        if (!_fonts.TryGetValue(name, out IImGuiFontInstance? font))
            return false;

        _logger?.LogWarning("[{man}] Removing font {fontName} ({owner})", nameof(ImGuiFontManager), name, font.Owner);

        IImGuiIO io = _imGui.GetIO();
        _imGui.ImFontAtlas_RemoveFont(io.Fonts, font.Font);
        return true;
    }

    private IDisposableHandle<IImFontConfig> VerifyArgumentsAndCreateConfig(string owner, string fontName, string path, float sizePixels, ImFontOptions? options = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(owner, nameof(owner));
        ArgumentException.ThrowIfNullOrWhiteSpace(fontName, nameof(fontName));
        ArgumentException.ThrowIfNullOrWhiteSpace(path, nameof(path));

        IDisposableHandle<IImFontConfig> configHandle = _imGui.CreateFontConfig();
        IImFontConfig config = configHandle.Value;

        if (options != null)
        {
            if (options.MergeMode is not null)
                config.MergeMode = options.MergeMode.Value;
            if (options.PixelSnapH is not null)
                config.PixelSnapH = options.PixelSnapH.Value;
            if (options.PixelSnapV is not null)
                config.PixelSnapV = options.PixelSnapV.Value;
            if (options.OversampleH is not null)
                config.OversampleH = options.OversampleH.Value;
            if (options.OversampleV is not null)
                config.OversampleV = options.OversampleV.Value;
            if (options.EllipsisChar is not null)
                config.EllipsisChar = options.EllipsisChar.Value;
            if (options.GlyphOffset is not null)
                config.GlyphOffset = options.GlyphOffset.Value;
            if (options.GlyphMinAdvanceX is not null)
                config.GlyphMinAdvanceX = options.GlyphMinAdvanceX.Value;
            if (options.GlyphMaxAdvanceX is not null)
                config.GlyphMaxAdvanceX = options.GlyphMaxAdvanceX.Value;
            if (options.GlyphExtraAdvanceX is not null)
                config.GlyphExtraAdvanceX = options.GlyphExtraAdvanceX.Value;
            if (options.FontNo is not null)
                config.FontNo = options.FontNo.Value;
            if (options.FontLoaderFlags is not null)
                config.FontLoaderFlags = options.FontLoaderFlags.Value;
            if (options.RasterizerMultiply is not null)
                config.RasterizerMultiply = options.RasterizerMultiply.Value;
            if (options.RasterizerDensity is not null)
                config.RasterizerDensity = options.RasterizerDensity.Value;
            if (options.Flags is not null)
                config.Flags = (ImFontFlags)options.Flags.Value;
        }

        return configHandle;
    }

    private void Register(ImGuiFontInstance fontInstance)
    {
        if (!_fonts.TryAdd(fontInstance.Name, fontInstance))
        {
            _logger?.LogWarning("[{man}] Font '{fontName}' is already added to font manager by '{owner}', overwriting it!", nameof(ImGuiFontManager), fontInstance.Name, fontInstance.Owner);
            _fonts[fontInstance.Name] = fontInstance;
        }
    }
}
