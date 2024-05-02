using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private List<GameObjectRuntimeSetSO> gameObjectRuntimeSets;
    [SerializeField] private InventorySO inventory;
    [SerializeField] private GameEventSO OnStartNewGame;

    private void Awake()
    {
        for (int i = 0; i < gameObjectRuntimeSets.Count; i++)
        {
            gameObjectRuntimeSets[i].Clear();
        }

        inventory.ClearInventory();
    }

    private void Start()
    {
        OnStartNewGame?.TriggerEvent();
    }
}
