using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

// InputScalar, manually implemented to add overloads for each C# numeric data type.
public unsafe partial interface IImGui
{
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(string label, ref byte p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(ReadOnlySpan<byte> label, ref byte p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(string label, ref sbyte p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(ReadOnlySpan<byte> label, ref sbyte p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(string label, ref ushort p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(ReadOnlySpan<byte> label, ref ushort p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(string label, ref short p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(ReadOnlySpan<byte> label, ref short p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(string label, ref uint p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(ReadOnlySpan<byte> label, ref uint p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(string label, ref int p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(ReadOnlySpan<byte> label, ref int p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(string label, ref ulong p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(ReadOnlySpan<byte> label, ref ulong p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(string label, ref long p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(ReadOnlySpan<byte> label, ref long p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(string label, ref float p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(ReadOnlySpan<byte> label, ref float p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(string label, ref double p_data);
    /// <inheritdoc cref="InputScalar(ReadOnlySpan{byte}, ImGuiDataType, void*)"/>
    public bool InputScalar(ReadOnlySpan<byte> label, ref double p_data);

    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, ref byte p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, ref byte p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, ref sbyte p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, ref sbyte p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, ref ushort p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, ref ushort p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, ref short p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, ref short p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, ref uint p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, ref uint p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, ref int p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, ref int p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, ref ulong p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, ref ulong p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, ref long p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, ref long p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, ref float p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, ref float p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, ref double p_data, int components);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, ref double p_data, int components);

    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, Span<byte> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<byte> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, Span<sbyte> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<sbyte> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, Span<ushort> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<ushort> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, Span<short> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<short> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, Span<uint> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<uint> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, Span<int> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<int> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, Span<ulong> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<ulong> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, Span<long> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<long> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, Span<float> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<float> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(string label, Span<double> p_data);
    /// <inheritdoc cref="InputScalarN(string, ImGuiDataType, void*, int)"/>
    public bool InputScalarN(ReadOnlySpan<byte> label, Span<double> p_data);

    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(string label, ref byte p_data, ref byte p_step, ref byte p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref byte p_data, ref byte p_step, ref byte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(string label, ref sbyte p_data, ref sbyte p_step, ref sbyte p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref sbyte p_data, ref sbyte p_step, ref sbyte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(string label, ref ushort p_data, ref ushort p_step, ref ushort p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref ushort p_data, ref ushort p_step, ref ushort p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(string label, ref short p_data, ref short p_step, ref short p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref short p_data, ref short p_step, ref short p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(string label, ref uint p_data, ref uint p_step, ref uint p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref uint p_data, ref uint p_step, ref uint p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(string label, ref int p_data, ref int p_step, ref int p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref int p_data, ref int p_step, ref int p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(string label, ref ulong p_data, ref ulong p_step, ref ulong p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref ulong p_data, ref ulong p_step, ref ulong p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(string label, ref long p_data, ref long p_step, ref long p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref long p_data, ref long p_step, ref long p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(string label, ref float p_data, ref float p_step, ref float p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref float p_data, ref float p_step, ref float p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(string label, ref double p_data, ref double p_step, ref double p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarEx(string, ImGuiDataType, void*, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarEx(ReadOnlySpan<byte> label, ref double p_data, ref double p_step, ref double p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);

    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, ref byte p_data, int components, ref byte p_step, ref byte p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref byte p_data, int components, ref byte p_step, ref byte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, ref sbyte p_data, int components, ref sbyte p_step, ref sbyte p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref sbyte p_data, int components, ref sbyte p_step, ref sbyte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, ref ushort p_data, int components, ref ushort p_step, ref ushort p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref ushort p_data, int components, ref ushort p_step, ref ushort p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, ref short p_data, int components, ref short p_step, ref short p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref short p_data, int components, ref short p_step, ref short p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, ref uint p_data, int components, ref uint p_step, ref uint p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref uint p_data, int components, ref uint p_step, ref uint p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, ref int p_data, int components, ref int p_step, ref int p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref int p_data, int components, ref int p_step, ref int p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, ref ulong p_data, int components, ref ulong p_step, ref ulong p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref ulong p_data, int components, ref ulong p_step, ref ulong p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, ref long p_data, int components, ref long p_step, ref long p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref long p_data, int components, ref long p_step, ref long p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, ref float p_data, int components, ref float p_step, ref float p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref float p_data, int components, ref float p_step, ref float p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, ref double p_data, int components, ref double p_step, ref double p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, ref double p_data, int components, ref double p_step, ref double p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);

    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, Span<byte> p_data, ref byte p_step, ref byte p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<byte> p_data, ref byte p_step, ref byte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, Span<sbyte> p_data, ref sbyte p_step, ref sbyte p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<sbyte> p_data, ref sbyte p_step, ref sbyte p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, Span<ushort> p_data, ref ushort p_step, ref ushort p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<ushort> p_data, ref ushort p_step, ref ushort p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, Span<short> p_data, ref short p_step, ref short p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<short> p_data, ref short p_step, ref short p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, Span<uint> p_data, ref uint p_step, ref uint p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<uint> p_data, ref uint p_step, ref uint p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, Span<int> p_data, ref int p_step, ref int p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<int> p_data, ref int p_step, ref int p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, Span<ulong> p_data, ref ulong p_step, ref ulong p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<ulong> p_data, ref ulong p_step, ref ulong p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, Span<long> p_data, ref long p_step, ref long p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<long> p_data, ref long p_step, ref long p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, Span<float> p_data, ref float p_step, ref float p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<float> p_data, ref float p_step, ref float p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(string label, Span<double> p_data, ref double p_step, ref double p_step_fast, string format, ImGuiInputTextFlags flags = 0);
    /// <inheritdoc cref="InputScalarNEx(string, ImGuiDataType, void*, int, void*, void*, string, ImGuiInputTextFlags)"/>
    public bool InputScalarNEx(ReadOnlySpan<byte> label, Span<double> p_data, ref double p_step, ref double p_step_fast, ReadOnlySpan<byte> format, ImGuiInputTextFlags flags = 0);
}