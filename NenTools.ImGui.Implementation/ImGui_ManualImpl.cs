using NenTools.ImGui.Interfaces;
using NenTools.ImGui.Native;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using static NenTools.ImGui.Interfaces.IImGuiPlatformIO;

namespace NenTools.ImGui.Implementation;

// Manually implemented imgui implementations, for the interface.
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

    /// <summary>
    /// This is needed as AddFontFromFileTTF has sanity checks (and will assert/error if some properties are off for a default structure) <br/>
    /// Refer to ImFontConfig constructor - https://github.com/ocornut/imgui/blob/842837e35b421a4c85ca30f6840321f0a3c5a029/imgui_draw.cpp#L2404
    /// </summary>
    /// <returns></returns>
    public IDisposableHandle<IImFontConfig> CreateFontConfig()
    {
        // create the concrete struct
        var handle = new DisposableHandle<IImFontConfig>(new ImFontConfig(), Unsafe.SizeOf<ImFontConfigStruct>());
        var config = handle.Value;
        config.FontDataOwnedByAtlas = true;
        config.OversampleH = 0;
        config.OversampleV = 0;
        config.GlyphMaxAdvanceX = float.MaxValue;
        config.RasterizerMultiply = 1.0f;
        config.RasterizerDensity = 1.0f;
        config.EllipsisChar = 0;
        return handle;
    }

    // Part of api, implemented manually.
    public void ImGuiTextFilter_ImGuiTextRange_split(IImGuiTextFilter_ImGuiTextRange self, sbyte separator, out IImVectorWrapper<IImGuiTextFilter_ImGuiTextRange> @out)
    {
        var vec = new ImVector<ImGuiTextFilter_ImGuiTextRangeStruct>();
        ImGuiMethods.ImGuiTextFilter_ImGuiTextRange_split(self is not null ? (ImGuiTextFilter_ImGuiTextRangeStruct*)self.NativePointer : null, separator, ref vec);
        @out = new ImVectorWrapper<IImGuiTextFilter_ImGuiTextRange>(vec.Size, vec.Capacity, vec.Data, 
            Unsafe.SizeOf<ImGuiTextFilter_ImGuiTextRangeStruct>(), (addr) => new ImGuiTextFilter_ImGuiTextRange((ImGuiTextFilter_ImGuiTextRangeStruct*)addr));
    }

    public void ImFontGlyphRangesBuilder_BuildRanges(IImFontGlyphRangesBuilder self, out IImVectorWrapper<uint> out_ranges)
    {
        var vec = new ImVector<uint>();
        ImGuiMethods.ImFontGlyphRangesBuilder_BuildRanges(self is not null ? (ImFontGlyphRangesBuilderStruct*)self.NativePointer : null, ref vec);
        out_ranges = new ImVectorWrapper<uint>(vec.Size, vec.Capacity, vec.Data, sizeof(uint), (addr) => *(uint*)addr);
    }

    /// <summary>
    /// Used to dispose of unmanaged resources (mainly unmanaged pointers from callbacks).
    /// </summary>
    public void DisposeCallbackHandles()
    {
        ImGuiPlatformIO.DisposeHandles();
    }

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

                string str = callback.GetClipboardText!(new ImGuiContext(context));
                byte[] strBuffer = new byte[Encoding.UTF8.GetByteCount(str) + 1];
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