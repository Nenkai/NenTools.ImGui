using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

public unsafe partial interface IImGui
{
    public IImTextureRef CreateTextureRef(ulong texId);

    public ulong ImTextureRef_GetTexID(IImTextureRef self);
}