using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// Implements <see cref="IEventAggregator"/>.
/// </summary>
public class EventAggregator : Node
{
    private readonly Dictionary<Type, EventBase> events = new Dictionary<Type, EventBase>();

    /// <summary>
    /// Gets the single instance of the event managed by this EventAggregator. Multiple calls to this method with the same <typeparamref name="TEventType"/> returns the same event instance.
    /// </summary>
    /// <typeparam name="TEventType">The type of event to get. This must inherit from <see cref="EventBase"/>.</typeparam>
    /// <returns>A singleton instance of an event object of type <typeparamref name="TEventType"/>.</returns>
    public TEventType GetEvent<TEventType>() where TEventType : EventBase, new()
    {
        lock (events)
        {
            EventBase existingEvent = null;

            if (!events.TryGetValue(typeof(TEventType), out existingEvent))
            {
                TEventType newEvent = new TEventType();
                events[typeof(TEventType)] = newEvent;

                return newEvent;
            }
            else
            {
                return (TEventType)existingEvent;
            }
        }
    }

    public override void _EnterTree() 
    {

    }

    public override void _ExitTree() 
    {

    }    
}

