using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using NenTools.ImGui.Interfaces;
using NenTools.ImGui.Native;

using static NenTools.ImGui.Interfaces.IImGuiPlatformIO;

namespace NenTools.ImGui.Implementation;

public unsafe partial class ImGui : IImGui
{
    public unsafe partial struct ImGuiPlatformIO : IImGuiPlatformIO
    {
        public class Callbacks
        {
            public GCHandle? Handle;
            public OpenInShellDelegate? OpenInShell;
            public GetClipboardTextDelegate? GetClipboardText;
            public SetClipboardTextDelegate? SetClipboardText;
            public nint ClipboardTextPtr;
        }
        private static readonly Callbacks CallbackHandle = new();

        public void AddOpenInShellCallback(OpenInShellDelegate callback)
        {
            CallbackHandle.OpenInShell = callback;
            CallbackHandle.Handle ??= GCHandle.Alloc(CallbackHandle);

            this.Platform_OpenInShellFn = &OpenInShellWrapper;
            this.Platform_OpenInShellUserData = (void*)GCHandle.ToIntPtr(CallbackHandle.Handle.Value);

            [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
            static unsafe byte OpenInShellWrapper(nint ctx, nint path)
            {
                ImGuiContextStruct* context = (ImGuiContextStruct*)ctx;
                var io = ImGuiMethods.GetPlatformIO();

                var handle = GCHandle.FromIntPtr((nint)io->Platform_OpenInShellUserData);
                var callback = (Callbacks)handle.Target!;

                ReadOnlySpan<byte> pathSpan = MemoryMarshal.CreateReadOnlySpanFromNullTerminated((byte*)path);
                return callback.OpenInShell!(new ImGuiContext(context), pathSpan) ? (byte)1 : (byte)0;
            }
        }

        public void AddSetClipboardTextCallback(SetClipboardTextDelegate callback)
        {
            CallbackHandle.SetClipboardText = callback;
            CallbackHandle.Handle ??= GCHandle.Alloc(CallbackHandle);

            this.Platform_SetClipboardTextFn = &SetClipboardTextWrapper;
            this.Platform_ClipboardUserData = (void*)GCHandle.ToIntPtr(CallbackHandle.Handle.Value);

            [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
            static unsafe void SetClipboardTextWrapper(nint ctx, nint path)
            {
                ImGuiContextStruct* context = (ImGuiContextStruct*)ctx;
                var io = ImGuiMethods.GetPlatformIO();

                var handle = GCHandle.FromIntPtr((nint)io->Platform_ClipboardUserData);
                var callback = (Callbacks)handle.Target!;

                ReadOnlySpan<byte> pathSpan = MemoryMarshal.CreateReadOnlySpanFromNullTerminated((byte*)path);
                callback.SetClipboardText!(new ImGuiContext(context), pathSpan);
            }
        }

        public void AddGetClipboardTextCallback(GetClipboardTextDelegate callback)
        {
            CallbackHandle.GetClipboardText = callback;
            CallbackHandle.Handle ??= GCHandle.Alloc(CallbackHandle);

            this.Platform_GetClipboardTextFn = &GetClipboardTextWrapper;
            this.Platform_ClipboardUserData = (void*)GCHandle.ToIntPtr(CallbackHandle.Handle.Value);

            [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
            static unsafe nint GetClipboardTextWrapper(nint ctx)
            {
                ImGuiContextStruct* context = (ImGuiContextStruct*)ctx;
                var io = ImGuiMethods.GetPlatformIO();

                var handle = GCHandle.FromIntPtr((nint)io->Platform_ClipboardUserData);
                var callback = (Callbacks)handle.Target!;

                string? str = callback.GetClipboardText!(new ImGuiContext(context));
                byte[] strBuffer = new byte[Encoding.UTF8.GetByteCount(str ?? string.Empty) + 1];
                Encoding.UTF8.GetBytes(str, strBuffer);

                if (callback.ClipboardTextPtr != nint.Zero)
                    Marshal.FreeHGlobal(callback.ClipboardTextPtr);

                callback.ClipboardTextPtr = Marshal.AllocHGlobal(strBuffer.Length);
                Marshal.Copy(strBuffer, 0, callback.ClipboardTextPtr, strBuffer.Length);

                return callback.ClipboardTextPtr;
            }
        }

        public static void DisposeHandles()
        {
            CallbackHandle.Handle?.Free();
            CallbackHandle.Handle = null;

            if (CallbackHandle.ClipboardTextPtr != nint.Zero)
            {
                Marshal.FreeHGlobal(CallbackHandle.ClipboardTextPtr);
                CallbackHandle.ClipboardTextPtr = nint.Zero;
            }
        }
    }
}
