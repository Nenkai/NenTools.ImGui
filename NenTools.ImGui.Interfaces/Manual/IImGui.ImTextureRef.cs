using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

public unsafe partial interface IImGui
{
    /// <inheritdoc cref="BeginPopupModal(string, ref bool, ImGuiWindowFlags)"/>
    bool BeginPopupModal(string name, ImGuiWindowFlags flags);

    /// <inheritdoc cref="BeginPopupModal(string, ref bool, ImGuiWindowFlags)"/>
    bool BeginPopupModal(ReadOnlySpan<byte> name, ImGuiWindowFlags flags);
}