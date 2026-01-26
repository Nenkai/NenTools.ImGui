using NenTools.ImGui.Interfaces;
using NenTools.ImGui.Native;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

    public IDisposableHandle<IImGuiTextFilter> CreateTextFilter(string defaultFilter = "")
    {
        var handle = new DisposableHandle<IImGuiTextFilter>(new ImGuiTextFilter(), Unsafe.SizeOf<ImGuiTextFilterStruct>());
        var filter = handle.Value;
        filter.InputBuf[0] = 0;
        filter.CountGrep = 0;

        if (!string.IsNullOrEmpty(defaultFilter))
        {
            byte[] bytes = Encoding.UTF8.GetBytes(defaultFilter);
            if (bytes.Length >= filter.InputBuf.Count)
                throw new ArgumentOutOfRangeException($"Default filter cannot be longer than {filter.InputBuf.Count}");

            fixed (byte* strPtr = bytes)
                NativeMemory.Copy(strPtr, filter.InputBuf.Data, (nuint)bytes.Length);
            ImGuiTextFilter_Build(filter);
        }

        return handle;
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


    /// <summary>
    /// Used to dispose of unmanaged resources (mainly unmanaged pointers from callbacks).
    /// </summary>
    public void DisposeCallbackHandles()
    {
        ImGuiPlatformIO.DisposeHandles();
    }

    // Part of api, implemented manually.

    // These exists so that we can pass null to p_open.
    public bool Begin(string name, ImGuiWindowFlags flags) => ImGuiMethods.Begin(name, null, (int)flags);
    public bool Begin(ReadOnlySpan<byte> name, ImGuiWindowFlags flags) => ImGuiMethods.Begin((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(name)), null, (int)flags);

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

    #region Combo overloads
    public bool Combo(string label, ref byte value, string items_separated_by_zeros)
    {
        var valueAsInt = (int)value;
        var changed = ImGuiMethods.Combo(label, ref valueAsInt, items_separated_by_zeros);
        if (changed)
        {
            value = (byte)(valueAsInt & 0xff);
        }
        return changed;
    }

    public bool Combo(ReadOnlySpan<byte> label, ref byte value, ReadOnlySpan<byte> items_separated_by_zeros)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pItems = label)
        {
            var valueAsInt = (int)value;
            var changed = ImGuiMethods.Combo((sbyte*)pLabel, ref valueAsInt, (sbyte*)pItems);
            if (changed)
            {
                value = (byte)(valueAsInt & 0xffff); 
            }
            return changed;
        }
    }

    public bool Combo(string label, ref ushort value, string items_separated_by_zeros)
    {
        var valueAsInt = (int)value;
        var changed = ImGuiMethods.Combo(label, ref valueAsInt, items_separated_by_zeros);
        if (changed)
        {
            value = (ushort)(valueAsInt & 0xff);
        }
        return changed;
    }

    public bool Combo(ReadOnlySpan<byte> label, ref ushort value, ReadOnlySpan<byte> items_separated_by_zeros)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pItems = label)
        {
            var valueAsInt = (int)value;
            var changed = ImGuiMethods.Combo((sbyte*)pLabel, ref valueAsInt, (sbyte*)pItems);
            if (changed)
            {
                value = (ushort)(valueAsInt & 0xffff);
            }
            return changed;
        }
    }
    #endregion

    // Overload input functions such that buf & buf_size => single ReadOnlySpan argument
    #region InputText overloads
    public bool InputText(string label, Span<byte> buf, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputText(label, (sbyte*)pBuf, (nuint)buf.Length, (int)flags);
    }

    public bool InputText(ReadOnlySpan<byte> label, Span<byte> buf, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputText((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)pBuf, (nuint)buf.Length, (int)flags);
    }

    public bool InputTextEx(string label, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextEx(label, (sbyte*)pBuf, (nuint)buf.Length, (int)flags, callback, user_data);
    }

    public bool InputTextEx(ReadOnlySpan<byte> label, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextEx((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)pBuf, (nuint)buf.Length, (int)flags, callback, user_data);
    }

    public bool InputTextMultiline(string label, Span<byte> buf)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextMultiline(label, (sbyte*)pBuf, (nuint)buf.Length);
    }

    public bool InputTextMultiline(ReadOnlySpan<byte> label, Span<byte> buf)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextMultiline((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)pBuf, (nuint)buf.Length);
    }

    public bool InputTextMultilineEx(string label, Span<byte> buf, Vector2 size, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextMultilineEx(label, (sbyte*)pBuf, (nuint)buf.Length, size, (int)flags, callback, user_data);
    }

    public bool InputTextMultilineEx(ReadOnlySpan<byte> label, Span<byte> buf, Vector2 size, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextMultilineEx((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)pBuf, (nuint)buf.Length, size, (int)flags, callback, user_data);
    }

    public bool InputTextWithHint(string label, string hint, Span<byte> buf, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextWithHint(label, hint, (sbyte*)pBuf, (nuint)buf.Length, (int)flags);
    }

    public bool InputTextWithHint(ReadOnlySpan<byte> label, Span<byte> hint, Span<byte> buf, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextWithHint((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(hint)), (sbyte*)pBuf, (nuint)buf.Length, (int)flags);
    }

    public bool InputTextWithHintEx(string label, string hint, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextWithHintEx(label, hint, (sbyte*)pBuf, (nuint)buf.Length, (int)flags, callback, user_data);
    }

    public bool InputTextWithHintEx(ReadOnlySpan<byte> label, Span<byte> hint, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextWithHintEx((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(hint)), (sbyte*)pBuf, (nuint)buf.Length, (int)flags, callback, user_data);
    }

    public bool InputTextWithHint(ReadOnlySpan<byte> label, ReadOnlySpan<byte> hint, Span<byte> buf, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextWithHint((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(hint)), (sbyte*)pBuf, (nuint)buf.Length, (int)flags);
    }

    public unsafe bool InputTextWithHintEx(ReadOnlySpan<byte> label, ReadOnlySpan<byte> hint, Span<byte> buf, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<nint, int> callback, void* user_data)
    {
        fixed (byte* pBuf = buf) return ImGuiMethods.InputTextWithHintEx((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(label)), (sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(hint)), (sbyte*)pBuf, (nuint)buf.Length, (int)flags, callback, user_data);
    }
    #endregion

    #region InputFloat overloads
    public bool InputFloat2(string label, ref Vector2 v) => ImGuiMethods.InputFloat2(label, ref v);
    public bool InputFloat2(ReadOnlySpan<byte> label, ref Vector2 v)
    {
        fixed (byte* pBuf = label)
            return ImGuiMethods.InputFloat2((sbyte*)pBuf, ref v);
    }

    public bool InputFloat2Ex(string label, ref Vector2 v, string format, ImGuiInputTextFlags flags) => ImGuiMethods.InputFloat2Ex(label, ref v, format, (int)flags);
    public bool InputFloat2Ex(ReadOnlySpan<byte> label, ref Vector2 v, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputFloat2Ex((sbyte*)pBuf, ref v, (sbyte*)pFormat, (int)flags);
    }

    public bool InputFloat3(string label, ref Vector3 v) => ImGuiMethods.InputFloat3(label, ref v);
    public bool InputFloat3(ReadOnlySpan<byte> label, ref Vector3 v)
    {
        fixed (byte* pBuf = label)
            return ImGuiMethods.InputFloat3((sbyte*)pBuf, ref v);
    }

    public bool InputFloat3Ex(string label, ref Vector3 v, string format, ImGuiInputTextFlags flags) => ImGuiMethods.InputFloat3Ex(label, ref v, format, (int)flags);
    public bool InputFloat3Ex(ReadOnlySpan<byte> label, ref Vector3 v, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputFloat3Ex((sbyte*)pBuf, ref v, (sbyte*)pFormat, (int)flags);
    }

    public bool InputFloat4(string label, ref Vector4 v) => ImGuiMethods.InputFloat4(label, ref v);
    public bool InputFloat4(ReadOnlySpan<byte> label, ref Vector4 v)
    {
        fixed (byte* pBuf = label)
            return ImGuiMethods.InputFloat4((sbyte*)pBuf, ref v);
    }

    public bool InputFloat4Ex(string label, ref Vector4 v, string format, ImGuiInputTextFlags flags) => ImGuiMethods.InputFloat4Ex(label, ref v, format, (int)flags);
    public bool InputFloat4Ex(ReadOnlySpan<byte> label, ref Vector4 v, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pBuf = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputFloat4Ex((sbyte*)pBuf, ref v, (sbyte*)pFormat, (int)flags); 
    }
    #endregion

    #region Scalar overloads
    public bool InputScalarEx(string label, ref byte p_data, ref byte p_step, ref byte p_step_fast, string format, ImGuiInputTextFlags flags) => 
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref byte p_data, ref byte p_step, ref byte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref sbyte p_data, ref sbyte p_step, ref sbyte p_step_fast, string format, ImGuiInputTextFlags flags) => 
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref sbyte p_data, ref sbyte p_step, ref sbyte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref ushort p_data, ref ushort p_step, ref ushort p_step_fast, string format, ImGuiInputTextFlags flags) => 
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref ushort p_data, ref ushort p_step, ref ushort p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref short p_data, ref short p_step, ref short p_step_fast, string format, ImGuiInputTextFlags flags) => 
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref short p_data, ref short p_step, ref short p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref uint p_data, ref uint p_step, ref uint p_step_fast, string format, ImGuiInputTextFlags flags) => 
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref uint p_data, ref uint p_step, ref uint p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref int p_data, ref int p_step, ref int p_step_fast, string format, ImGuiInputTextFlags flags) => 
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref int p_data, ref int p_step, ref int p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref ulong p_data, ref ulong p_step, ref ulong p_step_fast, string format, ImGuiInputTextFlags flags) => 
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref ulong p_data, ref ulong p_step, ref ulong p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref long p_data, ref long p_step, ref long p_step_fast, string format, ImGuiInputTextFlags flags) => 
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref long p_data, ref long p_step, ref long p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step), (sbyte*)pFormat, (int)flags);
    }
    #endregion

    public bool BeginPopupModal(string name, ImGuiWindowFlags flags) => ImGuiMethods.BeginPopupModal(name, null, (int)flags);
    public bool BeginPopupModal(ReadOnlySpan<byte> name, ImGuiWindowFlags flags) => ImGuiMethods.BeginPopupModal((sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference<byte>(name)), null, (int)flags);

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