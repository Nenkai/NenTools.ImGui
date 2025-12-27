using Microsoft.Extensions.Logging;

using NenTools.ImGui.Implementation;
using NenTools.ImGui.Interfaces;
using NenTools.ImGui.Interfaces.Shell.Fonts;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        => AddFontTTF(owner, fontName, path, sizePixels, ref Unsafe.AsRef<uint>(glyphRanges), options);

    public unsafe IImGuiFontInstance AddFontTTF(string owner, string fontName, string path, float sizePixels, ref uint glyphRanges, ImFontOptions? options = default)
    {
        IImGuiIO io = _imGui.GetIO();

        using IDisposableHandle<IImFontConfig> configHandle = _imGui.CreateFontConfig();
        IImFontConfig config = configHandle.Value;

        if (options != null)
        {
            if (options.FontData is not null)
                config.FontData = (void*)options.FontData.Value;
            if (options.FontDataSize is not null)
                config.FontDataSize = options.FontDataSize.Value;
            if (options.FontDataOwnedByAtlas is not null)
                config.FontDataOwnedByAtlas = options.FontDataOwnedByAtlas.Value;
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
            if (options.FontLoaderData is not null)
                config.FontLoaderData = (void*)options.FontLoaderData.Value;
        }

        _logger?.LogWarning("[{man}] Adding font {fontName} ({owner}) from \"{path}\"", nameof(ImGuiFontManager), fontName, owner, path);

        IImFont font = _imGui.ImFontAtlas_AddFontFromFileTTF(io.Fonts, path, sizePixels, config, ref glyphRanges);
        IImGuiFontInstance fontInstance = new ImGuiFontInstance
        {
            Owner = owner,
            Font = font
        };

        if (!_fonts.TryAdd(fontName, fontInstance))
        {
            _logger?.LogWarning("[{man}] Font '{fontName}' is already added to font manager by '{owner}', overwriting it!", nameof(ImGuiFontManager), fontName, owner);
            _fonts[fontName] = fontInstance;
        }

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
}
