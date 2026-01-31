using NenTools.ImGui.Interfaces;
using NenTools.ImGui.Native;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Implementation;

public unsafe partial class ImGui : IImGui
{
    // Generator may convert this from sbyte to char*, which is wrong.
    // We use a span here.
    ///<summary>
    /// call after CreateContext() and before the first call to NewFrame() to provide .ini data from your own data source.<br/>
    ///</summary>
    public void LoadIniSettingsFromMemory(ReadOnlySpan<byte> data, nuint ini_size)
    {
        fixed (byte* bytes = data)
            ImGuiMethods.LoadIniSettingsFromMemory(bytes, ini_size);
    }

    ///<summary>
    /// return a zero-terminated string with the .ini data which you can save by your own mean. call when io.WantSaveIniSettings is set, then save data by your own mean and clear io.WantSaveIniSettings.<br/>
    ///</summary>
    public string SaveIniSettingsToMemory(out nuint? out_ini_size)
    {
        nuint outIniSize = 0;
        string str = ImGuiMethods.SaveIniSettingsToMemory((nuint)(&outIniSize));
        out_ini_size = outIniSize;
        return str;
    }
}
