using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NenTools.ImGui.Interfaces.Shell.Textures;

namespace NenTools.ImGui.Shell.Textures;

public class ImGuiImageState : IQueuedImGuiImage
{
    public bool IsLoaded { get; set; }
    public IImGuiImage? Image { get; set; }

    public void Dispose()
    {
         Image?.Dispose();
    }
}
