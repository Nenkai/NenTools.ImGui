using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NenTools.ImGui.Interfaces;

#pragma warning disable CS1591 // Missing XML comment

// VSliderScalar, manually implemented to add overloads for each C# numeric data type.
// VSliderScalarN has Span support.
public unsafe partial interface IImGui
{
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(string label, Vector2 size, ref sbyte p_data, ref sbyte p_min, ref sbyte p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref sbyte p_data, ref sbyte p_min, ref sbyte p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(string label, Vector2 size, ref byte p_data, ref byte p_min, ref byte p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref byte p_data, ref byte p_min, ref byte p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(string label, Vector2 size, ref short p_data, ref short p_min, ref short p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref short p_data, ref short p_min, ref short p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(string label, Vector2 size, ref ushort p_data, ref ushort p_min, ref ushort p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref ushort p_data, ref ushort p_min, ref ushort p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(string label, Vector2 size, ref int p_data, ref int p_min, ref int p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref int p_data, ref int p_min, ref int p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(string label, Vector2 size, ref uint p_data, ref uint p_min, ref uint p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref uint p_data, ref uint p_min, ref uint p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(string label, Vector2 size, ref long p_data, ref long p_min, ref long p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref long p_data, ref long p_min, ref long p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(string label, Vector2 size, ref ulong p_data, ref ulong p_min, ref ulong p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref ulong p_data, ref ulong p_min, ref ulong p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(string label, Vector2 size, ref float p_data, ref float p_min, ref float p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref float p_data, ref float p_min, ref float p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(string label, Vector2 size, ref double p_data, ref double p_min, ref double p_max);
    /// <inheritdoc cref="VSliderScalar(string, Vector2, ImGuiDataType, void*, void*, void*)"/>
    public bool VSliderScalar(ReadOnlySpan<byte> label, Vector2 size, ref double p_data, ref double p_min, ref double p_max);

    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(string label, Vector2 size, ref sbyte p_data, ref sbyte p_min, ref sbyte p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref sbyte p_data, ref sbyte p_min, ref sbyte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(string label, Vector2 size, ref byte p_data, ref byte p_min, ref byte p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref byte p_data, ref byte p_min, ref byte p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(string label, Vector2 size, ref short p_data, ref short p_min, ref short p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref short p_data, ref short p_min, ref short p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(string label, Vector2 size, ref ushort p_data, ref ushort p_min, ref ushort p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref ushort p_data, ref ushort p_min, ref ushort p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(string label, Vector2 size, ref int p_data, ref int p_min, ref int p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref int p_data, ref int p_min, ref int p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(string label, Vector2 size, ref uint p_data, ref uint p_min, ref uint p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref uint p_data, ref uint p_min, ref uint p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(string label, Vector2 size, ref long p_data, ref long p_min, ref long p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref long p_data, ref long p_min, ref long p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(string label, Vector2 size, ref ulong p_data, ref ulong p_min, ref ulong p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref ulong p_data, ref ulong p_min, ref ulong p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(string label, Vector2 size, ref float p_data, ref float p_min, ref float p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref float p_data, ref float p_min, ref float p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(string label, Vector2 size, ref double p_data, ref double p_min, ref double p_max, string format, ImGuiSliderFlags flags = 0);
    /// <inheritdoc cref="VSliderScalarEx(string, Vector2, ImGuiDataType, void*, void*, void*, string, ImGuiSliderFlags)"/>
    public bool VSliderScalarEx(ReadOnlySpan<byte> label, Vector2 size, ref double p_data, ref double p_min, ref double p_max, ReadOnlySpan<byte> format, ImGuiSliderFlags flags = 0);
}