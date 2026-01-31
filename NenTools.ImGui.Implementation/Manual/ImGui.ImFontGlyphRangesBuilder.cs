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
    public void ImFontGlyphRangesBuilder_BuildRanges(IImFontGlyphRangesBuilder self, out IImVectorWrapper<uint> out_ranges)
    {
        var vec = new ImVector<uint>();
        ImGuiMethods.ImFontGlyphRangesBuilder_BuildRanges(self is not null ? (ImFontGlyphRangesBuilderStruct*)self.NativePointer : null, ref vec);
        out_ranges = new ImVectorWrapper<uint>(vec.Size, vec.Capacity, vec.Data, sizeof(uint), (addr) => *(uint*)addr);
    }
}
