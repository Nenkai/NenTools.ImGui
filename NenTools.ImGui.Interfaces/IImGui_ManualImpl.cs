// This file was generated with ImGuiInterfaceGenerator
using System;
using System.Runtime.InteropServices;
using System.Numerics;

namespace NenTools.ImGui.Interfaces;

///<summary>
///Interface to the ImGui library.<br/>
///</summary>
public unsafe partial interface IImGui
{
    public ulong ImTextureRef_GetTexID(IImTextureRef self);
    public IImTextureRef CreateTextureRef(ulong texId);

    /// <summary>
    /// This is needed as AddFontFromFileTTF has sanity checks (and will assert/error if some properties are off for a default structure) <br/>
    /// Refer to ImFontConfig constructor - https://github.com/ocornut/imgui/blob/842837e35b421a4c85ca30f6840321f0a3c5a029/imgui_draw.cpp#L2404
    /// </summary>
    /// <returns></returns>
    public IDisposableHandle<IImFontConfig> CreateFontConfig();

    public void ImGuiTextFilter_ImGuiTextRange_split(IImGuiTextFilter_ImGuiTextRange self, sbyte separator, out IImVectorWrapper<IImGuiTextFilter_ImGuiTextRange> @out);

    ///<summary>
    /// Output new ranges (ImVector_Construct()/ImVector_Destruct() can be used to safely construct out_ranges)<br/>
    ///</summary>
    public void ImFontGlyphRangesBuilder_BuildRanges(IImFontGlyphRangesBuilder self, out IImVectorWrapper<uint> out_ranges);
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