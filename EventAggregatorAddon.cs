#if TOOLS
using Godot;
using System;

[Tool]
public class EventAggregatorAddon : EditorPlugin
{
    public override void _EnterTree()
    {
        var script = GD.Load<Script>("addons/EventAggregator/EventAggregator.cs");
        var texture = GD.Load<Texture>("addons/EventAggregator/EventAggregator.png");
        AddCustomType("EventAggregator","Node",script,texture);
    }

    public override void _ExitTree()
    {
        RemoveCustomType("EventAggregator");
    }
}
#endif