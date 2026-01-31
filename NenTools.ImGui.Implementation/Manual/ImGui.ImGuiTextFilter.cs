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
    public IDisposableHandle<IImGuiTextFilter> CreateTextFilter(string defaultFilter = "")
    {
        var handle = new DisposableHandle<IImGuiTextFilter>(new ImGuiTextFilter(), Unsafe.SizeOf<ImGuiTextFilterStruct>());
        var filter = handle.Value;
        filter.InputBuf[0] = 0;
        filter.CountGrep = 0;

        if (!string.IsNullOrEmpty(defaultFilter))
        {
            byte[] bytes = Encoding.UTF8.GetBytes(defaultFilter);
            if (bytes.Length >= filter.InputBuf.Count)
                throw new ArgumentOutOfRangeException($"Default filter cannot be longer than {filter.InputBuf.Count}");

            fixed (byte* strPtr = bytes)
                NativeMemory.Copy(strPtr, filter.InputBuf.Data, (nuint)bytes.Length);
            ImGuiTextFilter_Build(filter);
        }

        return handle;
    }

    public void ImGuiTextFilter_ImGuiTextRange_split(IImGuiTextFilter_ImGuiTextRange self, sbyte separator, out IImVectorWrapper<IImGuiTextFilter_ImGuiTextRange> @out)
    {
        var vec = new ImVector<ImGuiTextFilter_ImGuiTextRangeStruct>();
        ImGuiMethods.ImGuiTextFilter_ImGuiTextRange_split(self is not null ? (ImGuiTextFilter_ImGuiTextRangeStruct*)self.NativePointer : null, separator, ref vec);
        @out = new ImVectorWrapper<IImGuiTextFilter_ImGuiTextRange>(vec.Size, vec.Capacity, vec.Data,
            Unsafe.SizeOf<ImGuiTextFilter_ImGuiTextRangeStruct>(), (addr) => new ImGuiTextFilter_ImGuiTextRange((ImGuiTextFilter_ImGuiTextRangeStruct*)addr));
    }
}
