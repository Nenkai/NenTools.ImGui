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
    public bool InputScalar(string label, ref byte p_data) =>
        ImGuiMethods.InputScalar(label, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data));
    public bool InputScalar(ReadOnlySpan<byte> label, ref byte p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data));
    }

    public bool InputScalar(string label, ref sbyte p_data) =>
        ImGuiMethods.InputScalar(label, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data));
    public bool InputScalar(ReadOnlySpan<byte> label, ref sbyte p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data));
    }

    public bool InputScalar(string label, ref ushort p_data) =>
        ImGuiMethods.InputScalar(label, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data));
    public bool InputScalar(ReadOnlySpan<byte> label, ref ushort p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data));
    }

    public bool InputScalar(string label, ref short p_data) =>
        ImGuiMethods.InputScalar(label, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data));
    public bool InputScalar(ReadOnlySpan<byte> label, ref short p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data));
    }

    public bool InputScalar(string label, ref uint p_data) =>
        ImGuiMethods.InputScalar(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data));
    public bool InputScalar(ReadOnlySpan<byte> label, ref uint p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data));
    }


    public bool InputScalar(string label, ref int p_data) =>
        ImGuiMethods.InputScalar(label, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data));
    public bool InputScalar(ReadOnlySpan<byte> label, ref int p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data));
    }

    public bool InputScalar(string label, ref ulong p_data) =>
        ImGuiMethods.InputScalar(label, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data));
    public bool InputScalar(ReadOnlySpan<byte> label, ref ulong p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data));
    }

    public bool InputScalar(string label, ref long p_data) =>
        ImGuiMethods.InputScalar(label, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data));
    public bool InputScalar(ReadOnlySpan<byte> label, ref long p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data));
    }

    public bool InputScalar(string label, ref float p_data) =>
        ImGuiMethods.InputScalar(label, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data));
    public bool InputScalar(ReadOnlySpan<byte> label, ref float p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data));
    }

    public bool InputScalar(string label, ref double p_data) =>
        ImGuiMethods.InputScalar(label, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data));
    public bool InputScalar(ReadOnlySpan<byte> label, ref double p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalar((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data));
    }



    public bool InputScalarN(string label, ref byte p_data, int components) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), components);
    public bool InputScalarN(ReadOnlySpan<byte> label, ref byte p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), components);
    }

    public bool InputScalarN(string label, ref sbyte p_data, int components) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), components);
    public bool InputScalarN(ReadOnlySpan<byte> label, ref sbyte p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), components);
    }

    public bool InputScalarN(string label, ref ushort p_data, int components) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), components);
    public bool InputScalarN(ReadOnlySpan<byte> label, ref ushort p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), components);
    }

    public bool InputScalarN(string label, ref short p_data, int components) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), components);
    public bool InputScalarN(ReadOnlySpan<byte> label, ref short p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), components);
    }

    public bool InputScalarN(string label, ref uint p_data, int components) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), components);
    public bool InputScalarN(ReadOnlySpan<byte> label, ref uint p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), components);
    }


    public bool InputScalarN(string label, ref int p_data, int components) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), components);
    public bool InputScalarN(ReadOnlySpan<byte> label, ref int p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), components);
    }

    public bool InputScalarN(string label, ref ulong p_data, int components) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), components);
    public bool InputScalarN(ReadOnlySpan<byte> label, ref ulong p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), components);
    }

    public bool InputScalarN(string label, ref long p_data, int components) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), components);
    public bool InputScalarN(ReadOnlySpan<byte> label, ref long p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), components);
    }

    public bool InputScalarN(string label, ref float p_data, int components) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), components);
    public bool InputScalarN(ReadOnlySpan<byte> label, ref float p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), components);
    }

    public bool InputScalarN(string label, ref double p_data, int components) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), components);
    public bool InputScalarN(ReadOnlySpan<byte> label, ref double p_data, int components)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), components);
    }



    public bool InputScalarN(string label, Span<byte> p_data) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_U8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<byte> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool InputScalarN(string label, Span<sbyte> p_data) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_S8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<sbyte> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool InputScalarN(string label, Span<ushort> p_data) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_U16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<ushort> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool InputScalarN(string label, Span<short> p_data) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_S16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<short> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool InputScalarN(string label, Span<uint> p_data) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_U32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<uint> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }


    public bool InputScalarN(string label, Span<int> p_data) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_S32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<int> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool InputScalarN(string label, Span<ulong> p_data) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_U64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<ulong> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool InputScalarN(string label, Span<long> p_data) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_S64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<long> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool InputScalarN(string label, Span<float> p_data) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_Float, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<float> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }

    public bool InputScalarN(string label, Span<double> p_data) =>
        ImGuiMethods.InputScalarN(label, (int)ImGuiDataType.ImGuiDataType_Double, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<double> p_data)
    {
        fixed (byte* pLabel = label)
            return ImGuiMethods.InputScalarN((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length);
    }




    public bool InputScalarEx(string label, ref byte p_data, ref byte p_step, ref byte p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref byte p_data, ref byte p_step, ref byte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref sbyte p_data, ref sbyte p_step, ref sbyte p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref sbyte p_data, ref sbyte p_step, ref sbyte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref ushort p_data, ref ushort p_step, ref ushort p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref ushort p_data, ref ushort p_step, ref ushort p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref short p_data, ref short p_step, ref short p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref short p_data, ref short p_step, ref short p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref uint p_data, ref uint p_step, ref uint p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref uint p_data, ref uint p_step, ref uint p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref int p_data, ref int p_step, ref int p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref int p_data, ref int p_step, ref int p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref ulong p_data, ref ulong p_step, ref ulong p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref ulong p_data, ref ulong p_step, ref ulong p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref long p_data, ref long p_step, ref long p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref long p_data, ref long p_step, ref long p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref float p_data, ref float p_step, ref float p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref float p_data, ref float p_step, ref float p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarEx(string label, ref double p_data, ref double p_step, ref double p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarEx(label, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref double p_data, ref double p_step, ref double p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }




    public bool InputScalarNEx(string label, ref byte p_data, int components, ref byte p_step, ref byte p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref byte p_data, int components, ref byte p_step, ref byte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, ref sbyte p_data, int components, ref sbyte p_step, ref sbyte p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref sbyte p_data, int components, ref sbyte p_step, ref sbyte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, ref ushort p_data, int components, ref ushort p_step, ref ushort p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref ushort p_data, int components, ref ushort p_step, ref ushort p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, ref short p_data, int components, ref short p_step, ref short p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref short p_data, int components, ref short p_step, ref short p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, ref uint p_data, int components, ref uint p_step, ref uint p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref uint p_data, int components, ref uint p_step, ref uint p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, ref int p_data, int components, ref int p_step, ref int p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref int p_data, int components, ref int p_step, ref int p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, ref ulong p_data, int components, ref ulong p_step, ref ulong p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref ulong p_data, int components, ref ulong p_step, ref ulong p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, ref long p_data, int components, ref long p_step, ref long p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref long p_data, int components, ref long p_step, ref long p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, ref float p_data, int components, ref float p_step, ref float p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref float p_data, int components, ref float p_step, ref float p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, ref double p_data, int components, ref double p_step, ref double p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref double p_data, int components, ref double p_step, ref double p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, Unsafe.AsPointer(ref p_data), components, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }





    public bool InputScalarNEx(string label, Span<byte> p_data, ref byte p_step, ref byte p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<byte> p_data, ref byte p_step, ref byte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, Span<sbyte> p_data, ref sbyte p_step, ref sbyte p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<sbyte> p_data, ref sbyte p_step, ref sbyte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S8, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, Span<ushort> p_data, ref ushort p_step, ref ushort p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<ushort> p_data, ref ushort p_step, ref ushort p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, Span<short> p_data, ref short p_step, ref short p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<short> p_data, ref short p_step, ref short p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S16, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, Span<uint> p_data, ref uint p_step, ref uint p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<uint> p_data, ref uint p_step, ref uint p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, Span<int> p_data, ref int p_step, ref int p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<int> p_data, ref int p_step, ref int p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S32, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, Span<ulong> p_data, ref ulong p_step, ref ulong p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_U64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<ulong> p_data, ref ulong p_step, ref ulong p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_U64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, Span<long> p_data, ref long p_step, ref long p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_S64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<long> p_data, ref long p_step, ref long p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_S64, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, Span<float> p_data, ref float p_step, ref float p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_Float, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<float> p_data, ref float p_step, ref float p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Float, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }

    public bool InputScalarNEx(string label, Span<double> p_data, ref double p_step, ref double p_step_fast, string format, ImGuiInputTextFlags flags = 0) =>
        ImGuiMethods.InputScalarNEx(label, (int)ImGuiDataType.ImGuiDataType_Double, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), format, (int)flags);
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<double> p_data, ref double p_step, ref double p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0)
    {
        fixed (byte* pLabel = label)
        fixed (byte* pFormat = format)
            return ImGuiMethods.InputScalarNEx((sbyte*)pLabel, (int)ImGuiDataType.ImGuiDataType_Double, !p_data.IsEmpty ? Unsafe.AsPointer(ref MemoryMarshal.GetReference(p_data)) : null, p_data.Length, Unsafe.AsPointer(ref p_step), Unsafe.AsPointer(ref p_step_fast), (sbyte*)pFormat, (int)flags);
    }
}
