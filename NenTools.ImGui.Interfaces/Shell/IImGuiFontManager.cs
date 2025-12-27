using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces.Shell;

/// <summary>
/// Font manager for ImGui.
/// </summary>
public interface IImGuiFontManager
{
    /// <summary>
    /// Currently registered fonts.
    /// </summary>
    IReadOnlyDictionary<string, IImFont> Fonts { get; }

    /// <summary>
    /// Adds a font to the manager.
    /// </summary>
    /// <param name="fontName">Font name/key.</param>
    /// <param name="path">Path to the font. TTF is expected.</param>
    /// <param name="sizePixels">Glyph size in pixels.</param>
    /// <param name="glyphRanges">Glyph range affected by this font.</param>
    /// <param name="options">Font options.</param>
    /// <returns></returns>
    unsafe IImFont AddFontTTF(string fontName, string path, float sizePixels, uint* glyphRanges, ImFontOptions? options = default);

    /// <summary>
    /// Adds a font to the manager.
    /// </summary>
    /// <param name="fontName">Font name/key.</param>
    /// <param name="path">Path to the font. TTF is expected.</param>
    /// <param name="sizePixels">Glyph size in pixels.</param>
    /// <param name="glyphRanges">Glyph range affected by this font.</param>
    /// <param name="options">Font options.</param>
    /// <returns></returns>
    IImFont AddFontTTF(string fontName, string path, float sizePixels, ref uint glyphRanges, ImFontOptions? options = default);

    /// <summary>
    /// Returns a font by name. Returns <see langword="null"/> if not found.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    IImFont? GetFont(string name);

    /// <summary>
    /// Removes a font from the manager.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    bool RemoveFont(string name);
}

/// <summary>
/// Font options for adding fonts.
/// </summary>
public class ImFontOptions
{
    ///<summary>
    ///           TTF/OTF data<br/>
    ///</summary>
    public nint? FontData { get; set; }

    ///<summary>
    ///           TTF/OTF data size<br/>
    ///</summary>
    public int? FontDataSize { set; get; }

    ///<summary>
    /// true      TTF/OTF data ownership taken by the owner ImFontAtlas (will delete memory itself).<br/>
    ///</summary>
    public bool? FontDataOwnedByAtlas { set; get; }

    ///<summary>
    /// false     Merge into previous ImFont, so you can combine multiple inputs font into one ImFont (e.g. ASCII font + icons + Japanese glyphs). You may want to use GlyphOffset.y when merge font of different heights.<br/>
    ///<br/>
    /// Options<br/>
    ///</summary>
    public bool? MergeMode { set; get; }

    ///<summary>
    /// false     Align every glyph AdvanceX to pixel boundaries. Useful e.g. if you are merging a non-pixel aligned font with the default font. If enabled, you can set OversampleH/V to 1.<br/>
    ///</summary>
    public bool? PixelSnapH { set; get; }

    ///<summary>
    /// true      Align Scaled GlyphOffset.y to pixel boundaries.<br/>
    ///</summary>
    public bool? PixelSnapV { set; get; }

    ///<summary>
    /// 0 (2)     Rasterize at higher quality for sub-pixel positioning. 0 == auto == 1 or 2 depending on size. Note the difference between 2 and 3 is minimal. You can reduce this to 1 for large glyphs save memory. Read https:github.com/nothings/stb/blob/master/tests/oversample/README.md for details.<br/>
    ///</summary>
    public sbyte? OversampleH { set; get; }

    ///<summary>
    /// 0 (1)     Rasterize at higher quality for sub-pixel positioning. 0 == auto == 1. This is not really useful as we don't use sub-pixel positions on the Y axis.<br/>
    ///</summary>
    public sbyte? OversampleV { set; get; }

    ///<summary>
    /// 0         Explicitly specify Unicode codepoint of ellipsis character. When fonts are being merged first specified ellipsis will be used.<br/>
    ///</summary>
    public uint? EllipsisChar { set; get; }

    ///<summary>
    ///           Size in pixels for rasterizer (more or less maps to the resulting font height).<br/>
    ///</summary>
    public float? SizePixels { set; get; }

