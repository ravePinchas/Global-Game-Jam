using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IMessageHandler : IEventSystemHandler
{
    public void HandleMessage(System.Type msgType, object data);
}

public class MessagingSystem<MessageType>
{
    static HashSet<GameObject> messageSubscribers = new HashSet<GameObject>();

    public static void Subscribe(GameObject obj)
    {
        messageSubscribers.Add(obj);
    }

    public static void SendMessage(object data = null)
    {
        foreach (GameObject targetGameObj in messageSubscribers)
        {
            ExecuteEvents.Execute<IMessageHandler>(targetGameObj, null, (obj, unusedEventData) => obj.HandleMessage(typeof(MessageType), data));
        }
    }
}
