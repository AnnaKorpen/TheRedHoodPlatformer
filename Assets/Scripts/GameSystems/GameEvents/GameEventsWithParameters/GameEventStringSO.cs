using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Game Events/Game Event With String", order = 51)]
public class GameEventStringSO : ScriptableObject
{
    private List<GameEventStringListener> listeners = new List<GameEventStringListener>();

    public void TriggerEvent(string message)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered(message);
        }
    }

    public void AddListener(GameEventStringListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(GameEventStringListener listener)
    {
        listeners.Remove(listener);
    }
}
