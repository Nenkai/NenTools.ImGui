using System;
using System.Numerics;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

// Manually implemented imgui interface members
public unsafe partial interface IImGui
{
    /// <summary>
    /// Dispose handles allocated by managed callback methods.
    /// </summary>
    void DisposeCallbackHandles();

    public IImTextureRef CreateTextureRef(ulong texId);

    /// <summary>
    /// NenTools: ImGuiTextFilter::ImGuiTextFilter
    /// </summary>
    /// <param name="defaultFilter"></param>
    /// <returns></returns>
    public IDisposableHandle<IImGuiTextFilter> CreateTextFilter(string defaultFilter = "");

    /// <summary>
    /// This is needed as AddFontFromFileTTF has sanity checks (and will assert/error if some properties are off for a default structure) <br/>
    /// Refer to ImFontConfig constructor - https://github.com/ocornut/imgui/blob/842837e35b421a4c85ca30f6840321f0a3c5a029/imgui_draw.cpp#L2404
    /// </summary>
    /// <returns></returns>
    public IDisposableHandle<IImFontConfig> CreateFontConfig();

    public ulong ImTextureRef_GetTexID(IImTextureRef self);

    public void ImGuiTextFilter_ImGuiTextRange_split(IImGuiTextFilter_ImGuiTextRange self, sbyte separator, out IImVectorWrapper<IImGuiTextFilter_ImGuiTextRange> @out);

    ///<summary>
    /// Output new ranges (ImVector_Construct()/ImVector_Destruct() can be used to safely construct out_ranges)<br/>
    ///</summary>
    public void ImFontGlyphRangesBuilder_BuildRanges(IImFontGlyphRangesBuilder self, out IImVectorWrapper<uint> out_ranges);

    // Generator may convert this from sbyte to char*, which is wrong.
    // We use a span here.
    ///<summary>
    /// call after CreateContext() and before the first call to NewFrame() to provide .ini data from your own data source.<br/>
    ///</summary>
    void LoadIniSettingsFromMemory(ReadOnlySpan<byte> data, nuint ini_size);

    string SaveIniSettingsToMemory(out nuint? out_ini_size);

    // These exists so that we can pass null to p_open.
    /// <inheritdoc cref="Begin(string, ref bool, ImGuiWindowFlags)"/>
    bool Begin(string name, ImGuiWindowFlags flags);

    /// <inheritdoc cref="Begin(string, ref bool, ImGuiWindowFlags)"/>
    bool Begin(ReadOnlySpan<byte> name, ImGuiWindowFlags flags);

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

    #region Combo overloads
    public bool Combo(string label, ref byte value, string items_separated_by_zeros);
    public bool Combo(ReadOnlySpan<byte> label, ref byte value, ReadOnlySpan<byte> items_separated_by_zeros);
    public bool Combo(string label, ref ushort value, string items_separated_by_zeros);
    public bool Combo(ReadOnlySpan<byte> label, ref ushort value, ReadOnlySpan<byte> items_separated_by_zeros);
    #endregion

    #region InputFloat overloads
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
    #endregion

