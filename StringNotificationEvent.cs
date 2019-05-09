using Godot;
using System;


public class StringNotificationEventArgs {
    public string Notification { get; set; }

     public StringNotificationEventArgs(string notification) {
        Notification = notification;
    }
}
public class StringNotificationEvent : PubSubEvent<StringNotificationEventArgs>
{

}
