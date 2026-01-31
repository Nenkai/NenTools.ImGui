using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

public unsafe partial interface IImGui
{
    // Generator may convert this from sbyte to char*, which is wrong.
    // We use a span here.
    ///<summary>
    /// call after CreateContext() and before the first call to NewFrame() to provide .ini data from your own data source.<br/>
    ///</summary>
    void LoadIniSettingsFromMemory(ReadOnlySpan<byte> data, nuint ini_size);

    string SaveIniSettingsToMemory(out nuint? out_ini_size);
}