    ///<summary>
    /// NULL      *LEGACY* THE ARRAY DATA NEEDS TO PERSIST AS LONG AS THE FONT IS ALIVE. Pointer to a user-provided list of Unicode range (2 value per range, values are inclusive, zero-terminated list).<br/>
    ///</summary>
    public nint? GlyphRanges { get; set; }

    ///<summary>
    /// NULL      Pointer to a small user-provided list of Unicode ranges (2 value per range, values are inclusive, zero-terminated list). This is very close to GlyphRanges[] but designed to exclude ranges from a font source, when merging fonts with overlapping glyphs. Use "Input Glyphs Overlap Detection Tool" to find about your overlapping ranges.<br/>
    ///</summary>
    public nint? GlyphExcludeRanges { get; set; }

    ///<summary>
    /// 0, 0      Offset (in pixels) all glyphs from this font input. Absolute value for default size, other sizes will scale this value.<br/>
    ///<br/>
    ///ImVec2        GlyphExtraSpacing;       0, 0      (REMOVED AT IT SEEMS LARGELY OBSOLETE. PLEASE REPORT IF YOU WERE USING THIS). Extra spacing (in pixels) between glyphs when rendered: essentially add to glyph-&gt;AdvanceX. Only X axis is supported for now.<br/>
    ///</summary>
    public Vector2? GlyphOffset { set; get; }

    ///<summary>
    /// 0         Minimum AdvanceX for glyphs, set Min to align font icons, set both Min/Max to enforce mono-space font. Absolute value for default size, other sizes will scale this value.<br/>
    ///</summary>
    public float? GlyphMinAdvanceX { set; get; }

    ///<summary>
    /// FLT_MAX   Maximum AdvanceX for glyphs<br/>
    ///</summary>
    public float? GlyphMaxAdvanceX { set; get; }

    ///<summary>
    /// 0         Extra spacing (in pixels) between glyphs. Please contact us if you are using this.  FIXME-NEWATLAS: Intentionally unscaled<br/>
    ///</summary>
    public float? GlyphExtraAdvanceX { set; get; }

    ///<summary>
    /// 0         Index of font within TTF/OTF file<br/>
    ///</summary>
    public uint? FontNo { set; get; }

    ///<summary>
    /// 0         Settings for custom font builder. THIS IS BUILDER IMPLEMENTATION DEPENDENT. Leave as zero if unsure.<br/>
    ///</summary>
    public uint? FontLoaderFlags { set; get; }

    ///<summary>
    /// 1.0f      Linearly brighten (&gt;1.0f) or darken (&lt;1.0f) font output. Brightening small fonts may be a good workaround to make them more readable. This is a silly thing we may remove in the future.<br/>
    ///<br/>
    ///unsigned int  FontBuilderFlags;        --        [Renamed in 1.92] Ue FontLoaderFlags.<br/>
    ///</summary>
    public float? RasterizerMultiply { set; get; }

    ///<summary>
    /// 1.0f      [LEGACY: this only makes sense when ImGuiBackendFlags_RendererHasTextures is not supported] DPI scale multiplier for rasterization. Not altering other font metrics: makes it easy to swap between e.g. a 100% and a 400% fonts for a zooming display, or handle Retina screen. IMPORTANT: If you change this it is expected that you increase/decrease font scale roughly to the inverse of this, otherwise quality may look lowered.<br/>
    ///</summary>
    public float? RasterizerDensity { set; get; }

    ///<summary>
    /// Font flags (don't use just yet, will be exposed in upcoming 1.92.X updates)<br/>
    ///<br/>
    /// [Internal]<br/>
    ///</summary>
    public uint? Flags { set; get; }

    ///<summary>
    /// Target font (as we merging fonts, multiple ImFontConfig may target the same font)<br/>
    ///</summary>
    //public IImFont DstFont { get; }

    ///<summary>
    /// Custom font backend for this source (default source is the one stored in ImFontAtlas)<br/>
    ///</summary>
    //public IImFontLoader FontLoader { get; }

    ///<summary>
    /// Font loader opaque storage (per font config)<br/>
    ///</summary>
    public nint? FontLoaderData { get; set; }
}