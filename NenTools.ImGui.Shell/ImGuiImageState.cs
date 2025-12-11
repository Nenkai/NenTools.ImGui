using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NenTools.ImGui.Abstractions;

namespace NenTools.ImGui.Shell;

public class ImGuiImageState : IQueuedImGuiImage
{
    public bool IsLoaded { get; set; }
    public IImGuiImage? Image { get; set; }

    public void Dispose()
    {
         Image?.Dispose();
    }
}
