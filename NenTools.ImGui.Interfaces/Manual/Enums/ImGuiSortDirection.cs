using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

public enum ImGuiSortDirection : byte
{
    ImGuiSortDirection_None = 0,
    ImGuiSortDirection_Ascending = 1,    // Ascending = 0->9, A->Z etc.
    ImGuiSortDirection_Descending = 2     // Descending = 9->0, Z->A etc.
};
