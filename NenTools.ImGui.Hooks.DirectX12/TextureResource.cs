using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vortice.Direct3D12;

namespace NenTools.ImGui.Hooks.DirectX12;

public class TextureResource : IDisposable
{
    public required ID3D12Resource Resource { get; set; }
    public required CpuDescriptorHandle CpuDescHandle { get; set; }
    public required GpuDescriptorHandle GpuDescHandle { get; set; }

    public void Dispose()
    {
        ((IDisposable)Resource).Dispose();
        GC.SuppressFinalize(this);
    }
}
