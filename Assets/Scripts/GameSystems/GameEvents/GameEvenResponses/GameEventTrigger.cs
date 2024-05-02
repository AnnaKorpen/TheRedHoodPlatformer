using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GameEventTrigger : MonoBehaviour
{
    [SerializeField] private bool triggerOnce;
    private bool gameEventTriggered;

    [SerializeField] private GameEventSO gameEvent;

    private void Awake()
    {
        gameEventTriggered = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameEvent == null) return;

        if (triggerOnce && gameEventTriggered) return;

        gameEventTriggered = true;
        gameEvent.TriggerEvent();
    }

}
