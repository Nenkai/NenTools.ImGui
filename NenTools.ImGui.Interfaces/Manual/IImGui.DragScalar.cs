using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

// DragScalar, manually implemented to add overloads for each C# numeric data type.
public unsafe partial interface IImGui
{
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(string label, ref byte p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(ReadOnlySpan<byte> label, ref byte p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(string label, ref sbyte p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(ReadOnlySpan<byte> label, ref sbyte p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(string label, ref ushort p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(ReadOnlySpan<byte> label, ref ushort p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(string label, ref short p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(ReadOnlySpan<byte> label, ref short p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(string label, ref uint p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(ReadOnlySpan<byte> label, ref uint p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(string label, ref int p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(ReadOnlySpan<byte> label, ref int p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(string label, ref ulong p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(ReadOnlySpan<byte> label, ref ulong p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(string label, ref long p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(ReadOnlySpan<byte> label, ref long p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(string label, ref float p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(ReadOnlySpan<byte> label, ref float p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(string label, ref double p_data);
    /// <inheritdoc cref="DragScalar(string, ImGuiDataType, void*)"/>
    public bool DragScalar(ReadOnlySpan<byte> label, ref double p_data);

    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, ref byte p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, ref byte p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, ref sbyte p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, ref sbyte p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, ref ushort p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, ref ushort p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, ref short p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, ref short p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, ref uint p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, ref uint p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, ref int p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, ref int p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, ref ulong p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, ref ulong p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, ref long p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, ref long p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, ref float p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, ref float p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, ref double p_data, int components);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, ref double p_data, int components);

    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, Span<byte> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<byte> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, Span<sbyte> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<sbyte> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, Span<ushort> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<ushort> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, Span<short> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<short> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, Span<uint> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<uint> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, Span<int> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<int> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, Span<ulong> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<ulong> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, Span<long> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<long> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, Span<float> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<float> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(string label, Span<double> p_data);
    /// <inheritdoc cref="DragScalarN(string, ImGuiDataType, void*, int)"/>
    public bool DragScalarN(ReadOnlySpan<byte> label, Span<double> p_data);

    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(string label, ref sbyte p_data, float v_speed, ref sbyte p_min, ref sbyte p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref sbyte p_data, float v_speed, ref sbyte p_min, ref sbyte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(string label, ref byte p_data, float v_speed, ref byte p_min, ref byte p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref byte p_data, float v_speed, ref byte p_min, ref byte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(string label, ref short p_data, float v_speed, ref short p_min, ref short p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref short p_data, float v_speed, ref short p_min, ref short p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(string label, ref ushort p_data, float v_speed, ref ushort p_min, ref ushort p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref ushort p_data, float v_speed, ref ushort p_min, ref ushort p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(string label, ref int p_data, float v_speed, ref int p_min, ref int p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref int p_data, float v_speed, ref int p_min, ref int p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(string label, ref uint p_data, float v_speed, ref uint p_min, ref uint p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref uint p_data, float v_speed, ref uint p_min, ref uint p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(string label, ref long p_data, float v_speed, ref long p_min, ref long p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref long p_data, float v_speed, ref long p_min, ref long p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(string label, ref ulong p_data, float v_speed, ref ulong p_min, ref ulong p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref ulong p_data, float v_speed, ref ulong p_min, ref ulong p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(string label, ref float p_data, float v_speed, ref float p_min, ref float p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref float p_data, float v_speed, ref float p_min, ref float p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(string label, ref double p_data, float v_speed, ref double p_min, ref double p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarEx(string, ImGuiDataType, void*, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarEx(ReadOnlySpan<byte> label, ref double p_data, float v_speed, ref double p_min, ref double p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);

    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, ref sbyte p_data, int components, float v_speed, ref sbyte p_min, ref sbyte p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref sbyte p_data, int components, float v_speed, ref sbyte p_min, ref sbyte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, ref byte p_data, int components, float v_speed, ref byte p_min, ref byte p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref byte p_data, int components, float v_speed, ref byte p_min, ref byte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, ref short p_data, int components, float v_speed, ref short p_min, ref short p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref short p_data, int components, float v_speed, ref short p_min, ref short p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, ref ushort p_data, int components, float v_speed, ref ushort p_min, ref ushort p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref ushort p_data, int components, float v_speed, ref ushort p_min, ref ushort p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, ref int p_data, int components, float v_speed, ref int p_min, ref int p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref int p_data, int components, float v_speed, ref int p_min, ref int p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, ref uint p_data, int components, float v_speed, ref uint p_min, ref uint p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref uint p_data, int components, float v_speed, ref uint p_min, ref uint p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, ref long p_data, int components, float v_speed, ref long p_min, ref long p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref long p_data, int components, float v_speed, ref long p_min, ref long p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, ref ulong p_data, int components, float v_speed, ref ulong p_min, ref ulong p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref ulong p_data, int components, float v_speed, ref ulong p_min, ref ulong p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, ref float p_data, int components, float v_speed, ref float p_min, ref float p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref float p_data, int components, float v_speed, ref float p_min, ref float p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, ref double p_data, int components, float v_speed, ref double p_min, ref double p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, ref double p_data, int components, float v_speed, ref double p_min, ref double p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);

    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, Span<sbyte> p_data, float v_speed, ref sbyte p_min, ref sbyte p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<sbyte> p_data, float v_speed, ref sbyte p_min, ref sbyte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, Span<byte> p_data, float v_speed, ref byte p_min, ref byte p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<byte> p_data, float v_speed, ref byte p_min, ref byte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, Span<short> p_data, float v_speed, ref short p_min, ref short p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<short> p_data, float v_speed, ref short p_min, ref short p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, Span<ushort> p_data, float v_speed, ref ushort p_min, ref ushort p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<ushort> p_data, float v_speed, ref ushort p_min, ref ushort p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, Span<int> p_data, float v_speed, ref int p_min, ref int p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<int> p_data, float v_speed, ref int p_min, ref int p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, Span<uint> p_data, float v_speed, ref uint p_min, ref uint p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<uint> p_data, float v_speed, ref uint p_min, ref uint p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, Span<long> p_data, float v_speed, ref long p_min, ref long p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<long> p_data, float v_speed, ref long p_min, ref long p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, Span<ulong> p_data, float v_speed, ref ulong p_min, ref ulong p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<ulong> p_data, float v_speed, ref ulong p_min, ref ulong p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, Span<float> p_data, float v_speed, ref float p_min, ref float p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<float> p_data, float v_speed, ref float p_min, ref float p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(string label, Span<double> p_data, float v_speed, ref double p_min, ref double p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="DragScalarNEx(string, ImGuiDataType, void*, int, float, void*, void*, string, ImGuiSliderFlags)"/>
    public bool DragScalarNEx(ReadOnlySpan<byte> label, Span<double> p_data, float v_speed, ref double p_min, ref double p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
}