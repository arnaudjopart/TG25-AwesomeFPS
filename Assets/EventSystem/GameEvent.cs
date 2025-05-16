using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameEvent", menuName = "Event System/GameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> _listeners = new List<GameEventListener>();
    public void SubscribeToEvent(GameEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnsubscribeFromEvent(GameEventListener listener)
    {
        _listeners.Remove(listener);
    }

    public void Raise()
    {
        for (var i = _listeners.Count-1; i >=0;i--)
        {
            _listeners[i].OnRaiseEvent();
        }
    }
}