using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

public unsafe partial interface IImGuiPlatformIO
{
    /// <summary>
    /// For use with <see cref="AddOpenInShellCallback(OpenInShellDelegate)"/>
    /// </summary>
    /// <param name="context"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public delegate bool OpenInShellDelegate(IImGuiContext context, ReadOnlySpan<byte> path);
    public delegate string? GetClipboardTextDelegate(IImGuiContext context);
    public delegate void SetClipboardTextDelegate(IImGuiContext context, ReadOnlySpan<byte> text);

    /// <summary>
    /// Adds a managed callback to Platform_OpenInShellFn<br/>
    /// <see cref="DisposeCallbackHandles"/> is intended to be called to clean up unmanaged handles.
    /// </summary>
    /// <param name="callback"></param>
    void AddOpenInShellCallback(OpenInShellDelegate callback);

    /// <summary>
    /// Adds a managed callback to Platform_GetClipboardTextFn<br/>
    /// <see cref="DisposeCallbackHandles"/> is intended to be called to clean up unmanaged handles.
    /// </summary>
    /// <param name="callback"></param>
    void AddGetClipboardTextCallback(GetClipboardTextDelegate callback);

    /// <summary>
    /// Adds a managed callback to Platform_SetClipboardTextFn<br/>
    /// <see cref="DisposeCallbackHandles"/> is intended to be called to clean up unmanaged handles.
    /// </summary>
    /// <param name="callback"></param>
    void AddSetClipboardTextCallback(SetClipboardTextDelegate callback);
}
