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
    /// Font.
    /// </summary>
    public IImFont Font { get; }
}
