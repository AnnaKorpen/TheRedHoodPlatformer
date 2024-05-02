using UnityEngine;

public class WorldStateSwitcher : MonoBehaviour
{
    [SerializeField] private WorldStateSO worldState;
    [SerializeField] private GameEventSO onRealWorld;
    [SerializeField] private GameEventSO onFantasyWorld;

    public void ChangeToRealWorld()
    {
        worldState.currentState = WorldStateSO.State.realWorld;
        onRealWorld?.TriggerEvent();
    }

    public void ChangeToFantasyWorld()
    {
        worldState.currentState = WorldStateSO.State.fantasyWorld;
        onFantasyWorld?.TriggerEvent();
    }

    public void ChangeWorldState()
    {
        if (worldState.currentState == WorldStateSO.State.realWorld)
        {
            ChangeToFantasyWorld();
        }
        else
        {
            ChangeToRealWorld();
        }
    }
}
