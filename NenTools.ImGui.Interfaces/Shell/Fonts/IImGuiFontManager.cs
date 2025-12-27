using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces.Shell.Fonts;

/// <summary>
/// Font manager for ImGui.
/// </summary>
public interface IImGuiFontManager
{
    /// <summary>
    /// Currently registered fonts.
    /// </summary>
    IReadOnlyDictionary<string, IImGuiFontInstance> Fonts { get; }

    /// <summary>
    /// Adds a font to the manager.
    /// </summary>
    /// <param name="owner">Owner of the font.</param>
    /// <param name="fontName">Font name/key.</param>
    /// <param name="path">Path to the font. TTF is expected.</param>
    /// <param name="sizePixels">Glyph size in pixels.</param>
    /// <param name="glyphRanges">Glyph range affected by this font. <b>Ensure the pointer to the array persists and doesn't move!</b></param>
    /// <param name="options">Font options.</param>
    /// <returns>New font instance. If merge mode was enabled, it may refer to an already existing font.</returns>
    unsafe IImGuiFontInstance AddFontTTF(string owner, string fontName, string path, float sizePixels, uint* glyphRanges, ImFontOptions? options = default);

    /// <summary>
    /// Adds a font to the manager.
    /// </summary>
    /// <param name="owner">Owner of the font.</param>
    /// <param name="fontName">Font name/key.</param>
    /// <param name="path">Path to the font. TTF is expected.</param>
    /// <param name="sizePixels">Glyph size in pixels.</param>
    /// <param name="glyphRanges">Glyph range affected by this font. <br/>
    /// If null, GetGlyphRangesDefault is used. <br/>
    /// <br/>
    /// The array does not have to be null-terminated (will be handled internally).<br/>
    /// </param>
    /// <param name="options">Font options.</param>
    /// <returns>New font instance. If merge mode was enabled, it may refer to an already existing font.</returns>
    IImGuiFontInstance AddFontTTF(string owner, string fontName, string path, float sizePixels, uint[] glyphRanges, ImFontOptions? options = default);

    /// <summary>
    /// Returns a font by name. Returns <see langword="null"/> if not found.
    /// </summary>
    /// <param name="name">Font name.</param>
    /// <returns>Returns <see langword="null"/> if not found.</returns>
    IImGuiFontInstance? GetFont(string name);

    /// <summary>
    /// Removes a font from the manager. Returns whether it was removed.
    /// </summary>
    /// <param name="name">Font name.</param>
    /// <returns>Returns whether it was removed.</returns>
    bool RemoveFont(string name);
}

/// <summary>
/// Font options for adding fonts.
/// </summary>
public class ImFontOptions
{
    /// <inheritdoc cref="IImFontConfig.MergeMode"/>
    public bool? MergeMode { set; get; }

    /// <inheritdoc cref="IImFontConfig.PixelSnapH"/>
    public bool? PixelSnapH { set; get; }

    /// <inheritdoc cref="IImFontConfig.PixelSnapV"/>
    public bool? PixelSnapV { set; get; }

    /// <inheritdoc cref="IImFontConfig.OversampleH"/>
    public sbyte? OversampleH { set; get; }

    /// <inheritdoc cref="IImFontConfig.OversampleV"/>
    public sbyte? OversampleV { set; get; }

    /// <inheritdoc cref="IImFontConfig.EllipsisChar"/>
    public uint? EllipsisChar { set; get; }

    /// <inheritdoc cref="IImFontConfig.SizePixels"/>
    public float? SizePixels { set; get; }

    /// <inheritdoc cref="IImFontConfig.GlyphExcludeRanges"/>
    public nint? GlyphExcludeRanges { get; set; }

    /// <inheritdoc cref="IImFontConfig.GlyphOffset"/>
    public Vector2? GlyphOffset { set; get; }

    /// <inheritdoc cref="IImFontConfig.GlyphMinAdvanceX"/>
    public float? GlyphMinAdvanceX { set; get; }

    /// <inheritdoc cref="IImFontConfig.GlyphMaxAdvanceX"/>
    public float? GlyphMaxAdvanceX { set; get; }

    /// <inheritdoc cref="IImFontConfig.GlyphExtraAdvanceX"/>
    public float? GlyphExtraAdvanceX { set; get; }

    /// <inheritdoc cref="IImFontConfig.FontNo"/>
    public uint? FontNo { set; get; }

    /// <inheritdoc cref="IImFontConfig.FontLoaderFlags"/>
    public uint? FontLoaderFlags { set; get; }

    /// <inheritdoc cref="IImFontConfig.RasterizerMultiply"/>
    public float? RasterizerMultiply { set; get; }

    /// <inheritdoc cref="IImFontConfig.RasterizerDensity"/>
    public float? RasterizerDensity { set; get; }

    /// <inheritdoc cref="IImFontConfig.Flags"/>
    public uint? Flags { set; get; }
}