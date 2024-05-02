using System;
using UnityEngine;

public class GameEventStringListener : MonoBehaviour
{
    public GameEventStringSO gameEvent;
    private Action<string> response;

    public void OnEnabled(Action<string> response)
    {
        if (gameEvent != null) gameEvent.AddListener(this);
        this.response = response;
    }

    private void OnDisable()
    {
        if (gameEvent != null) gameEvent.RemoveListener(this);
    }

    public void OnEventTriggered(string message)
    {
        response?.Invoke(message);
    }
}
