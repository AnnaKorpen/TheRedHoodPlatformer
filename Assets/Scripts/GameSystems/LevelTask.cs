using UnityEngine;

public class LevelTask : MonoBehaviour
{
    [SerializeField] private GameObjectRuntimeSetSO levelKeysSet;
    [SerializeField] private InventorySO playerInventory;
    [SerializeField] private ItemDataSO key;

    [SerializeField] private GameEventSO onLevelTaskCmpleted;

    public void CheckLevelGoal()
    {
        if (levelKeysSet.Items.Count > 0 && (playerInventory.ShowItem(key.itemName).itemQuantity == levelKeysSet.Items.Count))
        {
            onLevelTaskCmpleted?.TriggerEvent();
            Debug.Log("Goal is achieved");
        }
    }
}
