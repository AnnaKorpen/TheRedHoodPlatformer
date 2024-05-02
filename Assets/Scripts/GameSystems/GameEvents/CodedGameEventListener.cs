using System;
using UnityEngine;

public class CodedGameEventListener : MonoBehaviour, IGameEventListener
{
    public GameEventSO gameEvent;

    private Action response;

    public void OnEnabled(Action response)
    {
        if (gameEvent != null) gameEvent.AddListener(this);
        this.response = response;
    }

    public void OnDisable()
    {
        if (gameEvent != null) gameEvent.RemoveListener(this);
    }

    public void OnEventTriggered()
    {
        response?.Invoke();
    }
}
