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

// Overload input functions such that buf & buf_size => single ReadOnlySpan argument
public unsafe partial class ImGui : IImGui
{
    public bool InputText(string label, Span<byte> buf, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputText(label, (sbyte*)pBuf, (nuint)buf.Length, (int)flags);
    }

    public bool InputText(ReadOnlySpan<byte> label, Span<byte> buf, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputText((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)pBuf, (nuint)buf.Length, (int)flags);
    }

    public bool InputTextEx(string label, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextEx(label, (sbyte*)pBuf, (nuint)buf.Length, (int)flags, callback, user_data);
    }

    public bool InputTextEx(ReadOnlySpan<byte> label, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextEx((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)pBuf, (nuint)buf.Length, (int)flags, callback, user_data);
    }

    public bool InputTextMultiline(string label, Span<byte> buf)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextMultiline(label, (sbyte*)pBuf, (nuint)buf.Length);
    }

    public bool InputTextMultiline(ReadOnlySpan<byte> label, Span<byte> buf)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextMultiline((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)pBuf, (nuint)buf.Length);
    }

    public bool InputTextMultilineEx(string label, Span<byte> buf, Vector2 size, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextMultilineEx(label, (sbyte*)pBuf, (nuint)buf.Length, size, (int)flags, callback, user_data);
    }

    public bool InputTextMultilineEx(ReadOnlySpan<byte> label, Span<byte> buf, Vector2 size, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextMultilineEx((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)pBuf, (nuint)buf.Length, size, (int)flags, callback, user_data);
    }

    public bool InputTextWithHint(string label, string hint, Span<byte> buf, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextWithHint(label, hint, (sbyte*)pBuf, (nuint)buf.Length, (int)flags);
    }

    public bool InputTextWithHint(ReadOnlySpan<byte> label, Span<byte> hint, Span<byte> buf, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextWithHint((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(hint)), (sbyte*)pBuf, (nuint)buf.Length, (int)flags);
    }

    public bool InputTextWithHintEx(string label, string hint, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextWithHintEx(label, hint, (sbyte*)pBuf, (nuint)buf.Length, (int)flags, callback, user_data);
    }

    public bool InputTextWithHintEx(ReadOnlySpan<byte> label, Span<byte> hint, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextWithHintEx((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(hint)), (sbyte*)pBuf, (nuint)buf.Length, (int)flags, callback, user_data);
    }

    public bool InputTextWithHint(ReadOnlySpan<byte> label, ReadOnlySpan<byte> hint, Span<byte> buf, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextWithHint((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(hint)), (sbyte*)pBuf, (nuint)buf.Length, (int)flags);
    }

    public unsafe bool InputTextWithHintEx(ReadOnlySpan<byte> label, ReadOnlySpan<byte> hint, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextWithHintEx((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(hint)), (sbyte*)pBuf, (nuint)buf.Length, (int)flags, callback, user_data);
    }
}
