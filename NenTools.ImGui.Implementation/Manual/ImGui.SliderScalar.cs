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
    public bool SliderScalar(string label, ref sbyte p_data, ref sbyte p_min, ref sbyte p_max) =>
        ImGuiMethods.SliderScalar(label, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalar(ReadOnlySpan<byte> label, ref sbyte p_data, ref sbyte p_min, ref sbyte p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalar(string label, ref byte p_data, ref byte p_min, ref byte p_max) =>
        ImGuiMethods.SliderScalar(label, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalar(ReadOnlySpan<byte> label, ref byte p_data, ref byte p_min, ref byte p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalar(string label, ref short p_data, ref short p_min, ref short p_max) =>
        ImGuiMethods.SliderScalar(label, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalar(ReadOnlySpan<byte> label, ref short p_data, ref short p_min, ref short p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalar(string label, ref ushort p_data, ref ushort p_min, ref ushort p_max) =>
        ImGuiMethods.SliderScalar(label, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalar(ReadOnlySpan<byte> label, ref ushort p_data, ref ushort p_min, ref ushort p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalar(string label, ref int p_data, ref int p_min, ref int p_max) =>
        ImGuiMethods.SliderScalar(label, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalar(ReadOnlySpan<byte> label, ref int p_data, ref int p_min, ref int p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalar(string label, ref uint p_data, ref uint p_min, ref uint p_max) =>
        ImGuiMethods.SliderScalar(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalar(ReadOnlySpan<byte> label, ref uint p_data, ref uint p_min, ref uint p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalar(string label, ref ulong p_data, ref ulong p_min, ref ulong p_max) =>
        ImGuiMethods.SliderScalar(label, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalar(ReadOnlySpan<byte> label, ref ulong p_data, ref ulong p_min, ref ulong p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalar(string label, ref long p_data, ref long p_min, ref long p_max) =>
        ImGuiMethods.SliderScalar(label, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalar(ReadOnlySpan<byte> label, ref long p_data, ref long p_min, ref long p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalar(string label, ref float p_data, ref float p_min, ref float p_max) =>
        ImGuiMethods.SliderScalar(label, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalar(ReadOnlySpan<byte> label, ref float p_data, ref float p_min, ref float p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalar(string label, ref double p_data, ref double p_min, ref double p_max) =>
        ImGuiMethods.SliderScalar(label, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalar(ReadOnlySpan<byte> label, ref double p_data, ref double p_min, ref double p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }




    public bool SliderScalarN(string label, ref sbyte p_data, int components, ref sbyte p_min, ref sbyte p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, ref sbyte p_data, int components, ref sbyte p_min, ref sbyte p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, ref byte p_data, int components, ref byte p_min, ref byte p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, ref byte p_data, int components, ref byte p_min, ref byte p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, ref short p_data, int components, ref short p_min, ref short p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, ref short p_data, int components, ref short p_min, ref short p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, ref ushort p_data, int components, ref ushort p_min, ref ushort p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, ref ushort p_data, int components, ref ushort p_min, ref ushort p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, ref int p_data, int components, ref int p_min, ref int p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, ref int p_data, int components, ref int p_min, ref int p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }


    public bool SliderScalarN(string label, ref uint p_data, int components, ref uint p_min, ref uint p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, ref uint p_data, int components, ref uint p_min, ref uint p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, ref long p_data, int components, ref long p_min, ref long p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, ref long p_data, int components, ref long p_min, ref long p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, ref ulong p_data, int components, ref ulong p_min, ref ulong p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, ref ulong p_data, int components, ref ulong p_min, ref ulong p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, ref float p_data, int components, ref float p_min, ref float p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, ref float p_data, int components, ref float p_min, ref float p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, ref double p_data, int components, ref double p_min, ref double p_max) =>
       ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, ref double p_data, int components, ref double p_min, ref double p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }



    public bool SliderScalarN(string label, Span<sbyte> p_data, ref sbyte p_min, ref sbyte p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_S8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, Span<sbyte> p_data, ref sbyte p_min, ref sbyte p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, Span<byte> p_data, ref byte p_min, ref byte p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_U8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, Span<byte> p_data, ref byte p_min, ref byte p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, Span<short> p_data, ref short p_min, ref short p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_S16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, Span<short> p_data, ref short p_min, ref short p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, Span<ushort> p_data, ref ushort p_min, ref ushort p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_U16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, Span<ushort> p_data, ref ushort p_min, ref ushort p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, Span<int> p_data, ref int p_min, ref int p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_S32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, Span<int> p_data, ref int p_min, ref int p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }


    public bool SliderScalarN(string label, Span<uint> p_data, ref uint p_min, ref uint p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_U32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, Span<uint> p_data, ref uint p_min, ref uint p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, Span<long> p_data, ref long p_min, ref long p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_S64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, Span<long> p_data, ref long p_min, ref long p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, Span<ulong> p_data, ref ulong p_min, ref ulong p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_U64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, Span<ulong> p_data, ref ulong p_min, ref ulong p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, Span<float> p_data, ref float p_min, ref float p_max) =>
        ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_Float, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, Span<float> p_data, ref float p_min, ref float p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }

    public bool SliderScalarN(string label, Span<double> p_data, ref double p_min, ref double p_max) =>
       ImGuiMethods.SliderScalarN(label, (int)ImGuiDataType.ImGuiDataType_Double, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    public bool SliderScalarN(ReadOnlySpan<byte> label, Span<double> p_data, ref double p_min, ref double p_max)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.SliderScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max));
    }





    public bool SliderScalarEx(string label, ref sbyte p_data, ref sbyte p_min, ref sbyte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarEx(ReadOnlySpan<byte> label, ref sbyte p_data, ref sbyte p_min, ref sbyte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarEx(string label, ref byte p_data, ref byte p_min, ref byte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarEx(ReadOnlySpan<byte> label, ref byte p_data, ref byte p_min, ref byte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarEx(string label, ref short p_data, ref short p_min, ref short p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarEx(ReadOnlySpan<byte> label, ref short p_data, ref short p_min, ref short p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarEx(string label, ref ushort p_data, ref ushort p_min, ref ushort p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarEx(ReadOnlySpan<byte> label, ref ushort p_data, ref ushort p_min, ref ushort p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarEx(string label, ref int p_data, ref int p_min, ref int p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarEx(ReadOnlySpan<byte> label, ref int p_data, ref int p_min, ref int p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarEx(string label, ref uint p_data, ref uint p_min, ref uint p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarEx(ReadOnlySpan<byte> label, ref uint p_data, ref uint p_min, ref uint p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarEx(string label, ref ulong p_data, ref ulong p_min, ref ulong p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarEx(ReadOnlySpan<byte> label, ref ulong p_data, ref ulong p_min, ref ulong p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarEx(string label, ref long p_data, ref long p_min, ref long p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarEx(ReadOnlySpan<byte> label, ref long p_data, ref long p_min, ref long p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarEx(string label, ref float p_data, ref float p_min, ref float p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarEx(label, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarEx(ReadOnlySpan<byte> label, ref float p_data, ref float p_min, ref float p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarEx(string label, ref double p_data, ref double p_min, ref double p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarEx(label, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarEx(ReadOnlySpan<byte> label, ref double p_data, ref double p_min, ref double p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }




    public bool SliderScalarNEx(string label, ref sbyte p_data, int components, ref sbyte p_min, ref sbyte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, ref sbyte p_data, int components, ref sbyte p_min, ref sbyte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, ref byte p_data, int components, ref byte p_min, ref byte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, ref byte p_data, int components, ref byte p_min, ref byte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, ref short p_data, int components, ref short p_min, ref short p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, ref short p_data, int components, ref short p_min, ref short p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, ref ushort p_data, int components, ref ushort p_min, ref ushort p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, ref ushort p_data, int components, ref ushort p_min, ref ushort p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, ref int p_data, int components, ref int p_min, ref int p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, ref int p_data, int components, ref int p_min, ref int p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, ref uint p_data, int components, ref uint p_min, ref uint p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, ref uint p_data, int components, ref uint p_min, ref uint p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, ref ulong p_data, int components, ref ulong p_min, ref ulong p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, ref ulong p_data, int components, ref ulong p_min, ref ulong p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, ref long p_data, int components, ref long p_min, ref long p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, ref long p_data, int components, ref long p_min, ref long p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, ref float p_data, int components, ref float p_min, ref float p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, ref float p_data, int components, ref float p_min, ref float p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, ref double p_data, int components, ref double p_min, ref double p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, ref double p_data, int components, ref double p_min, ref double p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }



    public bool SliderScalarNEx(string label, Span<sbyte> p_data, ref sbyte p_min, ref sbyte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, Span<sbyte> p_data, ref sbyte p_min, ref sbyte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, Span<byte> p_data, ref byte p_min, ref byte p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, Span<byte> p_data, ref byte p_min, ref byte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, Span<short> p_data, ref short p_min, ref short p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, Span<short> p_data, ref short p_min, ref short p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, Span<ushort> p_data, ref ushort p_min, ref ushort p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, Span<ushort> p_data, ref ushort p_min, ref ushort p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, Span<int> p_data, ref int p_min, ref int p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, Span<int> p_data, ref int p_min, ref int p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, Span<uint> p_data, ref uint p_min, ref uint p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, Span<uint> p_data, ref uint p_min, ref uint p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, Span<ulong> p_data, ref ulong p_min, ref ulong p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, Span<ulong> p_data, ref ulong p_min, ref ulong p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, Span<long> p_data, ref long p_min, ref long p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, Span<long> p_data, ref long p_min, ref long p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, Span<float> p_data, ref float p_min, ref float p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_Float, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, Span<float> p_data, ref float p_min, ref float p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }

    public bool SliderScalarNEx(string label, Span<double> p_data, ref double p_min, ref double p_max, string format, ImGuiSliderFlags flags = 0) =>
        ImGuiMethods.SliderScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_Double, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), format, (int)flags);
    public bool SliderScalarNEx(ReadOnlySpan<byte> label, Span<double> p_data, ref double p_min, ref double p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.SliderScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_min), Unsafe.AsPointer(ref p_max), (sbyte*)pFormat, (int)flags);
    }
}
