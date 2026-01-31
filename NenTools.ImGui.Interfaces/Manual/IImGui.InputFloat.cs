using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

public unsafe partial interface IImGui
{
    /// <inheritdoc cref="InputFloat2(string, ref float)"/>
    bool InputFloat2(string label, ref Vector2 v);

    /// <inheritdoc cref="InputFloat2(string, ref float)"/>
    bool InputFloat2(ReadOnlySpan<byte> label, ref Vector2 v);

    /// <inheritdoc cref="InputFloat2Ex(string, ref float, string, ImGuiInputTextFlags)"/>
    bool InputFloat2Ex(string label, ref Vector2 v, string format, ImGuiInputTextFlags flags);

    /// <inheritdoc cref="InputFloat2Ex(string, ref float, string, ImGuiInputTextFlags)"/>
    bool InputFloat2Ex(ReadOnlySpan<byte> label, ref Vector2 v, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags);

    /// <inheritdoc cref="InputFloat3(string, ref float)"/>
    bool InputFloat3(string label, ref Vector3 v);

    /// <inheritdoc cref="InputFloat3(string, ref float)"/>
    bool InputFloat3(ReadOnlySpan<byte> label, ref Vector3 v);

    /// <inheritdoc cref="InputFloat3Ex(string, ref float, string, ImGuiInputTextFlags)"/>
    bool InputFloat3Ex(string label, ref Vector3 v, string format, ImGuiInputTextFlags flags);

    /// <inheritdoc cref="InputFloat3Ex(string, ref float, string, ImGuiInputTextFlags)"/>
    bool InputFloat3Ex(ReadOnlySpan<byte> label, ref Vector3 v, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags);

    /// <inheritdoc cref="InputFloat4(string, ref float)"/>
    bool InputFloat4(string label, ref Vector4 v);

    /// <inheritdoc cref="InputFloat4(string, ref float)"/>
    bool InputFloat4(ReadOnlySpan<byte> label, ref Vector4 v);

    /// <inheritdoc cref="InputFloat4Ex(string, ref float, string, ImGuiInputTextFlags)"/>
    bool InputFloat4Ex(string label, ref Vector4 v, string format, ImGuiInputTextFlags flags);

    /// <inheritdoc cref="InputFloat4Ex(string, ref float, string, ImGuiInputTextFlags)"/>
    bool InputFloat4Ex(ReadOnlySpan<byte> label, ref Vector4 v, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags);
}