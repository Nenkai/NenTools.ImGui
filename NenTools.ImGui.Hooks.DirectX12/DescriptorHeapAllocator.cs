using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Vortice.Direct3D12;

namespace NenTools.ImGui.Hooks.DirectX12;

// Taken from imgui examples
public class DescriptorHeapAllocator
{
    private ID3D12DescriptorHeap Heap;
    private DescriptorHeapType HeapType = DescriptorHeapType.Count;
    private CpuDescriptorHandle HeapStartCpu;
    private GpuDescriptorHandle HeapStartGpu;
    private uint HeapHandleIncrement;
    private Stack<int> FreeIndices = [];

    public void Create(ID3D12Device device, ID3D12DescriptorHeap heap)
    {
        ArgumentNullException.ThrowIfNull(device, nameof(device));
        ArgumentNullException.ThrowIfNull(heap, nameof(heap));

        Heap = heap;
        DescriptorHeapDescription desc = heap.Description;
        HeapType = desc.Type;
        HeapStartCpu = Heap.GetCPUDescriptorHandleForHeapStart();
        HeapStartGpu = Heap.GetGPUDescriptorHandleForHeapStart();
        HeapHandleIncrement = (uint)device.GetDescriptorHandleIncrementSize(HeapType);
        FreeIndices = new Stack<int>((int)desc.DescriptorCount);
        for (int n = (int)desc.DescriptorCount; n > 0; n--)
            FreeIndices.Push(n - 1);
    }

    public void Destroy()
    {
        Heap?.Dispose();
        FreeIndices.Clear();
    }

    public void Alloc(ref CpuDescriptorHandle outCpuDescHandle, ref GpuDescriptorHandle outGpuDescHandle)
    {
        long idx = FreeIndices.Peek();
        FreeIndices.Pop();
        outCpuDescHandle.Ptr = (nuint)(HeapStartCpu.Ptr + (ulong)idx * HeapHandleIncrement);
        outGpuDescHandle.Ptr = (nuint)(HeapStartGpu.Ptr + (ulong)idx * HeapHandleIncrement);
    }

    public void Free(CpuDescriptorHandle outCpuDescHandle, GpuDescriptorHandle outGpuDescHandle)
    {
        int cpuIdx = (int)((outCpuDescHandle.Ptr - HeapStartCpu.Ptr) / HeapHandleIncrement);
        int gpuIdx = (int)((outGpuDescHandle.Ptr - HeapStartGpu.Ptr) / HeapHandleIncrement);
        FreeIndices.Push(cpuIdx);
    }
};
