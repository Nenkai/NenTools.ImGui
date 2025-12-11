using System.Collections.Generic;

namespace NenTools.ImGui.Abstractions;

public class BackendHookOptions
{
    /// <summary>
    /// <b>NOT CURRENTLY FUNCTIONAL</b><br/>
    /// [Experimental! + Initialisation Only!]<br/>
    /// <br/>
    /// Enables the viewports feature of Dear ImGui; which puts individual ImGui windows onto invisible windows, allowing
    /// them to escape the program region/area.
    /// </summary>
    public bool EnableViewports { get; set; } = false;

    /// <summary>
    /// [Real Time]<br/>
    /// Tries to suppress window deactivation message to the application/game.
    /// Sometimes necessary to stop the application from pausing when <see cref="EnableViewports"/> is turned on.
    /// </summary>
    public bool IgnoreWindowUnactivate { get; set; } = false;

    /// <summary>
    /// The individual list of implementations.
    /// </summary>
    public List<IBackendHook> Implementations { get; set; }
}
