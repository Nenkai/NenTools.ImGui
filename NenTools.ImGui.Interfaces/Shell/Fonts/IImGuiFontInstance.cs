using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces.Shell.Fonts;

/// <summary>
/// Font instance, loaded by the font manager.
/// </summary>
public interface IImGuiFontInstance
{
    /// <summary>
    /// Owner for this font.
    /// </summary>
    public string Owner { get; }

    /// <summary>
    /// Name of the font.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// File path for the font, if available.
    /// </summary>
    public string? Path { get; }

    /// <summary>
    /// Font.
    /// </summary>
    public IImFont Font { get; }

    /// <summary>
    /// Glyph ranges for this font (if manually specified).
    /// </summary>
    public uint[]? GlyphRanges { get; }

    /// <summary>
    /// Whether this font is merged.
    /// </summary>
    public bool IsMerged { get; }
}
