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
    /// <inheritdoc cref="InputText(string, sbyte*, nuint, ImGuiInputTextFlags)"/>
    public bool InputText(string label, Span<byte> buf, ImGuiInputTextFlags flags);

    /// <inheritdoc cref="InputText(string, sbyte*, nuint, ImGuiInputTextFlags)"/>
    public bool InputText(ReadOnlySpan<byte> label, Span<byte> buf, ImGuiInputTextFlags flags);

    /// <inheritdoc cref="InputTextEx(string, sbyte*, nuint, ImGuiInputTextFlags, delegate* unmanaged[Cdecl]{nint, int}, void*)"/>
    public bool InputTextEx(string label, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data);

    /// <inheritdoc cref="InputTextEx(string, sbyte*, nuint, ImGuiInputTextFlags, delegate* unmanaged[Cdecl]{nint, int}, void*)"/>
    public bool InputTextEx(ReadOnlySpan<byte> label, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data);

    /// <inheritdoc cref="InputTextMultiline(string, sbyte*, nuint)"/>
    public bool InputTextMultiline(string label, Span<byte> buf);

    /// <inheritdoc cref="InputTextMultiline(string, sbyte*, nuint)"/>
    public bool InputTextMultiline(ReadOnlySpan<byte> label, Span<byte> buf);

    /// <inheritdoc cref="InputTextMultilineEx(string, sbyte*, nuint, Vector2, ImGuiInputTextFlags, delegate* unmanaged[Cdecl]{nint, int}, void*)"/>
    public bool InputTextMultilineEx(string label, Span<byte> buf, Vector2 size, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data);

    /// <inheritdoc cref="InputTextMultilineEx(string, sbyte*, nuint, Vector2, ImGuiInputTextFlags, delegate* unmanaged[Cdecl]{nint, int}, void*)"/>
    public bool InputTextMultilineEx(ReadOnlySpan<byte> label, Span<byte> buf, Vector2 size, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data);

    /// <inheritdoc cref="InputTextWithHint(string, string, sbyte*, nuint, ImGuiInputTextFlags)"/>
    public bool InputTextWithHint(string label, string hint, Span<byte> buf, ImGuiInputTextFlags flags);

    /// <inheritdoc cref="InputTextWithHint(string, string, sbyte*, nuint, ImGuiInputTextFlags)"/>
    public bool InputTextWithHint(ReadOnlySpan<byte> label, ReadOnlySpan<byte> hint, Span<byte> buf, ImGuiInputTextFlags flags);

    /// <inheritdoc cref="InputTextWithHintEx(string, string, sbyte*, nuint, ImGuiInputTextFlags, delegate* unmanaged[Cdecl]{nint, int}, void*)"/>
    public bool InputTextWithHintEx(string label, string hint, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data);

    /// <inheritdoc cref="InputTextWithHintEx(string, string, sbyte*, nuint, ImGuiInputTextFlags, delegate* unmanaged[Cdecl]{nint, int}, void*)"/>
    public bool InputTextWithHintEx(ReadOnlySpan<byte> label, ReadOnlySpan<byte> hint, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data);
}