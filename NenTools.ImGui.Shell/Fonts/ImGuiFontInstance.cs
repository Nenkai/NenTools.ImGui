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
    public required string Owner { get; init; }
    public required IImFont Font { get; init; }
}
