using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

public unsafe partial interface IImGui
{
    public bool Combo(string label, ref byte value, string items_separated_by_zeros);
    public bool Combo(ReadOnlySpan<byte> label, ref byte value, ReadOnlySpan<byte> items_separated_by_zeros);
    public bool Combo(string label, ref ushort value, string items_separated_by_zeros);
    public bool Combo(ReadOnlySpan<byte> label, ref ushort value, ReadOnlySpan<byte> items_separated_by_zeros);
}