using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NenTools.ImGui.Interfaces;
using NenTools.ImGui.Native;

namespace NenTools.ImGui.Implementation;

public unsafe partial class ImGui : IImGui
{
    public IImTextureRef CreateTextureRef(ulong texId)
    {
        return new ImTextureRef(texId);
    }

    public ulong ImTextureRef_GetTexID(IImTextureRef self)
    {
        var @struct = ((ImTextureRef)self).ToStruct();
        return ImGuiMethods.ImTextureRef_GetTexID(&@struct);
    }
}
