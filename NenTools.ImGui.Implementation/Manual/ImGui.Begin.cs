using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using NenTools.ImGui.Interfaces;
using NenTools.ImGui.Native;

namespace NenTools.ImGui.Implementation;

public unsafe partial class ImGui : IImGui
{
    // These exists so that we can pass null to p_open.
    public bool Begin(string name, ImGuiWindowFlags flags) => ImGuiMethods.Begin(name, null, (int)flags);
    public bool Begin(ReadOnlySpan<byte> name, ImGuiWindowFlags flags) => ImGuiMethods.Begin((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(name)), null, (int)flags);
}
