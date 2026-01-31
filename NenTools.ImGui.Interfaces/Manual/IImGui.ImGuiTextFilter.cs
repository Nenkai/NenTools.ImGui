using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

public unsafe partial interface IImGui
{
    // These exists so that we can pass null to p_open.
    /// <inheritdoc cref="Begin(string, ref bool, ImGuiWindowFlags)"/>
    bool Begin(string name, ImGuiWindowFlags flags);

    /// <inheritdoc cref="Begin(string, ref bool, ImGuiWindowFlags)"/>
    bool Begin(ReadOnlySpan<byte> name, ImGuiWindowFlags flags);
}