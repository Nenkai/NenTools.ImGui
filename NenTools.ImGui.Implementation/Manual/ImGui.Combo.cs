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
    // Utils for passing other data types.
    public bool Combo(string label, ref byte value, string items_separated_by_zeros)
    {
        var valueAsInt = (int)value;
        var changed = ImGuiMethods.Combo(label, ref valueAsInt, items_separated_by_zeros);
        if (changed)
            value = (byte)valueAsInt;
        return changed;
    }

    public bool Combo(ReadOnlySpan<byte> label, ref byte value, ReadOnlySpan<byte> items_separated_by_zeros)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pItems = items_separated_by_zeros)
        {
            var valueAsInt = (int)value;
            var changed = ImGuiMethods.Combo((sbyte*)pLabel, ref valueAsInt, (sbyte*)pItems);
            if (changed)
                value = (byte)valueAsInt;
            return changed;
        }
    }

    public bool Combo(string label, ref ushort value, string items_separated_by_zeros)
    {
        var valueAsInt = (int)value;
        var changed = ImGuiMethods.Combo(label, ref valueAsInt, items_separated_by_zeros);
        if (changed)
            value = (ushort)valueAsInt;
        return changed;
    }

    public bool Combo(ReadOnlySpan<byte> label, ref ushort value, ReadOnlySpan<byte> items_separated_by_zeros)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pItems = items_separated_by_zeros)
        {
            var valueAsInt = (int)value;
            var changed = ImGuiMethods.Combo((sbyte*)pLabel, ref valueAsInt, (sbyte*)pItems);
            if (changed)
                value = (ushort)valueAsInt;
            return changed;
        }
    }
}
