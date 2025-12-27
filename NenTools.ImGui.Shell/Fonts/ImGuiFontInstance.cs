using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NenTools.ImGui.Interfaces;
using NenTools.ImGui.Interfaces.Shell.Fonts;

namespace NenTools.ImGui.Shell.Fonts;

public class ImGuiFontInstance : IImGuiFontInstance
{
    /// <inheritdoc/>
    public required string Owner { get; init; }

    /// <inheritdoc/>
    public required string Name { get; init; }

    /// <inheritdoc/>
    public string? Path { get; init; } = null!;

    /// <inheritdoc/>
    public required IImFont Font { get; init; }

    /// <inheritdoc/>
    public bool IsMerged { get; init; }

    private uint[] _glyphRange;
    public uint[]? GlyphRanges => _glyphRange;

    internal void SetGlyphRanges(uint[] ranges)
    {
        _glyphRange = ranges;
    }
}
