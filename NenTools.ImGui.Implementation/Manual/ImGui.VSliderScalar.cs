using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using NenTools.ImGui.Interfaces;
using NenTools.ImGui.Native;

namespace NenTools.ImGui.Implementation;

// Very boilerplatey way to handle mapping data type to c# types through overloads, but for performance reasons, we keep it that way.
public unsafe partial class ImGui : IImGui
{
    public bool VSliderScalar(string label, Vector2 size, ref sbyte p_data, ref sbyte p_min, ref sbyte p_max) =>
        ImGuiMethods.VSliderScalar(label, size, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref sbyte p_data, ref sbyte p_min, ref sbyte p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.VSliderScalar((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool VSliderScalar(string label, Vector2 size, ref byte p_data, ref byte p_min, ref byte p_max) =>
        ImGuiMethods.VSliderScalar(label, size, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref byte p_data, ref byte p_min, ref byte p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.VSliderScalar((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool VSliderScalar(string label, Vector2 size, ref short p_data, ref short p_min, ref short p_max) =>
        ImGuiMethods.VSliderScalar(label, size, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref short p_data, ref short p_min, ref short p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.VSliderScalar((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool VSliderScalar(string label, Vector2 size, ref ushort p_data, ref ushort p_min, ref ushort p_max) =>
        ImGuiMethods.VSliderScalar(label, size, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref ushort p_data, ref ushort p_min, ref ushort p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.VSliderScalar((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool VSliderScalar(string label, Vector2 size, ref int p_data, ref int p_min, ref int p_max) =>
        ImGuiMethods.VSliderScalar(label, size, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref int p_data, ref int p_min, ref int p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.VSliderScalar((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool VSliderScalar(string label, Vector2 size, ref uint p_data, ref uint p_min, ref uint p_max) =>
        ImGuiMethods.VSliderScalar(label, size, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref uint p_data, ref uint p_min, ref uint p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.VSliderScalar((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool VSliderScalar(string label, Vector2 size, ref ulong p_data, ref ulong p_min, ref ulong p_max) =>
        ImGuiMethods.VSliderScalar(label, size, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref ulong p_data, ref ulong p_min, ref ulong p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.VSliderScalar((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool VSliderScalar(string label, Vector2 size, ref long p_data, ref long p_min, ref long p_max) =>
        ImGuiMethods.VSliderScalar(label, size, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref long p_data, ref long p_min, ref long p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.VSliderScalar((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool VSliderScalar(string label, Vector2 size, ref float p_data, ref float p_min, ref float p_max) =>
        ImGuiMethods.VSliderScalar(label, size, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref float p_data, ref float p_min, ref float p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.VSliderScalar((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool VSliderScalar(string label, Vector2 size, ref double p_data, ref double p_min, ref double p_max) =>
        ImGuiMethods.VSliderScalar(label, size, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref double p_data, ref double p_min, ref double p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.VSliderScalar((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }




    public bool VSliderScalarEx(string label, Vector2 size, ref sbyte p_data, ref sbyte p_min, ref sbyte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.VSliderScalarEx(label, size, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref sbyte p_data, ref sbyte p_min, ref sbyte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.VSliderScalarEx((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool VSliderScalarEx(string label, Vector2 size, ref byte p_data, ref byte p_min, ref byte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.VSliderScalarEx(label, size, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref byte p_data, ref byte p_min, ref byte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.VSliderScalarEx((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool VSliderScalarEx(string label, Vector2 size, ref short p_data, ref short p_min, ref short p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.VSliderScalarEx(label, size, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref short p_data, ref short p_min, ref short p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.VSliderScalarEx((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool VSliderScalarEx(string label, Vector2 size, ref ushort p_data, ref ushort p_min, ref ushort p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.VSliderScalarEx(label, size, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref ushort p_data, ref ushort p_min, ref ushort p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.VSliderScalarEx((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool VSliderScalarEx(string label, Vector2 size, ref int p_data, ref int p_min, ref int p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.VSliderScalarEx(label, size, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref int p_data, ref int p_min, ref int p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.VSliderScalarEx((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool VSliderScalarEx(string label, Vector2 size, ref uint p_data, ref uint p_min, ref uint p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.VSliderScalarEx(label, size, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref uint p_data, ref uint p_min, ref uint p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.VSliderScalarEx((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool VSliderScalarEx(string label, Vector2 size, ref ulong p_data, ref ulong p_min, ref ulong p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.VSliderScalarEx(label, size, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref ulong p_data, ref ulong p_min, ref ulong p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.VSliderScalarEx((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool VSliderScalarEx(string label, Vector2 size, ref long p_data, ref long p_min, ref long p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.VSliderScalarEx(label, size, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref long p_data, ref long p_min, ref long p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.VSliderScalarEx((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool VSliderScalarEx(string label, Vector2 size, ref float p_data, ref float p_min, ref float p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.VSliderScalarEx(label, size, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref float p_data, ref float p_min, ref float p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.VSliderScalarEx((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool VSliderScalarEx(string label, Vector2 size, ref double p_data, ref double p_min, ref double p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.VSliderScalarEx(label, size, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref double p_data, ref double p_min, ref double p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.VSliderScalarEx((sbyte*)pLabel, size, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }
}