    #region Scalar overloads
    public bool InputScalarEx(string label, ref byte p_data, ref byte p_step, ref byte p_step_fast, string format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref byte p_data, ref byte p_step, ref byte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(string label, ref sbyte p_data, ref sbyte p_step, ref sbyte p_step_fast, string format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref sbyte p_data, ref sbyte p_step, ref sbyte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(string label, ref ushort p_data, ref ushort p_step, ref ushort p_step_fast, string format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref ushort p_data, ref ushort p_step, ref ushort p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(string label, ref short p_data, ref short p_step, ref short p_step_fast, string format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref short p_data, ref short p_step, ref short p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(string label, ref uint p_data, ref uint p_step, ref uint p_step_fast, string format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref uint p_data, ref uint p_step, ref uint p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(string label, ref int p_data, ref int p_step, ref int p_step_fast, string format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref int p_data, ref int p_step, ref int p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(string label, ref ulong p_data, ref ulong p_step, ref ulong p_step_fast, string format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref ulong p_data, ref ulong p_step, ref ulong p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(string label, ref long p_data, ref long p_step, ref long p_step_fast, string format, ImGuiInputTextFlags flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref long p_data, ref long p_step, ref long p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags);
    #endregion

    /// <inheritdoc cref="BeginPopupModal(string, ref bool, ImGuiWindowFlags)"/>
    bool BeginPopupModal(string name, ImGuiWindowFlags flags);

    /// <inheritdoc cref="BeginPopupModal(string, ref bool, ImGuiWindowFlags)"/>
    bool BeginPopupModal(ReadOnlySpan<byte> name, ImGuiWindowFlags flags);
}

public unsafe partial interface IImGuiPlatformIO
{
    /// <summary>
    /// For use with <see cref="AddOpenInShellCallback(OpenInShellDelegate)"/>
    /// </summary>
    /// <param name="context"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public delegate bool OpenInShellDelegate(IImGuiContext context, ReadOnlySpan<byte> path);
    public delegate string? GetClipboardTextDelegate(IImGuiContext context);
    public delegate void SetClipboardTextDelegate(IImGuiContext context, ReadOnlySpan<byte> text);

    /// <summary>
    /// Adds a managed callback to Platform_OpenInShellFn<br/>
    /// <see cref="DisposeCallbackHandles"/> is intended to be called to clean up unmanaged handles.
    /// </summary>
    /// <param name="callback"></param>
    void AddOpenInShellCallback(OpenInShellDelegate callback);

    /// <summary>
    /// Adds a managed callback to Platform_GetClipboardTextFn<br/>
    /// <see cref="DisposeCallbackHandles"/> is intended to be called to clean up unmanaged handles.
    /// </summary>
    /// <param name="callback"></param>
    void AddGetClipboardTextCallback(GetClipboardTextDelegate callback);

    /// <summary>
    /// Adds a managed callback to Platform_SetClipboardTextFn<br/>
    /// <see cref="DisposeCallbackHandles"/> is intended to be called to clean up unmanaged handles.
    /// </summary>
    /// <param name="callback"></param>
    void AddSetClipboardTextCallback(SetClipboardTextDelegate callback);
}

#region Forward-declared enums not caught by ClangSharpPInvokeGenerator
// Forward declaration.
public enum ImGuiMouseSource : int
{
    ImGuiMouseSource_Mouse = 0,         // Input is coming from an actual mouse.
    ImGuiMouseSource_TouchScreen,       // Input is coming from a touch screen (no hovering prior to initial press, less precise initial press aiming, dual-axis wheeling possible).
    ImGuiMouseSource_Pen,               // Input is coming from a pressure/magnetic pen (often used in conjunction with high-sampling rates).
    ImGuiMouseSource_COUNT
};

/// <summary>
/// A key identifier (ImGuiKey_XXX or ImGuiMod_XXX value): can represent Keyboard, Mouse and Gamepad values.<br/>
/// All our named keys are >= 512. Keys value 0 to 511 are left unused and were legacy native/opaque key values (&lt; 1.87).<br/>
/// Support for legacy keys was completely removed in 1.91.5.<br/>
/// Read details about the 1.87+ transition : https://github.com/ocornut/imgui/issues/4921<br/>
/// Note that "Keys" related to physical keys and are not the same concept as input "Characters", the later are submitted via io.AddInputCharacter().<br/>
/// The keyboard key enum values are named after the keys on a standard US keyboard, and on other keyboard types the keys reported may not match the keycaps.<br/>
/// </summary>
public enum ImGuiKey : int
{
    // Keyboard
    ImGuiKey_None = 0,
    ImGuiKey_NamedKey_BEGIN = 512,  // First valid key value (other than 0)

    ImGuiKey_Tab = 512,             // == ImGuiKey_NamedKey_BEGIN
    ImGuiKey_LeftArrow,
    ImGuiKey_RightArrow,
    ImGuiKey_UpArrow,
    ImGuiKey_DownArrow,
    ImGuiKey_PageUp,
    ImGuiKey_PageDown,
    ImGuiKey_Home,
    ImGuiKey_End,
    ImGuiKey_Insert,
    ImGuiKey_Delete,
    ImGuiKey_Backspace,
    ImGuiKey_Space,
    ImGuiKey_Enter,
    ImGuiKey_Escape,
    ImGuiKey_LeftCtrl, ImGuiKey_LeftShift, ImGuiKey_LeftAlt, ImGuiKey_LeftSuper,     // Also see ImGuiMod_Ctrl, ImGuiMod_Shift, ImGuiMod_Alt, ImGuiMod_Super below!
    ImGuiKey_RightCtrl, ImGuiKey_RightShift, ImGuiKey_RightAlt, ImGuiKey_RightSuper,
    ImGuiKey_Menu,
    ImGuiKey_0, ImGuiKey_1, ImGuiKey_2, ImGuiKey_3, ImGuiKey_4, ImGuiKey_5, ImGuiKey_6, ImGuiKey_7, ImGuiKey_8, ImGuiKey_9,
    ImGuiKey_A, ImGuiKey_B, ImGuiKey_C, ImGuiKey_D, ImGuiKey_E, ImGuiKey_F, ImGuiKey_G, ImGuiKey_H, ImGuiKey_I, ImGuiKey_J,
    ImGuiKey_K, ImGuiKey_L, ImGuiKey_M, ImGuiKey_N, ImGuiKey_O, ImGuiKey_P, ImGuiKey_Q, ImGuiKey_R, ImGuiKey_S, ImGuiKey_T,
    ImGuiKey_U, ImGuiKey_V, ImGuiKey_W, ImGuiKey_X, ImGuiKey_Y, ImGuiKey_Z,
    ImGuiKey_F1, ImGuiKey_F2, ImGuiKey_F3, ImGuiKey_F4, ImGuiKey_F5, ImGuiKey_F6,
    ImGuiKey_F7, ImGuiKey_F8, ImGuiKey_F9, ImGuiKey_F10, ImGuiKey_F11, ImGuiKey_F12,
    ImGuiKey_F13, ImGuiKey_F14, ImGuiKey_F15, ImGuiKey_F16, ImGuiKey_F17, ImGuiKey_F18,
    ImGuiKey_F19, ImGuiKey_F20, ImGuiKey_F21, ImGuiKey_F22, ImGuiKey_F23, ImGuiKey_F24,
    ImGuiKey_Apostrophe,        // '
    ImGuiKey_Comma,             // ,
    ImGuiKey_Minus,             // -
    ImGuiKey_Period,            // .
    ImGuiKey_Slash,             // /
    ImGuiKey_Semicolon,         // ;
    ImGuiKey_Equal,             // =
    ImGuiKey_LeftBracket,       // [
    ImGuiKey_Backslash,         // \ (this text inhibit multiline comment caused by backslash)
    ImGuiKey_RightBracket,      // ]
    ImGuiKey_GraveAccent,       // `
    ImGuiKey_CapsLock,
    ImGuiKey_ScrollLock,
    ImGuiKey_NumLock,
    ImGuiKey_PrintScreen,
    ImGuiKey_Pause,
    ImGuiKey_Keypad0, ImGuiKey_Keypad1, ImGuiKey_Keypad2, ImGuiKey_Keypad3, ImGuiKey_Keypad4,
    ImGuiKey_Keypad5, ImGuiKey_Keypad6, ImGuiKey_Keypad7, ImGuiKey_Keypad8, ImGuiKey_Keypad9,
    ImGuiKey_KeypadDecimal,
    ImGuiKey_KeypadDivide,
    ImGuiKey_KeypadMultiply,
    ImGuiKey_KeypadSubtract,
    ImGuiKey_KeypadAdd,
    ImGuiKey_KeypadEnter,
    ImGuiKey_KeypadEqual,
    ImGuiKey_AppBack,               // Available on some keyboard/mouses. Often referred as "Browser Back"
    ImGuiKey_AppForward,
    ImGuiKey_Oem102,                // Non-US backslash.

    // Gamepad
    // (analog values are 0.0f to 1.0f)
    // (download controller mapping PNG/PSD at http://dearimgui.com/controls_sheets)
    //                              // XBOX        | SWITCH  | PLAYSTA. | -> ACTION
    ImGuiKey_GamepadStart,          // Menu        | +       | Options  |
    ImGuiKey_GamepadBack,           // View        | -       | Share    |
    ImGuiKey_GamepadFaceLeft,       // X           | Y       | Square   | Tap: Toggle Menu. Hold: Windowing mode (Focus/Move/Resize windows)
    ImGuiKey_GamepadFaceRight,      // B           | A       | Circle   | Cancel / Close / Exit
    ImGuiKey_GamepadFaceUp,         // Y           | X       | Triangle | Text Input / On-screen Keyboard
    ImGuiKey_GamepadFaceDown,       // A           | B       | Cross    | Activate / Open / Toggle / Tweak
    ImGuiKey_GamepadDpadLeft,       // D-pad Left  | "       | "        | Move / Tweak / Resize Window (in Windowing mode)
    ImGuiKey_GamepadDpadRight,      // D-pad Right | "       | "        | Move / Tweak / Resize Window (in Windowing mode)
    ImGuiKey_GamepadDpadUp,         // D-pad Up    | "       | "        | Move / Tweak / Resize Window (in Windowing mode)
    ImGuiKey_GamepadDpadDown,       // D-pad Down  | "       | "        | Move / Tweak / Resize Window (in Windowing mode)
    ImGuiKey_GamepadL1,             // L Bumper    | L       | L1       | Tweak Slower / Focus Previous (in Windowing mode)
    ImGuiKey_GamepadR1,             // R Bumper    | R       | R1       | Tweak Faster / Focus Next (in Windowing mode)
    ImGuiKey_GamepadL2,             // L Trigger   | ZL      | L2       | [Analog]
    ImGuiKey_GamepadR2,             // R Trigger   | ZR      | R2       | [Analog]
    ImGuiKey_GamepadL3,             // L Stick     | L3      | L3       |
    ImGuiKey_GamepadR3,             // R Stick     | R3      | R3       |
    ImGuiKey_GamepadLStickLeft,     //             |         |          | [Analog] Move Window (in Windowing mode)
    ImGuiKey_GamepadLStickRight,    //             |         |          | [Analog] Move Window (in Windowing mode)
    ImGuiKey_GamepadLStickUp,       //             |         |          | [Analog] Move Window (in Windowing mode)
    ImGuiKey_GamepadLStickDown,     //             |         |          | [Analog] Move Window (in Windowing mode)
    ImGuiKey_GamepadRStickLeft,     //             |         |          | [Analog]
    ImGuiKey_GamepadRStickRight,    //             |         |          | [Analog]
    ImGuiKey_GamepadRStickUp,       //             |         |          | [Analog]
    ImGuiKey_GamepadRStickDown,     //             |         |          | [Analog]

    // Aliases: Mouse Buttons (auto-submitted from AddMouseButtonEvent() calls)
    // - This is mirroring the data also written to io.MouseDown[], io.MouseWheel, in a format allowing them to be accessed via standard key API.
    ImGuiKey_MouseLeft, ImGuiKey_MouseRight, ImGuiKey_MouseMiddle, ImGuiKey_MouseX1, ImGuiKey_MouseX2, ImGuiKey_MouseWheelX, ImGuiKey_MouseWheelY,

    // [Internal] Reserved for mod storage
    ImGuiKey_ReservedForModCtrl, ImGuiKey_ReservedForModShift, ImGuiKey_ReservedForModAlt, ImGuiKey_ReservedForModSuper,

    // [Internal] If you need to iterate all keys (for e.g. an input mapper) you may use ImGuiKey_NamedKey_BEGIN..ImGuiKey_NamedKey_END.
    //ImGuiKey_NamedKey_END,
    //ImGuiKey_NamedKey_COUNT = ImGuiKey_NamedKey_END - ImGuiKey_NamedKey_BEGIN,

    // Keyboard Modifiers (explicitly submitted by backend via AddKeyEvent() calls)
    // - Any functions taking a ImGuiKeyChord parameter can binary-or those with regular keys, e.g. Shortcut(ImGuiMod_Ctrl | ImGuiKey_S).
    // - Those are written back into io.KeyCtrl, io.KeyShift, io.KeyAlt, io.KeySuper for convenience,
    //   but may be accessed via standard key API such as IsKeyPressed(), IsKeyReleased(), querying duration etc.
    // - Code polling every key (e.g. an interface to detect a key press for input mapping) might want to ignore those
    //   and prefer using the real keys (e.g. ImGuiKey_LeftCtrl, ImGuiKey_RightCtrl instead of ImGuiMod_Ctrl).
    // - In theory the value of keyboard modifiers should be roughly equivalent to a logical or of the equivalent left/right keys.
    //   In practice: it's complicated; mods are often provided from different sources. Keyboard layout, IME, sticky keys and
    //   backends tend to interfere and break that equivalence. The safer decision is to relay that ambiguity down to the end-user...
    // - On macOS, we swap Cmd(Super) and Ctrl keys at the time of the io.AddKeyEvent() call.
    ImGuiMod_None = 0,
    ImGuiMod_Ctrl = 1 << 12, // Ctrl (non-macOS), Cmd (macOS)
    ImGuiMod_Shift = 1 << 13, // Shift
    ImGuiMod_Alt = 1 << 14, // Option/Menu
    ImGuiMod_Super = 1 << 15, // Windows/Super (non-macOS), Ctrl (macOS)
    ImGuiMod_Mask_ = 0xF000,  // 4-bits

    //ImGuiKey_COUNT = ImGuiKey_NamedKey_END,    // Obsoleted in 1.91.5 because it was misleading (since named keys don't start at 0 anymore)
    ImGuiMod_Shortcut = ImGuiMod_Ctrl,            // Removed in 1.90.7, you can now simply use ImGuiMod_Ctrl
    //ImGuiKey_ModCtrl = ImGuiMod_Ctrl, ImGuiKey_ModShift = ImGuiMod_Shift, ImGuiKey_ModAlt = ImGuiMod_Alt, ImGuiKey_ModSuper = ImGuiMod_Super, // Renamed in 1.89
    //ImGuiKey_KeyPadEnter = ImGuiKey_KeypadEnter,              // Renamed in 1.87
};

public enum ImGuiDir : int
{
    ImGuiDir_None = -1,
    ImGuiDir_Left = 0,
    ImGuiDir_Right = 1,
    ImGuiDir_Up = 2,
    ImGuiDir_Down = 3,
    ImGuiDir_COUNT
};

public enum ImGuiSortDirection : byte
{
    ImGuiSortDirection_None = 0,
    ImGuiSortDirection_Ascending = 1,    // Ascending = 0->9, A->Z etc.
    ImGuiSortDirection_Descending = 2     // Descending = 9->0, Z->A etc.
};
#endregion