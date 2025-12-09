using System;

namespace NenTools.ImGui.Hooks;

public interface IImguiHook : IDisposable
{
    /// <summary>
    /// True if the API is supported for the current process.
    /// </summary>
    bool IsApiSupported();

    /// <summary>
    /// Initializes the hooks specific to this graphics API.
    /// </summary>
    void InitAndEnableHooks();

    /// <summary>
    /// Disables the hooks used by this implementation.
    /// </summary>
    void DisableHooks();

    /// <summary>
    /// Re-enables the hooks used by this implementation.
    /// </summary>
    void EnableHooks();

    /// <summary>
    /// Loads an image.
    /// </summary>
    /// <param name="textureData"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    ulong LoadTexture(Span<byte> textureData, uint width, uint height);

    /// <summary>
    /// Returns whether a texture is loaded.
    /// </summary>
    bool IsTextureLoaded(ulong texId);

    /// <summary>
    /// Updates an image.
    /// </summary>
    /// <param name="texId">Texture Id.</param>
    /// <param name="textureData">Nex texture data.</param>
    /// <param name="width">Width.</param>
    /// <param name="height">Height.</param>
    void UpdateTexture(ulong texId, Span<byte> textureData, uint width, uint height);

    /// <summary>
    /// Frees an image.
    /// </summary>
    void FreeTexture(ulong texId);

    public delegate void OnBackendInitializedDelegate();
    public delegate void OnBackendShutdownDelegate();
    public delegate void OnBuffersResizedDelegate(uint width, uint height);

    /// <summary>
    /// Fired when the backend renderer was initialized.
    /// </summary>
    public event OnBackendInitializedDelegate OnBackendInitialized;

    /// <summary>
    /// Fired when the backend renderer was shutdown.
    /// </summary>
    public event OnBackendShutdownDelegate OnBackendShutdown;

    /// <summary>
    /// Fired when the backend renderer caught a resize event.
    /// </summary>
    public event OnBuffersResizedDelegate OnBuffersResized;

}
