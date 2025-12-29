using NenTools.ImGui.Hooks.Definitions;
using NenTools.ImGui.Hooks.DirectX;
using NenTools.ImGui.Hooks.DirectX12.Definitions;
using NenTools.ImGui.Native;
using NenTools.ImGui.Interfaces.Backend;

using Reloaded.Hooks.Definitions;
using Reloaded.Memory.Interfaces;

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

using Vortice.Direct3D12;
using Vortice.DXGI;
using static Vortice.Direct3D12.D3D12;
using static Vortice.DXGI.DXGI;

#pragma warning disable CA1416 // This call site is reachable on all platforms. (method) is only supported on: 'windows' 5.1.2600 and later.

namespace NenTools.ImGui.Hooks.DirectX12;

public unsafe class DX12BackendHook : IBackendHook
{
    private bool _initializedD3D12 = false;

    private static readonly string[] _supportedDlls =
    [
        "d3d12.dll",
    ];

    private IHook<PresentDelegate> _presentHook;
    private nuint _hookedSwapchainVtableAddr;
    private nuint _previousVTableAddr;
    private IHook<ResizeBuffersDelegate> _resizeBuffersHook;
    private IHook<ResizeTargetDelegate> _resizeTargetHook;
    private IHook<CreateSwapChainForHwnd> _createSwapChainForHwndHook;

    delegate nint PresentDelegate(nuint swapChainPtr, int syncInterval, PresentFlags flags);
    delegate nint ResizeBuffersDelegate(nint swapchainPtr, uint bufferCount, uint width, uint height, Format newFormat, SwapChainFlags swapchainFlags);
    delegate nint ResizeTargetDelegate(nint swapchainPtr, nint pNewTargetParameters);
    delegate nint CreateSwapChainForHwnd(nint this_, nint pDevice, nint hWnd, SwapChainDescription* pDesc, SwapChainFullscreenDescription* pFullscreenDesc, nint pRestrictToOutput, nint ppSwapChain);

    public event IBackendHook.OnBackendInitializedDelegate OnBackendInitialized;
    public event IBackendHook.OnBackendShutdownDelegate OnBackendShutdown;
    public event IBackendHook.OnBuffersResizedDelegate OnBuffersResized;

    private bool _convertPointerHooksToVtableHookPhase = false;

    // Hook fields
    [ThreadStatic]
    private static int _presentDepth;

    [ThreadStatic]
    private static int _resizeBufferDepth;

    [ThreadStatic]
    private static int _resizeTargetDepth;

    [ThreadStatic]
    private static bool _createSwapChainRecursionLock;

    private readonly Lock _lock = new();
    private bool _isHookingD3D12 = false; // Used to ensure CreateSwapChainForHwnd hook does not call recursively
    private bool _isUsingFrameGenerationSwapchain = false; // Used to determine whether we are using Frame Gen (DLSS/FSR)'s swapchain (not really used?)
    private bool _isUsingProtonSwapchain = false; // Used to determine whether we are using Proton's Swapchain
    private nuint _protonSwapchainOffset; // Used to determine where the real swapchain is in proton's wrapper swapchain

    /*
    * In some cases (E.g. under DX9 + Viewports enabled), Dear ImGui might call
    * DirectX functions from within its internal logic.
    *
    * We put a lock on the current thread in order to prevent stack overflow.
    */
    public static nuint? CommandQueueOffset = null;


    // Core D3D12 Resources
    public ID3D12Device Device { get; private set; }
    public IDXGISwapChain3 SwapChain { get; private set; }
    public ID3D12CommandQueue CommandQueue { get; private set; }
    private List<CommandContext> _commandContexts = [];
    private ID3D12DescriptorHeap _shaderResourceViewDescHeap;
    private ID3D12DescriptorHeap _renderTargetViewDescHeap;
    private List<FrameContext> _frameContexts = [];
    public int _commandContextIndex;

    // D3D12 Texture resources
    private ID3D12CommandAllocator _textureUploadCommandAllocator;
    private ID3D12GraphicsCommandList _textureUploadCommandList;
    private ID3D12CommandQueue _textureUploadCommandQueue;
    private ID3D12Fence _textureUploadFence;
    private ulong _fenceValue;

    private static DescriptorHeapAllocator _textureHeapAllocator;
    private ConcurrentDictionary<ulong, TextureResource> _textureIds = [];

    public void* _imGuiBackendRendererData;

    /// <summary>
    /// Contains the DX12 DXGI Factory VTable.
    /// </summary>
    public static IVirtualFunctionTable FactoryVTable { get; private set; }

    /// <summary>
    /// Contains the DX12 DXGI Swapchain VTable.
    /// </summary>
    public static IVirtualFunctionTable SwapchainVTable { get; private set; }

    /// <summary>
    /// Contains the DX12 DXGI Command Queue VTable.
    /// </summary>
    public static IVirtualFunctionTable ComamndQueueVTable { get; private set; }

    public DX12BackendHook()
    {
        ImguiHookDx12Wrapper.Instance = this;
    }

    public bool IsApiSupported()
    {
        foreach (var dll in _supportedDlls)
        {
            var handle = PInvoke.GetModuleHandle(dll);
            if (!handle.IsInvalid)
                return true;
        }

        // Fallback to detecting D3D12Core
        if (File.Exists(Path.Combine("D3D12", "D3D12Core.dll")))
            return true;

        return false;
    }

