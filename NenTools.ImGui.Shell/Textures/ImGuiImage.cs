using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NenTools.ImGui.Interfaces.Shell.Textures;

namespace NenTools.ImGui.Shell.Textures;

public class ImGuiImage : IImGuiImage
{
    public ulong TexId { get; set; }
    public uint Width { get; set; }
    public uint Height { get; set; }

    internal IImGuiTextureManager TextureManager { get; set; }
    internal bool Disposed { get; set; }

    public ImGuiImage(IImGuiTextureManager textureManager, ulong texId, uint width, uint height)
    {
        TextureManager = textureManager;

        TexId = texId;
        Width = width;
        Height = height;
    }

    public void Dispose()
    {
        TextureManager.FreeImage(this);
    }
}
