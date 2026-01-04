using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace NenTools.ImGui.Native;

public unsafe partial class ImGuiMethods
{
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_LoadIniSettingsFromMemory", ExactSpelling = true)]
    public static extern void LoadIniSettingsFromMemory(byte* ini_data, nuint ini_size);

    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_SaveIniSettingsToMemory", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.LPUTF8Str)]
    public static extern string SaveIniSettingsToMemory(nuint out_ini_size);

    // We have these so that we can pass null to p_open.
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_Begin", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool Begin([MarshalAs(UnmanagedType.LPUTF8Str)] string name, bool* p_open, int flags);
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_Begin", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool Begin(sbyte* name, bool* p_open, int flags);

    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_BeginPopupModal", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool BeginPopupModal([MarshalAs(UnmanagedType.LPUTF8Str)] string name, bool* p_open, int flags);
    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_BeginPopupModal", ExactSpelling = true)]
    public static extern bool BeginPopupModal(sbyte* name, bool* p_open, int flags);

    #region InputFloat
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_InputFloat2", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool InputFloat2([MarshalAs(UnmanagedType.LPUTF8Str)] string label, ref Vector2 v);
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_InputFloat2", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool InputFloat2(sbyte* label, ref Vector2 v);
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_InputFloat2Ex", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool InputFloat2Ex([MarshalAs(UnmanagedType.LPUTF8Str)] string label, ref Vector2 v, [MarshalAs(UnmanagedType.LPUTF8Str)] string format, int flags);
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_InputFloat2Ex", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool InputFloat2Ex(sbyte* label, ref Vector2 v, sbyte* format, int flags);
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_InputFloat3", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool InputFloat3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, ref Vector3 v);
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_InputFloat3", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool InputFloat3(sbyte* label, ref Vector3 v);
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_InputFloat3Ex", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool InputFloat3Ex([MarshalAs(UnmanagedType.LPUTF8Str)] string label, ref Vector3 v, [MarshalAs(UnmanagedType.LPUTF8Str)] string format, int flags);
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_InputFloat3Ex", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool InputFloat3Ex(sbyte* label, ref Vector3 v, sbyte* format, int flags);
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_InputFloat4", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool InputFloat4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, ref Vector4 v);
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_InputFloat4", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool InputFloat4(sbyte* label, ref Vector4 v);
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_InputFloat4Ex", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool InputFloat4Ex([MarshalAs(UnmanagedType.LPUTF8Str)] string label, ref Vector4 v, [MarshalAs(UnmanagedType.LPUTF8Str)] string format, int flags);
    [DllImport("ImGui/Binaries/ImGuiLib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_InputFloat4Ex", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool InputFloat4Ex(sbyte* label, ref Vector4 v, sbyte* format, int flags);
    #endregion
}