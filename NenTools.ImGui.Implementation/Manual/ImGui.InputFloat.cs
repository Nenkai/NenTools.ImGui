using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using NenTools.ImGui.Interfaces;
using NenTools.ImGui.Native;

namespace NenTools.ImGui.Implementation;

public unsafe partial class ImGui : IImGui
{
    public bool InputFloat2(string label, ref Vector2 v) => ImGuiMethods.InputFloat2(label, ref v);
    public bool InputFloat2(ReadOnlySpan<byte> label, ref Vector2 v)
    {
        fixed (byte* pBuf = label)
            return ImGuiMethods.InputFloat2((sbyte*)pBuf, ref v);
    }

    public bool InputFloat2Ex(string label, ref Vector2 v, string format, ImGuiInputTextFlags flags) => ImGuiMethods.InputFloat2Ex(label, ref v, format, (int)flags);
    public bool InputFloat2Ex(ReadOnlySpan<byte> label, ref Vector2 v, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputFloat2Ex((sbyte*)pBuf, ref v, (sbyte*)pFormat, (int)flags);
    }

    public bool InputFloat3(string label, ref Vector3 v) => ImGuiMethods.InputFloat3(label, ref v);
    public bool InputFloat3(ReadOnlySpan<byte> label, ref Vector3 v)
    {
        fixed (byte* pBuf = label)
            return ImGuiMethods.InputFloat3((sbyte*)pBuf, ref v);
    }

    public bool InputFloat3Ex(string label, ref Vector3 v, string format, ImGuiInputTextFlags flags) => ImGuiMethods.InputFloat3Ex(label, ref v, format, (int)flags);
    public bool InputFloat3Ex(ReadOnlySpan<byte> label, ref Vector3 v, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputFloat3Ex((sbyte*)pBuf, ref v, (sbyte*)pFormat, (int)flags);
    }

    public bool InputFloat4(string label, ref Vector4 v) => ImGuiMethods.InputFloat4(label, ref v);
    public bool InputFloat4(ReadOnlySpan<byte> label, ref Vector4 v)
    {
        fixed (byte* pBuf = label)
            return ImGuiMethods.InputFloat4((sbyte*)pBuf, ref v);
    }

    public bool InputFloat4Ex(string label, ref Vector4 v, string format, ImGuiInputTextFlags flags) => ImGuiMethods.InputFloat4Ex(label, ref v, format, (int)flags);
    public bool InputFloat4Ex(ReadOnlySpan<byte> label, ref Vector4 v, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputFloat4Ex((sbyte*)pBuf, ref v, (sbyte*)pFormat, (int)flags);
    }
}
