using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using NenTools.ImGui.Abstractions;
using NenTools.ImGui.Hooks;
using NenTools.ImGui.Interfaces;
using NenTools.ImGui.Native;
using NenTools.ImGui.Shell.Windows;

using Reloaded.Hooks.Definitions;

using TextCopy;

namespace NenTools.ImGui.Shell;

public class ImGuiShell : IImGuiShell
{
    private readonly IReloadedHooks _hooks;
    private readonly IImGui _imGui;
    private readonly IBackendHook _imguiHook;
    private readonly ImGuiShellConfig _imGuiConfig;

    public IImGuiTextureManager TextureManager { get; }

    private bool _menuVisible;

    private List<IImGuiComponent> _components = [];

    public event IImGuiShell.OnImGuiConfigurationDelegate? OnImGuiConfiguration;
    public event IImGuiShell.OnFirstRenderDelegate? OnFirstRender;
    public event IImGuiShell.OnEndMainMenuBarRenderDelegate? OnEndMainMenuBarRender;
    public event IImGuiShell.OnLogMessageDelegate? OnLogMessage;

    // Categories
    //  top menu categories (for sorting)
    //  -> groups of component lists, grouped by priority
    //    -> list of components, ordered by name
    private readonly Dictionary<string, SortedList<int, SortedDictionary<string, List<IImGuiComponent>>>> _menuCategoryToComponentList = [];

    public const int SystemPriority = -1000;

    public bool ContextCreated { get; private set; } = false;
    public bool IsOverlayEnabled { get; private set; } = false;

    public bool MouseActiveWhileMenuOpen { get; private set; } = true;
    public bool IsMainMenuOpen => _menuVisible;

    public string FileMenuName => "File";
    public string ModsMenuName => "Mods";
    public string OtherMenuName => "Other";

    public bool _initialized = false;

    private OverlayLogger _overlayLogger;

    public ImGuiShell(IReloadedHooks hooks, IBackendHook backendHook, IImGui imgui, ImGuiShellConfig imGuiConfig, ILoggerFactory? loggerFactory = null)
    {
        _hooks = hooks;
        _imguiHook = backendHook; 
        _imGui = imgui;
        _imGuiConfig = imGuiConfig;

        _overlayLogger = new OverlayLogger(_imGui, _imGuiConfig);
        TextureManager = new ImGuiTextureManager(backendHook, loggerFactory);
    }

    public void DisableOverlay() => IsOverlayEnabled = false;
    public void EnableOverlay() => IsOverlayEnabled = true;

    public void HideMenu() => SetMenuState(false);
    public void ShowMenu() => SetMenuState(true);
    public void ToggleMenuState() => SetMenuState(!_menuVisible);

    private void SetMenuState(bool visible)
    {
        _menuVisible = visible;

        // This will block WndProc from passing WM_SETCURSOR events to the game
        // This is useful to avoid having the game override ImGui's cursor sets
        ImguiHook.BlockSetCursor = visible;

        if (ContextCreated)
        {
            // Ensure to alert ImGui not to do any cursor changes if the cursor is not visible
            // Otherwise if the menu is hidden, ImGui may try to apply changes which will may cause cursor flicker.
            // This is not really needed anymore with WM_SETCURSOR being blocked, but still - at least ImGui won't unnecessarily
            // trigger events and waste cycles.
            if (_menuVisible)
                _imGui.GetIO().ConfigFlags &= ~ImGuiConfigFlags.ImGuiConfigFlags_NoMouseCursorChange;
            else
                _imGui.GetIO().ConfigFlags |= ImGuiConfigFlags.ImGuiConfigFlags_NoMouseCursorChange;
        }
    }

    /// <summary>
    /// Creates and starts the ImGui context/rendering.
    /// </summary>
    /// <returns></returns>
    public async Task Start(BackendHookOptions hookOptions)
    {
        SDK.Init(_hooks, debug => OnLogMessage?.Invoke(debug, Color.White));

        HideMenu();

        await ImguiHook.Create(_imGui, Render, hookOptions);
        ContextCreated = true;

        _menuCategoryToComponentList.TryAdd(FileMenuName, []);
        _menuCategoryToComponentList.TryAdd(ModsMenuName, []);
        _menuCategoryToComponentList.TryAdd(OtherMenuName, []);

        AddComponent(new DemoWindow(_imGui));
        AddComponent(_overlayLogger);

        OnImGuiConfiguration?.Invoke();

        _imguiHook.OnBackendInitialized += OnBackendInitialized;
        _initialized = true;
    }