    /// <summary>
    /// Creates a dummy device/swapchain used to locate vtables and offsets used by D3D12.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    /// <exception cref="Exception"></exception>
    private void CreateDummySwapchainAndFindVTables()
    {
        DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Creating dummy D3D12 device for hook purposes...");

        ID3D12Device? device;
        var createDevice = PInvoke.GetProcAddress(PInvoke.GetModuleHandle("d3d12.dll"), "D3D12CreateDevice");

        // D3D12CreateDevice may have been hooked beforehand (Reshade, etc), so unhook it temporarily
        // we're creating a dummy device, so we preferably don't want anyone to treat it as something to interact with
        List<byte>? originalFunctionBytesDiff = HookUtility.GetOriginalBytesIfHooked((nuint)createDevice.Value);
        if (originalFunctionBytesDiff is not null)
        {
            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] D3D12CreateDevice appears to be hooked by someone else before us, unhooking temporarily for dummy device creation...");

            Span<byte> previouslyHookedBytes = new byte[originalFunctionBytesDiff.Count];
            Reloaded.Memory.Memory.Instance.SafeRead((nuint)createDevice.Value, previouslyHookedBytes); // Read hooked bytes
            Reloaded.Memory.Memory.Instance.SafeWrite((nuint)createDevice.Value, CollectionsMarshal.AsSpan(originalFunctionBytesDiff)); // Restore original

            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] D3D12CreateDevice unhooked, creating device.");
            SharpGen.Runtime.Result res = D3D12CreateDevice(null, Vortice.Direct3D.FeatureLevel.Level_12_0, out device);
            if (!res.Success) // Call original
                throw new Exception($"Failed to create D3D12 Device for vtable detection. Error: {res}");

            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] D3D12CreateDevice dummy device created, restoring previous hook.");

            Reloaded.Memory.Memory.Instance.SafeWrite((nuint)createDevice.Value, previouslyHookedBytes); // Restore hooked bytes
        }
        else
        {
            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] D3D12CreateDevice is not hooked, creating device.");

            try
            {
                SharpGen.Runtime.Result res = D3D12CreateDevice(null, Vortice.Direct3D.FeatureLevel.Level_12_0, out device);
                if (!res.Success) // Call original
                    throw new Exception($"Failed to create D3D12 Device for vtable detection. Error: {res}");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create D3D12 Device for vtable detection.", ex);
            }
        }
        device.Name = $"[{nameof(DX12BackendHook)}] Dummy D3D12 device";

        ID3D12CommandQueue commandQueue = device.CreateCommandQueue(new CommandQueueDescription(CommandListType.Direct));
        commandQueue.Name = $"[{nameof(DX12BackendHook)}] Dummy command queue";

        var swapChainDesc = new SwapChainDescription1()
        {
            Format = Format.R8G8B8A8_UNorm,
            BufferUsage = Usage.RenderTargetOutput,
            SwapEffect = SwapEffect.FlipDiscard,
            BufferCount = 2,
            SampleDescription = new SampleDescription(1, 0),
            AlphaMode = AlphaMode.Premultiplied,
            Width = 1,
            Height = 1,
        };

        DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Creating dummy swapchain.");

        IDXGISwapChain1? swapChain = null;
        using (IDXGIFactory6 factory = CreateDXGIFactory2<IDXGIFactory6>(debug: false)) // Will call CreateDXGIFactory2
        {
            // We ideally don't want to create a swapchain through CreateSwapChainForHwnd, because it may have been hooked
            // Try multiple ways

            try
            {
                swapChain = factory.CreateSwapChainForComposition(commandQueue, swapChainDesc, null!);
            }
            catch
            {
                DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Dummy swapchain creation failed with CreateSwapChainForComposition");
            }

            if (swapChain is null)
            {
                if (!CreateHandleWithDummyWindow(factory, commandQueue, out swapChainDesc, out swapChain)) // TODO: Verify if this one even works
                {
                    throw new Exception("Could not create dummy swapchain with dummy window");
                }
                else
                    DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Swapchain created with CreateHandleWithDummyWindow");
            }
            else
                DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Swapchain created with CreateSwapChainForComposition");
            swapChain.DebugName = $"[{nameof(DX12BackendHook)}] Dummy swapchain";

            // TODO: use this to figure if it's a DLSS or FSR object? could never get that working
            var typeInfo = RTTIUtility.GetLocator((void*)swapChain.NativePointer);

            bool usingFrameGenSwapchain = false;

            // We need to try and find the command queue from the swapchain
            // We are not allowed to simply use it from hooked calls (D3D12 may forbid this)
            // So search for the pointer in the dummy swapchain
            unsafe
            {
                nint* ptr = (nint*)swapChain.NativePointer;
                for (int i = 0; i < 1000; i++)
                {
                    if (ptr[i] == commandQueue.NativePointer)
                    {
                        CommandQueueOffset = (nuint)(i * 8);
                        break;
                    }
                }
            }

            if (CommandQueueOffset is null)
            {
                bool shouldBreak = false;
                for (nuint @base = 0; @base < 512 * (nuint)sizeof(nuint); @base += (nuint)sizeof(nuint))
                {
                    nuint preScanBase = (nuint)swapChain.NativePointer + @base;
                    if (PInvoke.IsBadReadPtr((void*)preScanBase, (nuint)sizeof(nuint)))
                        break;

                    nuint scanBase = *(nuint*)preScanBase;
                    if (scanBase == 0 || PInvoke.IsBadReadPtr((void*)scanBase, (nuint)sizeof(nuint)))
                        continue;

                    for (nuint i = 0; i < 512 * (nuint)sizeof(nuint); i += (nuint)sizeof(nuint))
                    {
                        nuint preData = scanBase + i;

                        if (PInvoke.IsBadReadPtr((void*)preData, (nuint)sizeof(nint)))
                            break;

                        nuint* data = *(nuint**)preData;

                        if ((nuint)data == (nuint)commandQueue.NativePointer)
                        {
                            // As per REFramework:
                            //   If we hook Streamline's Swapchain, the menu fails to render correctly/flickers
                            //   So we switch out the swapchain with the internal one owned by Streamline
                            //   Side note: Even though we are scanning for Proton here,
                            //   this doubles as an offset scanner for the real swapchain inside Streamline (or FSR3)
                            if (_isUsingFrameGenerationSwapchain)
                                swapChain = new IDXGISwapChain3((nint)scanBase);

                            if (!_isUsingFrameGenerationSwapchain)
                                _isUsingProtonSwapchain = true;

                            CommandQueueOffset = i;
                            _protonSwapchainOffset = @base;
                            shouldBreak = true;

                            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Proton potentially detected");
                            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Found command queue offset: 0x{i:X8}");
                            break;
                        }
                    }

                    if (_isUsingProtonSwapchain || shouldBreak)
                        break;
                }
            }

            FactoryVTable = SDK.Hooks.VirtualFunctionTableFromObject(factory.NativePointer, Enum.GetNames<IDXGIFactoryVTable>().Length);
            SwapchainVTable = SDK.Hooks.VirtualFunctionTableFromObject(swapChain.NativePointer, Enum.GetNames<IDXGISwapChainVTable>().Length);
            ComamndQueueVTable = SDK.Hooks.VirtualFunctionTableFromObject(commandQueue.NativePointer, Enum.GetNames<ID3D12CommandQueueVTable>().Length);

            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Swapchain command queue offset: 0x{CommandQueueOffset:X}");

            if (CommandQueueOffset is null)
                throw new Exception("Could not determine command queue offset from DX12 Swapchain pointer.");

            swapChain?.Dispose();
        }

        // Cleanup
        device.Dispose();
    }

    private static bool CreateHandleWithDummyWindow(IDXGIFactory2 factory, ID3D12CommandQueue commandQueue, out SwapChainDescription1 swapChainDesc, out IDXGISwapChain1 swapChain)
    {
        var handle = PInvoke.GetModuleHandle(null);

        const string className = $"{nameof(DX12BackendHook)}_DummyClassName";
        fixed (char* pClassName = className)
        {
            var wc = new WNDCLASSEXW()
            {
                cbSize = 0x50,
                style = WNDCLASS_STYLES.CS_HREDRAW | WNDCLASS_STYLES.CS_VREDRAW,
                lpfnWndProc = PInvoke.DefWindowProc,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = new HINSTANCE(handle.DangerousGetHandle()),
                hIcon = HICON.Null,
                hCursor = HCURSOR.Null,
                hbrBackground = Windows.Win32.Graphics.Gdi.HBRUSH.Null,
                lpszClassName = pClassName
            };

            PInvoke.RegisterClassEx(wc);

            var hwnd = PInvoke.CreateWindowEx(0, className, $"[{nameof(DX12BackendHook)}] DX Dummy Window", WINDOW_STYLE.WS_OVERLAPPEDWINDOW, 0, 0, 100, 100, HWND.Null, null, handle, null);

            swapChainDesc.BufferCount = 3;
            swapChainDesc.Width = 0;
            swapChainDesc.Height = 0;
            swapChainDesc.Format = Format.R8G8B8A8_UNorm;
            swapChainDesc.Flags = SwapChainFlags.FrameLatencyWaitableObject;
            swapChainDesc.BufferUsage = Usage.RenderTargetOutput;
            swapChainDesc.SampleDescription.Count = 1;
            swapChainDesc.SampleDescription.Quality = 0;
            swapChainDesc.SwapEffect = SwapEffect.FlipDiscard;
            swapChainDesc.AlphaMode = AlphaMode.Unspecified;
            swapChainDesc.Scaling = Scaling.Stretch;
            swapChainDesc.Stereo = false;

            try
            {
                swapChain = factory.CreateSwapChainForHwnd(commandQueue, hwnd, swapChainDesc, null, null);
                return true;
            }
            catch (Exception ex)
            {
                swapChain = null;
                return false;
            }
        }
    }

    /// <summary>
    /// Finds and hooks D3D12 functions.
    /// </summary>
    public void InitAndEnableHooks()
    {
        _isHookingD3D12 = true;
        if (CommandQueueOffset == 0 || SwapchainVTable is null && ComamndQueueVTable is null) // We are reusing known pointers if we already found them
            CreateDummySwapchainAndFindVTables();

        // Got our pointers, start hooking functions.
        HookBaseD3D12Functions();
        _isHookingD3D12 = false;
    }

    /// <summary>
    /// Hooks D3D12 functions after their vtables have been located.
    /// </summary>
    private void HookBaseD3D12Functions()
    {
        DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Hooking base D3D12 functions...");

        // TODO: Hook streamline 

        lock (_lock)
        {
            DisableHooks();

            _convertPointerHooksToVtableHookPhase = true;

            // Hook vtable entries, least intrusive
            nuint presentPointerAddr = (nuint)SwapchainVTable[(int)IDXGISwapChainVTable.Present].EntryAddress;
            _presentHook = new FunctionPointerHook<PresentDelegate>(presentPointerAddr, PresentImpl).Activate();

            nuint createSwapChainForHwndPointerAddr = (nuint)FactoryVTable[(int)IDXGIFactoryVTable.CreateSwapChainForHwnd].EntryAddress;
            _createSwapChainForHwndHook ??= new FunctionPointerHook<CreateSwapChainForHwnd>(createSwapChainForHwndPointerAddr, CreateSwapChainForHwndImpl).Activate();
        }
    }

    ~DX12BackendHook()
    {
        Dispose();
    }

    public void Dispose()
    {
        lock (_lock)
        {
            ShutdownD3D12(isReinit: false);
            DisableHooks();

            _createSwapChainForHwndHook?.Disable();
            _shaderResourceViewDescHeap?.Dispose();

            // Dispose texture resources
            _textureHeapAllocator?.Destroy();

            _textureUploadCommandAllocator?.Dispose();
            _textureUploadCommandList?.Dispose();
            _textureUploadCommandQueue?.Dispose();
            _textureUploadFence?.Dispose();
        }

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Hooked CreateSwapChainForHwnd. Called when switching to FSR Frame Gen.
    /// </summary>
    /// <param name="factory"></param>
    /// <param name="pDevice"></param>
    /// <param name="hWnd"></param>
    /// <param name="pDesc"></param>
    /// <param name="pFullscreenDesc"></param>
    /// <param name="pRestrictToOutput"></param>
    /// <param name="ppSwapChain"></param>
    /// <returns></returns>
    public nint CreateSwapChainForHwndImpl(nint factory, nint pDevice, nint hWnd, SwapChainDescription* pDesc, SwapChainFullscreenDescription* pFullscreenDesc, nint pRestrictToOutput, nint ppSwapChain)
    {
        DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] CreateSwapChainForHwndImpl called");

        if (_isHookingD3D12)
            return _createSwapChainForHwndHook.OriginalFunction.Invoke(factory, pDevice, hWnd, pDesc, pFullscreenDesc, pRestrictToOutput, ppSwapChain);

        lock (_lock)
        {
            DisableHooks(); // FSR/DLSS creates a new swapchain. We have hooks on the vtable pointer of the original swapchain, we need to restore it
            ShutdownD3D12();
        }

        var res = _createSwapChainForHwndHook.OriginalFunction.Invoke(factory, pDevice, hWnd, pDesc, pFullscreenDesc, pRestrictToOutput, ppSwapChain);

        lock (_lock)
        {
            InitAndEnableHooks();
        }

        DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] CreateSwapChainForHwndImpl end");
        return res;
    }

    /// <summary>
    /// Initializes D3D12 for ImGui rendering.
    /// </summary>
    /// <returns></returns>
    private bool InitD3D12()
    {
        DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] InitD3D12 (buffer count: {SwapChain.Description.BufferCount})");

        ShutdownD3D12();
        ImGuiMethods.cImGui_ImplWin32_Init(SwapChain.Description.OutputWindow);

        for (int i = 0; i < 3; i++)
        {
            var commandContext = new CommandContext();
            commandContext.Setup(this);
            _commandContexts.Add(commandContext);
        }

        // Create SRV Heap
        var descriptorImGuiRender = new DescriptorHeapDescription
        {
            Type = DescriptorHeapType.ConstantBufferViewShaderResourceViewUnorderedAccessView,
            DescriptorCount = 11,
            Flags = DescriptorHeapFlags.ShaderVisible
        };

        if (_shaderResourceViewDescHeap is null)
        {
            _shaderResourceViewDescHeap = Device.CreateDescriptorHeap(descriptorImGuiRender);
            if (_shaderResourceViewDescHeap == null)
            {
                DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Failed to create shader resource view descriptor heap.");
                return false;
            }
            _shaderResourceViewDescHeap.Name = $"[{nameof(DX12BackendHook)}] ShaderResourceViewDescHeap";
        }

        // Create RTV Heap
        var renderTargetDesc = new DescriptorHeapDescription
        {
            Type = DescriptorHeapType.RenderTargetView,
            DescriptorCount = SwapChain.Description.BufferCount, // depends based on user's OS settings, don't hardcode a number here
            Flags = DescriptorHeapFlags.None,
            NodeMask = 1
        };
        _renderTargetViewDescHeap = Device.CreateDescriptorHeap(renderTargetDesc);
        if (_renderTargetViewDescHeap is null)
            return false;

        var rtvDescriptorSize = Device.GetDescriptorHandleIncrementSize(DescriptorHeapType.RenderTargetView);
        var rtvHandle = _renderTargetViewDescHeap.GetCPUDescriptorHandleForHeapStart();
        _renderTargetViewDescHeap.Name = $"[{nameof(DX12BackendHook)}] RenderTargetViewHeap";

        // Get RTVs
        IDXGISwapChain swapChain = SwapChain;
        for (uint i = 0; i < swapChain.Description.BufferCount; i++)
        {
            _frameContexts.Add(new FrameContext
            {
                MainRenderTargetDescriptor = rtvHandle,
                MainRenderTargetResource = swapChain.GetBuffer<ID3D12Resource>(i),
            });
            Device.CreateRenderTargetView(_frameContexts[(int)i].MainRenderTargetResource, null, rtvHandle);
            rtvHandle.Ptr += rtvDescriptorSize;
        }

        var props = new HeapProperties()
        {
            Type = HeapType.Default,
            CPUPageProperty = CpuPageProperty.Unknown,
            MemoryPoolPreference = MemoryPool.Unknown
        };

        // Create our texture heap allocator/pool, for ImGui textures
        if (_textureHeapAllocator is null)
        {
            _textureHeapAllocator = new DescriptorHeapAllocator();
            var heap = Device.CreateDescriptorHeap(new DescriptorHeapDescription()
            {
                DescriptorCount = 2048,
                Type = DescriptorHeapType.ConstantBufferViewShaderResourceViewUnorderedAccessView,
                Flags = DescriptorHeapFlags.ShaderVisible,
            });
            heap.Name = $"[{nameof(DX12BackendHook)}] Texture Descriptor Heap";
            _textureHeapAllocator.Create(Device, heap);
        }

        var initInfo = new ImGui_ImplDX12_InitInfo_t
        {
            Device = Device.NativePointer,
            CommandQueue = CommandQueue.NativePointer,
            NumFramesInFlight = (int)swapChain.Description.BufferCount,
            RTVFormat = (int)Format.R8G8B8A8_UNorm,
            SrvDescriptorHeap = _shaderResourceViewDescHeap.NativePointer,
            SrvDescriptorAllocFn = &ImguiHookDx12Wrapper.SrvDescriptorAllocCallback,
            SrvDescriptorFreeFn = &ImguiHookDx12Wrapper.SrvDescriptorFreeCallback,
        };

        ImGuiMethods.cImGui_ImplDX12_Init((nint)(&initInfo));
        _imGuiBackendRendererData = ImGuiMethods.GetIO()->BackendRendererUserData;

        DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] D3D12 initted.");

        _initializedD3D12 = true;
        OnBackendInitialized?.Invoke();

        return true;
    }

    /// <summary>
    /// Shuts down D3D12 for ImGui rendering. This will clean up all known resources and call ImGui_ImplDX12_Shutdown.
    /// </summary>
    private void ShutdownD3D12(bool isReinit = true)
    {
        if (isReinit)
            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Cleaning up D3D12 for reinitialization");
        else
            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] ShutdownD3D12 called");

        if (_imGuiBackendRendererData is not null)
            ImGuiMethods.cImGui_ImplDX12_Shutdown();

        foreach (var commandContext in _commandContexts)
            commandContext.Reset();
        _commandContexts.Clear();

        // ResizeBuffer requires swapchain resources to be freed.
        foreach (var ctx in _frameContexts)
        {
            // NOTE: This may crash/error here if:
            // The vtable pointer on the swapchain hasn't been restored.
            // The way it happens is:
            // - Turning on and off FSR Frame Gen repeatedly
            // - Switching from fullscreen to windowed
            // - Turning on DirectX debug layer?
            // This should now be solved in CreateSwapChainForHwnd where we restore hooks before shutting down.
            ctx.MainRenderTargetResource?.Dispose();
            ctx.MainRenderTargetResource = null!;
        }

        _frameContexts.Clear();
        _renderTargetViewDescHeap?.Dispose();

        // We do not reset texture heap/SRV to persist textures.

        if (ImGuiMethods.GetIO()->BackendPlatformName is not null && Marshal.PtrToStringAnsi((nint)ImGuiMethods.GetIO()->BackendPlatformName)!.Contains("win32"))
            ImGuiMethods.cImGui_ImplWin32_Shutdown();

        _imGuiBackendRendererData = null;
        _initializedD3D12 = false;
        OnBackendShutdown?.Invoke();
    }


    /// <summary>
    /// Disables D3D12 hooks, no D3D12 function will be intercepted.
    /// </summary>
    public void DisableHooks()
    {
        DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Disabling D3D12 hooks (if any)");

        _presentHook?.Disable();
        _resizeBuffersHook?.Disable();
        _resizeTargetHook?.Disable();

        // HookedVirtualFunctionTableFromObject/HookedObjectVirtualFunctionTable (Reloaded-II) does not give us a way to restore the vtable pointer
        // So restore it ourselves.
        if (_hookedSwapchainVtableAddr != 0 && _previousVTableAddr != 0)
        {
            // We gotta restore the vtable pointer. It may cause trouble if the game or anybody else tries to free a swapchain.
            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Restoring swapchain vtable pointer which we previously hooked");

            Interlocked.Exchange(ref *(nuint*)_hookedSwapchainVtableAddr, _previousVTableAddr);
            _convertPointerHooksToVtableHookPhase = true;

            _hookedSwapchainVtableAddr = 0;
            _previousVTableAddr = 0;
        }

        // We don't unhook swapchain creation. Not needed.
    }

    /// <summary>
    /// Enables D3D12 hooks and starts intercepting D3D12 functions.
    /// </summary>
    public void EnableHooks()
    {
        _presentHook?.Enable();
        _resizeBuffersHook?.Enable();
        _resizeTargetHook?.Enable();
    }

    #region Present Hook
    /// <summary>
    /// Hooked IDXGISwapChain::Present function.
    /// </summary>
    /// <param name="swapChainPtr"></param>
    /// <param name="syncInterval"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    public nint PresentImpl(nuint swapChainPtr, int syncInterval, PresentFlags flags)
    {
        PresentDelegate originalFunc = _presentHook.OriginalFunction;

        IDXGISwapChain3 swapChain = new IDXGISwapChain3((nint)swapChainPtr);

        // Ignore windows which don't belong to us.
        var windowHandle = swapChain.Description.OutputWindow;
        if (!ImguiHook.CheckWindowHandle(windowHandle))
        {
            Debug.WriteLine($"[{nameof(DX12BackendHook)}] Discarding Window Handle {windowHandle:X} due to Mismatch");
            return originalFunc(swapChainPtr, syncInterval, flags);
        }

        if (!_convertPointerHooksToVtableHookPhase && swapChainPtr != _hookedSwapchainVtableAddr)
            return originalFunc(swapChainPtr, syncInterval, flags);

        // For safety reasons, we switch from vtable entry pointer hooks to whole vtable hook
        if (_convertPointerHooksToVtableHookPhase)
        {
            _presentHook.Disable();

            // Save the swapchain pointer/vtable pointers
            _hookedSwapchainVtableAddr = swapChainPtr;
            _previousVTableAddr = *(nuint*)swapChainPtr;

            // NOTE: Must ensure that IDXGISwapChainVTable has all the members defined for IDXGISwapChain (including inherited ones), since we are copying the whole vtable.
            // It should have all members up to IDXGISwapChain4.
            IVirtualFunctionTable hookedVTable = SDK.Hooks.HookedVirtualFunctionTableFromObject((nint)swapChainPtr, Enum.GetNames<IDXGISwapChainVTable>().Length);
            _presentHook = hookedVTable.CreateFunctionHook<PresentDelegate>((int)IDXGISwapChainVTable.Present, PresentImpl).Activate();
            _resizeBuffersHook = hookedVTable.CreateFunctionHook<ResizeBuffersDelegate>((int)IDXGISwapChainVTable.ResizeBuffers, ResizeBuffersImpl).Activate();
            _resizeTargetHook = hookedVTable.CreateFunctionHook<ResizeTargetDelegate>((int)IDXGISwapChainVTable.ResizeTarget, ResizeTargetImpl).Activate();

            _convertPointerHooksToVtableHookPhase = false;
            originalFunc = _presentHook.OriginalFunction;
        }

        SwapChain = swapChain;
        Device = SwapChain.GetDevice<ID3D12Device>();

        // Proton's real swap chain may be located elsewhere, we've tracked it earlier
        if (_isUsingProtonSwapchain)
        {
            nuint realSwapchainPtr = *(nuint*)(swapChainPtr + _protonSwapchainOffset);
            CommandQueue = new ID3D12CommandQueue(*(nint*)(realSwapchainPtr + CommandQueueOffset!.Value));
        }
        else
            CommandQueue = new ID3D12CommandQueue(*(nint*)(swapChainPtr + CommandQueueOffset!.Value));

        if (_presentDepth > 0)
        {
            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Present discarding via Recursion Lock");

            _presentDepth++;
            var res_ = originalFunc.Invoke(swapChainPtr, syncInterval, flags);
            if (res_ != nint.Zero)
                DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Present original failed 0x{res_:X8}");
            _presentDepth--;
            return res_;
        }

        OnPresent();

        _presentDepth++;
        var result = originalFunc(swapChainPtr, syncInterval, flags);
        if (result != nint.Zero)
            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Present original failed 0x{result:X8}");

        _presentDepth--;

        return result;
    }

    private bool _hasHookedWinProc = false;
    /// <summary>
    /// Our own function for handling present calls.
    /// </summary>
    private void OnPresent()
    {
        if (!_initializedD3D12)
        {
            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] Init D3D12 handle for ImGui, Window Handle: {SwapChain.Description.OutputWindow:X}");
            if (!_hasHookedWinProc)
            {
                ImguiHook.InitializeWithHandle(SwapChain.Description.OutputWindow);
                _hasHookedWinProc = true;
            }

            lock (_lock)
            {
                InitD3D12();
            }
        }

        ImGuiMethods.cImGui_ImplDX12_NewFrame();

        // OUTDATED COMMENT MAYBE:
        // ImGui >=1.92 note
        // When resizing windows outside the game window (viewports), the game wants to
        // Resize windows for some reason using PlatformIO_SetWindowSize
        // ImGui's DX12 implementation for that will call ResizeBuffers which we hook

        // In turn, InvalidateDeviceObjects will be called, and all textures will be destroyed as of 1.92

        // On the next frame for some reason the textures aren't recreated (font mainly?)
        // We may need to also set ImGui->PlatformIO->SetWindowSize to null maybe? Not sure.

        // this may  call CreateSwapChainForHwnd when creating windows, which we hook. we use a lock to make sure we aren't freeing objects again.
        _createSwapChainRecursionLock = true;
        ImguiHook.NewFrame();
        _createSwapChainRecursionLock = false;

        if (_commandContexts.Count == 0)
            return;

        // Triple buffer
        CommandContext commandContext = _commandContexts[_commandContextIndex++ % _commandContexts.Count];

        if (SwapChain.CurrentBackBufferIndex >= _frameContexts.Count)
            return;

        FrameContext currentFrameContext = _frameContexts[(int)SwapChain.CurrentBackBufferIndex];

        commandContext.Wait(TimeSpan.FromSeconds(-1)); // INFINITE
        lock (commandContext.Lock)
        {
            commandContext.HasCommands = true;

            var barrier = new ResourceBarrier(new ResourceTransitionBarrier(currentFrameContext.MainRenderTargetResource, ResourceStates.Present, ResourceStates.RenderTarget));
            commandContext.CommandList.ResourceBarrier(barrier);
            commandContext.CommandList.OMSetRenderTargets(currentFrameContext.MainRenderTargetDescriptor, null);
            commandContext.CommandList.SetDescriptorHeaps(_shaderResourceViewDescHeap);

            ImGuiMethods.cImGui_ImplDX12_RenderDrawData((nint)ImGuiMethods.GetDrawData(), commandContext.CommandList.NativePointer);

            barrier = new ResourceBarrier(new ResourceTransitionBarrier(currentFrameContext.MainRenderTargetResource, ResourceStates.RenderTarget, ResourceStates.Present));
            commandContext.CommandList.ResourceBarrier(barrier);

            commandContext.Execute(CommandQueue);
        }
    }
    #endregion

    #region ResizeBuffers Hook
    /// <summary>
    /// Hook for IDXGISwapChain::ResizeBuffers, for handling window resizes.
    /// </summary>
    /// <param name="swapchainPtr"></param>
    /// <param name="bufferCount"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="newFormat"></param>
    /// <param name="swapchainFlags"></param>
    /// <returns></returns>
    public nint ResizeBuffersImpl(nint swapchainPtr, uint bufferCount, uint width, uint height, Format newFormat, SwapChainFlags swapchainFlags)
    {
        DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] --- ResizeBuffers called ---");

        if (_resizeBufferDepth > 0)
        {
            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] ResizeBuffers discarding wia Recursion Lock");

            _resizeBufferDepth++;
            var res = _resizeBuffersHook.OriginalFunction(swapchainPtr, bufferCount, width, height, newFormat, swapchainFlags);
            _resizeBufferDepth--;
            return res;
        }

        // Dispose all frame context resources
        OnBuffersResizedImpl(width, height);

        _resizeBufferDepth++;
        var result = _resizeBuffersHook.OriginalFunction(swapchainPtr, bufferCount, width, height, newFormat, swapchainFlags);
        _resizeBufferDepth--;

        if (result != nint.Zero)
            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] ResizeBuffers original failed with {result:X}");

        DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] --- ResizeBuffers end (result: {result:X8}) ---");
        return result;
    }

    private void OnBuffersResizedImpl(uint width, uint height)
    {
        // Deinit everything.
        lock (_lock)
        {
            ShutdownD3D12();
        }

        OnBuffersResized?.Invoke(width, height);
    }
    #endregion

    #region ResizeTarget Hook
    /// <summary>
    /// Hook for IDXGISwapChain::ResizeTarget, for handling windowed/fullscreen switches.
    /// </summary>
    /// <param name="swapchainPtr"></param>
    /// <param name="pNewTargetParameters"></param>
    /// <returns></returns>
    public nint ResizeTargetImpl(nint swapchainPtr, nint pNewTargetParameters)
    {
        DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] --- ResizeTarget called ---");
        if (_resizeTargetDepth > 0)
        {
            Debug.WriteLine($"[{nameof(DX12BackendHook)}] ResizeTarget discarding via Recursion Lock");

            _resizeTargetDepth++;
            var res = _resizeTargetHook.OriginalFunction(swapchainPtr, pNewTargetParameters);
            _resizeTargetDepth--;
            return res;
        }

        // Dispose all frame context resources
        OnTargetResized();

        _resizeTargetDepth++;
        var result = _resizeTargetHook.OriginalFunction(swapchainPtr, pNewTargetParameters);
        _resizeTargetDepth--;

        if (result != nint.Zero)
            DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] ResizeTarget original failed with result: 0x{result:X}");

        DebugLog.WriteLine($"[{nameof(DX12BackendHook)}] --- ResizeTarget end (result: {result:X8}) ---");
        return result;
    }

    private void OnTargetResized()
    {
        // Deinit everything.
        lock (_lock)
        {
            ShutdownD3D12();
        }
    }
    #endregion

    public void SrvDescriptorAllocCallback(ImGui_ImplDX12_InitInfo_t* initInfo, CpuDescriptorHandle* cpuHandle, GpuDescriptorHandle* gpuHandle)
    {
        _textureHeapAllocator.Alloc(ref *cpuHandle, ref *gpuHandle);
    }

    public void SrvDescriptorFreeCallback(ImGui_ImplDX12_InitInfo_t* a, CpuDescriptorHandle cpuHandle, GpuDescriptorHandle gpuHandle)
    {
        _textureHeapAllocator.Free(cpuHandle, gpuHandle);
    }

    #region Texture Work
    const int D3D12_TEXTURE_DATA_PITCH_ALIGNMENT = 256;
    const int BytesPerPixel = 4;

    /// <summary>
    /// Loads an image and returns the ImTextureID for it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="imageWidth"></param>
    /// <param name="imageHeight"></param>
    /// <returns></returns>
    public ulong LoadTexture(Span<byte> bytes, uint imageWidth, uint imageHeight)
    {
        var heapProperties = new HeapProperties(HeapType.Default);
        var imageDesc = new ResourceDescription(ResourceDimension.Texture2D, 0, imageWidth, imageHeight, 1, 1, Format.R8G8B8A8_UNorm, 1, 0, TextureLayout.Unknown, ResourceFlags.None);
        ID3D12Resource pTexture = Device.CreateCommittedResource(heapProperties, HeapFlags.None, imageDesc, ResourceStates.CopyDest);

        var uploadBufferHeapDesc = new HeapProperties(HeapType.Upload);
        uint uploadPitch = (uint)(imageWidth * BytesPerPixel + D3D12_TEXTURE_DATA_PITCH_ALIGNMENT - 1u & ~(D3D12_TEXTURE_DATA_PITCH_ALIGNMENT - 1u));
        uint uploadSize = imageHeight * uploadPitch;

        var tempDesc = new ResourceDescription(ResourceDimension.Buffer, 0, uploadSize, 1, 1, 1, Format.Unknown, 1, 0, TextureLayout.RowMajor, ResourceFlags.None);
        ID3D12Resource uploadBuffer = Device.CreateCommittedResource(uploadBufferHeapDesc, HeapFlags.None, tempDesc, ResourceStates.GenericRead);

        var range = new Vortice.Direct3D12.Range()
        {
            Begin = 0,
            End = uploadSize,
        };

        nint mapped = 0;
        if (!uploadBuffer.Map(0, range, &mapped).Success)
        {
            ;
        }

        fixed (byte* imageData = bytes)
        {
            for (int y = 0; y < imageHeight; y++)
                Buffer.MemoryCopy(imageData + y * imageWidth * 4, // Src
                    (void*)(nuint)(mapped + y * uploadPitch), // Dst
                    imageWidth * 4, imageWidth * 4); // Len
        }
        uploadBuffer.Unmap(0, range);

        var srcLocation = new TextureCopyLocation(uploadBuffer, new PlacedSubresourceFootPrint()
        {
            Footprint = new SubresourceFootPrint()
            {
                Format = Format.R8G8B8A8_UNorm,
                Width = imageWidth,
                Height = imageHeight,
                Depth = 1,
                RowPitch = uploadPitch,
            },
        });
        var dstLocation = new TextureCopyLocation(pTexture, 0);

        ID3D12Fence fence = Device.CreateFence(0, FenceFlags.None);
        var @event = PInvoke.CreateEvent(null, false, false, (string)null);
        var queue = Device.CreateCommandQueue(CommandListType.Direct, nodeMask: 1);
        var cmdAllocator = Device.CreateCommandAllocator(CommandListType.Direct);
        var cmdList = Device.CreateCommandList<ID3D12GraphicsCommandList>(0, CommandListType.Direct, cmdAllocator, null);

        cmdList.CopyTextureRegion(dstLocation, 0, 0, 0, srcLocation, null);
        cmdList.ResourceBarrier(new ResourceBarrier(new ResourceTransitionBarrier(pTexture, ResourceStates.CopyDest, ResourceStates.PixelShaderResource)));
        cmdList.Close();

        queue.ExecuteCommandList(cmdList);
        queue.Signal(fence, 1);
        fence.SetEventOnCompletion(1, @event.DangerousGetHandle());
        PInvoke.WaitForSingleObject(@event, 0xFFFFFFFF);

        // Dispose
        cmdList.Dispose();
        cmdAllocator.Dispose();
        queue.Dispose();
        @event.Dispose();
        fence.Dispose();
        uploadBuffer.Dispose();

        var cpuHandle = new CpuDescriptorHandle();
        var gpuHandle = new GpuDescriptorHandle();
        _textureHeapAllocator.Alloc(ref cpuHandle, ref gpuHandle);

        // https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shader_component_mapping
        const int D3D12_DEFAULT_SHADER_4_COMPONENT_MAPPING = 0 & 0x7 | (1 & 0x7) << 3 | (2 & 0x7) << 3 * 2 | (3 & 0x7) << 3 * 3 | 1 << 3 * 4;
        Device.CreateShaderResourceView(pTexture, new ShaderResourceViewDescription()
        {
            Format = Format.R8G8B8A8_UNorm,
            ViewDimension = ShaderResourceViewDimension.Texture2D,
            Texture2D = new Texture2DShaderResourceView()
            {
                MipLevels = 1,
                MostDetailedMip = 0,
            },
            Shader4ComponentMapping = D3D12_DEFAULT_SHADER_4_COMPONENT_MAPPING
        }, cpuHandle);

        _textureIds.TryAdd((ulong)gpuHandle.Ptr, new TextureResource()
        {
            Resource = pTexture,
            CpuDescHandle = cpuHandle,
            GpuDescHandle = gpuHandle
        });

        return (ulong)gpuHandle.Ptr;
    }

    public void UpdateTexture(ulong gpuHandle, Span<byte> newBytes, uint width, uint height)
    {
        if (!_textureIds.TryGetValue(gpuHandle, out TextureResource? textureResource))
            throw new KeyNotFoundException("Could not find texture for update.");

        uint rowPitch = (uint)((width * BytesPerPixel + D3D12_TEXTURE_DATA_PITCH_ALIGNMENT - 1) & ~(D3D12_TEXTURE_DATA_PITCH_ALIGNMENT - 1));
        uint uploadSize = height * rowPitch;

        HeapProperties uploadProp = new HeapProperties(HeapType.Upload);
        ResourceDescription bufDesc = new ResourceDescription(ResourceDimension.Buffer, 0, uploadSize, 1, 1, 1, Format.Unknown, 1, 0, TextureLayout.RowMajor, ResourceFlags.None);
        ID3D12Resource upload = Device.CreateCommittedResource(uploadProp, HeapFlags.None, bufDesc, ResourceStates.GenericRead);

        // Copy
        nint mapped = 0;
        upload.Map(0, &mapped);
        fixed (byte* src = newBytes)
        {
            for (int y = 0; y < height; y++)
                Buffer.MemoryCopy(
                    src + y * width * BytesPerPixel,
                    (void*)(mapped + y * rowPitch),
                    width * BytesPerPixel,
                    width * BytesPerPixel);
        }
        upload.Unmap(0);

        var srcLoc = new TextureCopyLocation(upload, new PlacedSubresourceFootPrint()
        {
            Footprint = new SubresourceFootPrint()
            {
                Format = Format.R8G8B8A8_UNorm,
                Width = width,
                Height = height,
                Depth = 1,
                RowPitch = rowPitch
            }
        });
        var dstLoc = new TextureCopyLocation(textureResource.Resource, 0);

        // Build command list
        _textureUploadCommandAllocator ??= Device.CreateCommandAllocator(CommandListType.Direct);
        _textureUploadCommandList ??= Device.CreateCommandList<ID3D12GraphicsCommandList>(CommandListType.Direct, _textureUploadCommandAllocator);
        _textureUploadCommandList.ResourceBarrier(new ResourceBarrier(new ResourceTransitionBarrier(textureResource.Resource, ResourceStates.PixelShaderResource, ResourceStates.CopyDest)));
        _textureUploadCommandList.CopyTextureRegion(dstLoc, 0, 0, 0, srcLoc, null);
        _textureUploadCommandList.ResourceBarrier(new ResourceBarrier(new ResourceTransitionBarrier(textureResource.Resource, ResourceStates.CopyDest, ResourceStates.PixelShaderResource)));
        _textureUploadCommandList.Close();

        // Execute
        _textureUploadCommandQueue ??= Device.CreateCommandQueue(CommandListType.Direct);

        _textureUploadFence ??= Device.CreateFence(0, FenceFlags.None);
        ulong signal = ++_fenceValue;

        _textureUploadCommandQueue.ExecuteCommandList(_textureUploadCommandList);
        _textureUploadCommandQueue.Signal(_textureUploadFence, signal);

        _textureUploadFence.SetEventOnCompletion(signal);
        //fence.CompletedValue = signal;

        upload.Dispose();
        _textureUploadCommandAllocator.Reset();
        _textureUploadCommandList.Reset(_textureUploadCommandAllocator, null);
    }

    public bool IsTextureLoaded(ulong texId)
    {
        return _textureIds.ContainsKey(texId);
    }

    public void FreeTexture(ulong texId)
    {
        if (!_textureIds.TryGetValue(texId, out TextureResource? textureHandle))
            throw new KeyNotFoundException("Texture was not found.");

        textureHandle.Dispose();
        _textureIds.TryRemove(texId, out _);
    }
    #endregion
}

