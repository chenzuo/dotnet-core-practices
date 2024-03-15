using System.ComponentModel;

using Microsoft.SemanticKernel;

namespace Semantic_Kernel;

public class LightPlugin
{
    /// <summary>
    /// Tracks whether the light is currently on or off.
    /// </summary>
    public bool IsOn { get; set; } = false;

#pragma warning disable CA1024 // Use properties where appropriate

    /// <summary>
    /// Gets the current state of the light ("on" or "off").
    /// </summary>
    /// <returns>The string "on" if the light is on, or "off" if it's off.</returns>
    [KernelFunction]
    [Description("Gets the state of the light.")]
    public string GetState() => IsOn ? "on" : "off";

#pragma warning restore CA1024 // Use properties where appropriate

    /// <summary>
    /// Changes the state of the light to the specified state.
    /// </summary>
    /// <param name="newState">The new state of the light (true for on, false for off).</param>
    /// <returns>The string "on" if the light is now on, or "off" if it's now off.</returns>
    [KernelFunction]
    [Description("Changes the state of the light.'")]
    public string ChangeState(bool newState)
    {
        this.IsOn = newState;
        var state = GetState();  // Retrieve the updated state

        // Log the state change to the console
        Console.WriteLine($"[Light is now {state}]");

        return state;
    }
}
