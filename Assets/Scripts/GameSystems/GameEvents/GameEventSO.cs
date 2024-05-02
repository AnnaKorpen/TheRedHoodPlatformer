using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Game Events/Game Event", order = 51)]
public class GameEventSO : ScriptableObject
{
    private List<IGameEventListener> listeners = new List<IGameEventListener>();

    public void TriggerEvent()
    {
        for (int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered();
        }
    }

    public void AddListener(IGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(IGameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
