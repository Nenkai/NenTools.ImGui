using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

/// <summary>
/// A key identifier (ImGuiKey_XXX or ImGuiMod_XXX value): can represent Keyboard, Mouse and Gamepad values.<br/>
/// All our named keys are >= 512. Keys value 0 to 511 are left unused and were legacy native/opaque key values (&lt; 1.87).<br/>
/// Support for legacy keys was completely removed in 1.91.5.<br/>
/// Read details about the 1.87+ transition : https://github.com/ocornut/imgui/issues/4921<br/>
/// Note that "Keys" related to physical keys and are not the same concept as input "Characters", the later are submitted via io.AddInputCharacter().<br/>
/// The keyboard key enum values are named after the keys on a standard US keyboard, and on other keyboard types the keys reported may not match the keycaps.<br/>
/// </summary>

public enum ImGuiDir : int
{
    ImGuiDir_None = -1,
    ImGuiDir_Left = 0,
    ImGuiDir_Right = 1,
    ImGuiDir_Up = 2,
    ImGuiDir_Down = 3,
    ImGuiDir_COUNT
};