public unsafe class ImguiHookDx12Wrapper
{
    public static DX12BackendHook Instance { get; set; }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SrvDescriptorAllocCallback(ImGui_ImplDX12_InitInfo_t* initInfo, CpuDescriptorHandle* cpuHandle, GpuDescriptorHandle* gpuHandle) => Instance.SrvDescriptorAllocCallback(initInfo, cpuHandle, gpuHandle);

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SrvDescriptorFreeCallback(ImGui_ImplDX12_InitInfo_t* initInfo, CpuDescriptorHandle cpuHandle, GpuDescriptorHandle gpuHandle) => Instance.SrvDescriptorFreeCallback(initInfo, cpuHandle, gpuHandle);

    #region Hook Functions
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
    public static nint ResizeBuffersImplStatic(nint swapchainPtr, uint bufferCount, uint width, uint height, Format newFormat, SwapChainFlags swapchainFlags) => Instance.ResizeBuffersImpl(swapchainPtr, bufferCount, width, height, newFormat, swapchainFlags);

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
    public static nint CreateSwapChainForHwndImplStatic(nint this_, nint pDevice, nint hWnd, SwapChainDescription* pDesc, SwapChainFullscreenDescription* pFullscreenDesc, nint pRestrictToOutput, nint ppSwapChain) => Instance.CreateSwapChainForHwndImpl(this_, pDevice, hWnd, pDesc, pFullscreenDesc, pRestrictToOutput, ppSwapChain);

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
    public static nint PresentImplStatic(nuint swapChainPtr, int syncInterval, PresentFlags flags) => Instance.PresentImpl(swapChainPtr, syncInterval, flags);
    #endregion
}

class FrameContext
{
    public ID3D12Resource? MainRenderTargetResource;
    public CpuDescriptorHandle MainRenderTargetDescriptor;

    public void Reset()
    {
        MainRenderTargetResource?.Dispose();
    }
};

// For ImGui
public unsafe partial struct ImGui_ImplDX12_InitInfo_t
{
    public nint Device;
    public nint CommandQueue;
    public int NumFramesInFlight;
    public int RTVFormat;
    public int DSVFormat;
    public void* UserData;
    public nint SrvDescriptorHeap;
    public delegate* unmanaged[Cdecl]<ImGui_ImplDX12_InitInfo_t*, CpuDescriptorHandle*, GpuDescriptorHandle*, void> SrvDescriptorAllocFn;
    public delegate* unmanaged[Cdecl]<ImGui_ImplDX12_InitInfo_t*, CpuDescriptorHandle, GpuDescriptorHandle, void> SrvDescriptorFreeFn;
    public nint LegacySingleSrvCpuDescriptor;
    public nint LegacySingleSrvGpuDescriptor;
}