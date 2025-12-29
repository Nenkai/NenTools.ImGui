using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32.SafeHandles;

using Vortice.Direct3D12;
using Windows.Win32;

#pragma warning disable CA1416 // This call site is reachable on all platforms. (method) is only supported on: 'windows' 5.1.2600 and later.

namespace NenTools.ImGui.Hooks.DirectX12;

internal class CommandContext
{
    public ID3D12CommandAllocator CommandAllocator { get; set; }
    public ID3D12GraphicsCommandList CommandList { get; set; }
    public ID3D12Fence Fence { get; set; }
    private SafeFileHandle? FenceEvent { get; set; }
    public ulong FenceValue { get; set; }
    public bool WaitingForFence { get; set; }
    public Lock Lock { get; private set; } = new();
    public bool HasCommands = false;

    public bool Setup(DX12BackendHook hook)
    {
        CommandAllocator?.Dispose();
        CommandList?.Dispose();
        Fence?.Dispose();

        var device = hook.Device;

        try
        {
            CommandAllocator = device.CreateCommandAllocator(CommandListType.Direct);
            CommandAllocator.Name = $"[{nameof(DX12BackendHook)}] ImGui Command Allocator";
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to create command allocator");
            return false;
        }

        try
        {
            CommandList = device.CreateCommandList<ID3D12GraphicsCommandList>(CommandListType.Direct, CommandAllocator);
            CommandList.Name = $"[{nameof(DX12BackendHook)}] ImGui CommandList";
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to create command list");
            return false;
        }

        try
        {
            Fence = device.CreateFence(FenceValue, FenceFlags.None);
            Fence.Name = $"[{nameof(DX12BackendHook)}] ImGui Command Context Fence";

            
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to create fence");
            return false;
        }

        try
        {
            FenceEvent = PInvoke.CreateEvent(null, false, false, (string)null);
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to create fence event");
            return false;
        }

        return true;
    }

    public void Wait(TimeSpan time)
    {
        lock (Lock)
        {
            if (FenceEvent is not null && WaitingForFence)
            {
                PInvoke.WaitForSingleObject(FenceEvent, (uint)time.TotalMilliseconds);
                PInvoke.ResetEvent(FenceEvent);
                WaitingForFence = false;
                CommandAllocator.Reset();
                CommandList.Reset(CommandAllocator, null);
                HasCommands = false;
            }
        }
    }

    public void Execute(ID3D12CommandQueue queue)
    {
        lock (Lock)
        {
            if (HasCommands)
            {
                CommandList.Close();
                queue.ExecuteCommandList(CommandList);
                queue.Signal(Fence, ++FenceValue);
                Fence.SetEventOnCompletion(FenceValue, FenceEvent.DangerousGetHandle());
                WaitingForFence = true;
                HasCommands = false;
            }
        }
    }

    public void Reset()
    {
        lock (Lock)
        {
            CommandAllocator?.Dispose();
            CommandList?.Dispose();
            Fence?.Dispose();
            FenceValue = 0;
            FenceEvent?.Dispose();
            FenceEvent = null;
            WaitingForFence = false;
        }
    }
}