    /// <summary>
    /// Shuts down the shell and ImGui overlay.
    /// </summary>
    public void Shutdown()
    {
        DisableOverlay();

        ImguiHook.Destroy();
        ContextCreated = false;

        _menuCategoryToComponentList.Clear();
        OnImGuiConfiguration = null;

        _imGui.DisposeCallbackHandles();
        _initialized = false;
    }

    private void OnBackendInitialized()
    {
        _imGui.DisposeCallbackHandles();

        // May be a ImGui bug/oversight (as of 1.92.5)?
        // When we initialize imgui for the first time with ImGui::CreateContext, it sets DEFAULT implementations for these functions after calling ImGui::CreateContext
        // - Platform_GetClipboardTextFn
        // - Platform_SetClipboardTextFn
        // - Platform_OpenInShellFn
        // - Platform_SetImeDataFn
        // PROBLEM: We deinit ImGui with ImGui_ImplWin32_Shutdown which calls ClearPlatformHandlers, and sets all platform callbacks to null.
        // We genuinely do not have a way to set the default implementations again without calling CreateContext again..

        // It is valid behavior to call CreateContext when there is already a context (it will create a context, and then restore the old one)
        // But something about this doesn't seem right.

        // What we do then, is register our own functions based on those default implementations
        // (technically we could grab the default implementations before ImGui_ImplWin32_Shutdown is called, but we don't have easy access to that.)
        var platformIo = _imGui.GetPlatformIO();
        platformIo.AddOpenInShellCallback(OpenInShell);
        platformIo.AddGetClipboardTextCallback(GetClipboardText);
        platformIo.AddSetClipboardTextCallback(SetClipboardText);
        // TODO Platform_SetImeDataFn
    }

    private static string? GetClipboardText(IImGuiContext context)
    {
        return ClipboardService.GetText();
    }

    private static unsafe void SetClipboardText(IImGuiContext context, ReadOnlySpan<byte> path)
    {
        string str = Encoding.UTF8.GetString(path);
        ClipboardService.SetText(str);
    }

    private static bool OpenInShell(IImGuiContext context, ReadOnlySpan<byte> path)
    {
        string str = Encoding.UTF8.GetString(path);
        Process? process = Process.Start(new ProcessStartInfo
        {
            FileName = str,
            UseShellExecute = true,
            WindowStyle = ProcessWindowStyle.Normal,
        });
        
        return process is not null;
    }

    public void AddComponent(IImGuiComponent component, string? overrideCategory = null, int overridePriority = 0, string? overrideOwner = null)
    {
        ImGuiMenuAttribute? attr = component.GetType().GetCustomAttribute<ImGuiMenuAttribute>();
        string? category = !string.IsNullOrEmpty(overrideCategory) ? overrideCategory : attr?.Category;
        int priority = overridePriority != 0 ? overridePriority : attr?.Priority ?? 0;
        string? owner = !string.IsNullOrEmpty(overrideOwner) ? overrideOwner : attr?.Owner;

        if (!string.IsNullOrEmpty(category))
        {
            if (!_menuCategoryToComponentList.TryGetValue(category, out var priorityGroup))
            {
                priorityGroup = [];
                _menuCategoryToComponentList.TryAdd(category, priorityGroup);
            }

            if (!priorityGroup.TryGetValue(priority, out var componentBucket))
            {
                componentBucket = [];
                priorityGroup.TryAdd(priority, componentBucket);
            }

            owner ??= "<unnamed>";
            if (!componentBucket.TryGetValue(owner, out List<IImGuiComponent>? components))
            {
                components = [];
                componentBucket.Add(owner, components);
            }

            components.Add(component);
        }

        _components.Add(component);
    }


    public void AddMenuSeparator(string? displayName, string category, int priority, string orderString)
    {
        ArgumentException.ThrowIfNullOrEmpty(category, nameof(category));
        ArgumentException.ThrowIfNullOrEmpty(orderString, nameof(orderString));

        AddComponent(new ImGuiSeparator(_imGui, displayName), category, priority, orderString);
    }

