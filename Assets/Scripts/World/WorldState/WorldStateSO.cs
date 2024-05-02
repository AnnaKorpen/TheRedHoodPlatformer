using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/World/World State", order = 51)]
public class WorldStateSO : ScriptableObject
{
    public enum State
    {
        realWorld,
        fantasyWorld,
    }

    public State currentState;
}
