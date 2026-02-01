using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

public unsafe partial interface IImGui
{
    /// <summary>
    /// NenTools: ImGuiTextFilter::ImGuiTextFilter
    /// </summary>
    /// <param name="defaultFilter"></param>
    /// <returns></returns>
    public IDisposableHandle<IImGuiTextFilter> CreateTextFilter(string defaultFilter = "");

    public void ImGuiTextFilter_ImGuiTextRange_split(IImGuiTextFilter_ImGuiTextRange self, sbyte separator, out IImVectorWrapper<IImGuiTextFilter_ImGuiTextRange> @out);
}