    private bool _firstRendered = false;
    private void Render()
    {
        if (!IsOverlayEnabled)
            return;

        // Test zone
        // TestImGui();

        if (!_firstRendered)
        {
            if (_menuVisible)
                _imGui.GetIO().ConfigFlags &= ~ImGuiConfigFlags.ImGuiConfigFlags_NoMouseCursorChange;
            else
                _imGui.GetIO().ConfigFlags |= ImGuiConfigFlags.ImGuiConfigFlags_NoMouseCursorChange;

            OnFirstRender?.Invoke();
            _firstRendered = true;
        }

        if (!_initialized)
            return;

        foreach (IImGuiComponent component in _components)
        {
            if (component.IsOverlay)
                component.Render(this);

            if (!_initialized) // Someone could have disabled overlay, return immediately.
                return;
        }

        if (!_menuVisible)
            return;

        if (_imGui.BeginMainMenuBar())
        {
            foreach (var mainMenuCategory in _menuCategoryToComponentList)
            {
                if (_imGui.BeginMenu(mainMenuCategory.Key))
                {
                    foreach (var prorityGroups in mainMenuCategory.Value)
                    {
                        foreach (var componentBucket in prorityGroups.Value)
                        {
                            foreach (IImGuiComponent component in componentBucket.Value)
                            {
                                component.RenderMenu(this);
                                if (!_initialized) // Someone could have disabled overlay, return immediately.
                                    return;
                            }
                        }
                    }

                    _imGui.EndMenu();
                }
            }

            OnEndMainMenuBarRender?.Invoke();
            if (!_initialized)
                return;

            _imGui.EndMainMenuBar();
        }

        if (!_initialized)
            return;

        foreach (var component in _components)
        {
            if (!component.IsOverlay)
            {
                component.Render(this);
                if (!_initialized)
                    return;
            }
        }
    }

    public void LogWriteLine(string source, string message, Color? color = null, LoggerOutputTargetFlags loggerTargetFlags = LoggerOutputTargetFlags.AllButOverlayLogger)
    {
        if (loggerTargetFlags.HasFlag(LoggerOutputTargetFlags.GeneralLoggers))
            OnLogMessage?.Invoke($"[{source}] {message}", color ?? null);

        if (loggerTargetFlags.HasFlag(LoggerOutputTargetFlags.OverlayLogger))
            _overlayLogger.AddMessage(source, message, color);
    }

    private unsafe void TestImGui()
    {
        IImGuiIO io = _imGui.GetIO();
        IImFontAtlas atlas = io.Fonts;
        foreach (IImFont font in atlas.Fonts)
        {

        }

        IImGuiPlatformIO platIo = _imGui.GetPlatformIO();
        IImVectorWrapper<IImGuiPlatformMonitor> monitors = platIo.Monitors;
        foreach (IImGuiPlatformMonitor monitor in monitors)
        {

        }
        IRangeStructAccessor<IImGuiKeyData> keys = io.KeysData;
        IImGuiKeyData key0 = keys[0];
        IImGuiKeyData key1 = keys[1];

        var builderStruct = new ImFontGlyphRangesBuilderStruct();
        var builder = new Implementation.ImGui.ImFontGlyphRangesBuilder(&builderStruct);
        _imGui.ImFontGlyphRangesBuilder_Clear(builder);
        _imGui.ImFontGlyphRangesBuilder_AddText(builder, "Hello World", null);
        _imGui.ImFontGlyphRangesBuilder_AddChar(builder, 0x7262);
        _imGui.ImFontGlyphRangesBuilder_AddRanges(builder, ref Unsafe.AsRef<uint>(_imGui.ImFontAtlas_GetGlyphRangesJapanese(io.Fonts)));
        _imGui.ImFontGlyphRangesBuilder_BuildRanges(builder, out var ranges);

        IImStructPtrVectorWrapper<IImTextureData> textures = platIo.Textures;
        IImTextureData texture = textures[0];

        IImDrawList drawList = _imGui.GetWindowDrawList();
        _imGui.ImDrawList_AddCircle(drawList, new Vector2(1.0f, 1.0f), 1, 0xFFFFFFFF);

        string version = _imGui.GetVersion();
        double time = _imGui.GetTime();
    }
}
