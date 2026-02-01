using System;
using System.Collections.Generic;
using System.Linq;
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
    public bool DragScalar(string label, ref byte p_data) =>
        ImGuiMethods.DragScalar(label, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data));
    public bool DragScalar(ReadOnlySpan<byte> label, ref byte p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data));
    }

    public bool DragScalar(string label, ref sbyte p_data) =>
        ImGuiMethods.DragScalar(label, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data));
    public bool DragScalar(ReadOnlySpan<byte> label, ref sbyte p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data));
    }

    public bool DragScalar(string label, ref ushort p_data) =>
        ImGuiMethods.DragScalar(label, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data));
    public bool DragScalar(ReadOnlySpan<byte> label, ref ushort p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data));
    }

    public bool DragScalar(string label, ref short p_data) =>
        ImGuiMethods.DragScalar(label, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data));
    public bool DragScalar(ReadOnlySpan<byte> label, ref short p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data));
    }

    public bool DragScalar(string label, ref uint p_data) =>
        ImGuiMethods.DragScalar(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data));
    public bool DragScalar(ReadOnlySpan<byte> label, ref uint p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data));
    }


    public bool DragScalar(string label, ref int p_data) =>
        ImGuiMethods.DragScalar(label, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data));
    public bool DragScalar(ReadOnlySpan<byte> label, ref int p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data));
    }

    public bool DragScalar(string label, ref ulong p_data) =>
        ImGuiMethods.DragScalar(label, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data));
    public bool DragScalar(ReadOnlySpan<byte> label, ref ulong p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data));
    }

    public bool DragScalar(string label, ref long p_data) =>
        ImGuiMethods.DragScalar(label, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data));
    public bool DragScalar(ReadOnlySpan<byte> label, ref long p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data));
    }

    public bool DragScalar(string label, ref float p_data) =>
        ImGuiMethods.DragScalar(label, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data));
    public bool DragScalar(ReadOnlySpan<byte> label, ref float p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data));
    }

    public bool DragScalar(string label, ref double p_data) =>
        ImGuiMethods.DragScalar(label, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data));
    public bool DragScalar(ReadOnlySpan<byte> label, ref double p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data));
    }


    public bool DragScalarN(string label, ref byte p_data, int components) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), components);
    public bool DragScalarN(ReadOnlySpan<byte> label, ref byte p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), components);
    }

    public bool DragScalarN(string label, ref sbyte p_data, int components) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), components);
    public bool DragScalarN(ReadOnlySpan<byte> label, ref sbyte p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), components);
    }

    public bool DragScalarN(string label, ref ushort p_data, int components) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), components);
    public bool DragScalarN(ReadOnlySpan<byte> label, ref ushort p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), components);
    }

    public bool DragScalarN(string label, ref short p_data, int components) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), components);
    public bool DragScalarN(ReadOnlySpan<byte> label, ref short p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), components);
    }

    public bool DragScalarN(string label, ref uint p_data, int components) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), components);
    public bool DragScalarN(ReadOnlySpan<byte> label, ref uint p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), components);
    }


    public bool DragScalarN(string label, ref int p_data, int components) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), components);
    public bool DragScalarN(ReadOnlySpan<byte> label, ref int p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), components);
    }

    public bool DragScalarN(string label, ref ulong p_data, int components) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), components);
    public bool DragScalarN(ReadOnlySpan<byte> label, ref ulong p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), components);
    }

    public bool DragScalarN(string label, ref long p_data, int components) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), components);
    public bool DragScalarN(ReadOnlySpan<byte> label, ref long p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), components);
    }

    public bool DragScalarN(string label, ref float p_data, int components) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), components);
    public bool DragScalarN(ReadOnlySpan<byte> label, ref float p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), components);
    }

    public bool DragScalarN(string label, ref double p_data, int components) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), components);
    public bool DragScalarN(ReadOnlySpan<byte> label, ref double p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), components);
    }



    public bool DragScalarN(string label, Span<byte> p_data) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_U8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<byte> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool DragScalarN(string label, Span<sbyte> p_data) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_S8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<sbyte> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool DragScalarN(string label, Span<ushort> p_data) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_U16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<ushort> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool DragScalarN(string label, Span<short> p_data) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_S16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<short> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool DragScalarN(string label, Span<uint> p_data) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), p_data.Length);
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<uint> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }


    public bool DragScalarN(string label, Span<int> p_data) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_S32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<int> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool DragScalarN(string label, Span<ulong> p_data) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_U64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<ulong> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool DragScalarN(string label, Span<long> p_data) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_S64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<long> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool DragScalarN(string label, Span<float> p_data) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_Float, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<float> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool DragScalarN(string label, Span<double> p_data) =>
        ImGuiMethods.DragScalarN(label, (int)ImGuiDataType.ImGuiDataType_Double, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<double> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.DragScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }




    public bool DragScalarEx(string label, ref sbyte p_data, float v_speed, ref sbyte p_min, ref sbyte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref sbyte p_data, float v_speed, ref sbyte p_min, ref sbyte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarEx(string label, ref byte p_data, float v_speed, ref byte p_min, ref byte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref byte p_data, float v_speed, ref byte p_min, ref byte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarEx(string label, ref short p_data, float v_speed, ref short p_min, ref short p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref short p_data, float v_speed, ref short p_min, ref short p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarEx(string label, ref ushort p_data, float v_speed, ref ushort p_min, ref ushort p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref ushort p_data, float v_speed, ref ushort p_min, ref ushort p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarEx(string label, ref int p_data, float v_speed, ref int p_min, ref int p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref int p_data, float v_speed, ref int p_min, ref int p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarEx(string label, ref uint p_data, float v_speed, ref uint p_min, ref uint p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref uint p_data, float v_speed, ref uint p_min, ref uint p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarEx(string label, ref ulong p_data, float v_speed, ref ulong p_min, ref ulong p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref ulong p_data, float v_speed, ref ulong p_min, ref ulong p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarEx(string label, ref long p_data, float v_speed, ref long p_min, ref long p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref long p_data, float v_speed, ref long p_min, ref long p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarEx(string label, ref float p_data, float v_speed, ref float p_min, ref float p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarEx(label, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref float p_data, float v_speed, ref float p_min, ref float p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarEx(string label, ref double p_data, float v_speed, ref double p_min, ref double p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarEx(label, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref double p_data, float v_speed, ref double p_min, ref double p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }




    public bool DragScalarNEx(string label, ref sbyte p_data, int components, float v_speed, ref sbyte p_min, ref sbyte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref sbyte p_data, int components, float v_speed, ref sbyte p_min, ref sbyte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, ref byte p_data, int components, float v_speed, ref byte p_min, ref byte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref byte p_data, int components, float v_speed, ref byte p_min, ref byte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, ref short p_data, int components, float v_speed, ref short p_min, ref short p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref short p_data, int components, float v_speed, ref short p_min, ref short p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, ref ushort p_data, int components, float v_speed, ref ushort p_min, ref ushort p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref ushort p_data, int components, float v_speed, ref ushort p_min, ref ushort p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, ref int p_data, int components, float v_speed, ref int p_min, ref int p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref int p_data, int components, float v_speed, ref int p_min, ref int p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, ref uint p_data, int components, float v_speed, ref uint p_min, ref uint p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref uint p_data, int components, float v_speed, ref uint p_min, ref uint p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, ref ulong p_data, int components, float v_speed, ref ulong p_min, ref ulong p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref ulong p_data, int components, float v_speed, ref ulong p_min, ref ulong p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, ref long p_data, int components, float v_speed, ref long p_min, ref long p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref long p_data, int components, float v_speed, ref long p_min, ref long p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, ref float p_data, int components, float v_speed, ref float p_min, ref float p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref float p_data, int components, float v_speed, ref float p_min, ref float p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, ref double p_data, int components, float v_speed, ref double p_min, ref double p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref double p_data, int components, float v_speed, ref double p_min, ref double p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), components, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }





    public bool DragScalarNEx(string label, Span<sbyte> p_data, float v_speed, ref sbyte p_min, ref sbyte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<sbyte> p_data, float v_speed, ref sbyte p_min, ref sbyte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, Span<byte> p_data, float v_speed, ref byte p_min, ref byte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<byte> p_data, float v_speed, ref byte p_min, ref byte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, Span<short> p_data, float v_speed, ref short p_min, ref short p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<short> p_data, float v_speed, ref short p_min, ref short p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, Span<ushort> p_data, float v_speed, ref ushort p_min, ref ushort p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<ushort> p_data, float v_speed, ref ushort p_min, ref ushort p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, Span<int> p_data, float v_speed, ref int p_min, ref int p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<int> p_data, float v_speed, ref int p_min, ref int p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, Span<uint> p_data, float v_speed, ref uint p_min, ref uint p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<uint> p_data, float v_speed, ref uint p_min, ref uint p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, Span<ulong> p_data, float v_speed, ref ulong p_min, ref ulong p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<ulong> p_data, float v_speed, ref ulong p_min, ref ulong p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, Span<long> p_data, float v_speed, ref long p_min, ref long p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<long> p_data, float v_speed, ref long p_min, ref long p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, Span<float> p_data, float v_speed, ref float p_min, ref float p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_Float, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<float> p_data, float v_speed, ref float p_min, ref float p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool DragScalarNEx(string label, Span<double> p_data, float v_speed, ref double p_min, ref double p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.DragScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_Double, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<double> p_data, float v_speed, ref double p_min, ref double p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.DragScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, v_speed, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }
}
