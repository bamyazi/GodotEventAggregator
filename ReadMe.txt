This addon is based on the EventAggregator from the Microsoft Prism Framework
https://github.com/PrismLibrary/Prism/tree/master/Source/Prism/Events
I have removed the WPF specific parts to make it compatible with Godot.
For information on how to use this the documentation is available here
https://prismlibrary.github.io/docs/event-aggregator.html

This version does not support the thread options from the original, all events will be triggered
on the thread from which they were published. This 'may' cause issues if the event is published 
from within the physics process ? - i don't quite understand the internals of Godot enough yet to
determine if this is an issue.

Add the node under your 'Root'
and use it like...

private EventAggregator _eventAggregator;

public override void _Ready() {
  _eventAggregator = (EventAggregator) GetTree().GetRoot().GetNode("Root/EventAggregator");
  _eventAggregator.GetEvent<StringNotificationEvent>().Subscribe(onStringNotification);
}
  
public void onStringNotification(StringNotificationEventArgs args) {
  GD.Print($"IT FECKIN WORKS: {args.Notification}");
}

and to publish an event

_eventAggregator.GetEvent<StringNotificationEvent>().Publish(new StringNotificationEventArgs("Hello world!"));
