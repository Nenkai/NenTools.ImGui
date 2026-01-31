using System;
using System.Numerics;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

// Manually implemented imgui interface members
public unsafe partial interface IImGui
{
    /// <summary>
    /// Dispose handles allocated by managed callback methods.
    /// </summary>
    void DisposeCallbackHandles();
}

#region Forward-declared enums not caught by ClangSharpPInvokeGenerator





#endregion