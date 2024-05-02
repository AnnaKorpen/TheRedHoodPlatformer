using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    public GameEventSO gameEvent;
    public UnityEvent response;

    private void OnEnable()
    {
        if (gameEvent != null) gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        if (gameEvent != null) gameEvent.RemoveListener(this);
    }

    public void OnEventTriggered()
    {
        response?.Invoke();
    }
}
