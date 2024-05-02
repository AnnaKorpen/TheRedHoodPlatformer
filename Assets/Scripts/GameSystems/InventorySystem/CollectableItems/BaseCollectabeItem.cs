using UnityEngine;

public abstract class BaseCollectabeItem : MonoBehaviour, ICollectableItem
{
    [Header("ItemData")]
    [SerializeField] private GameObjectRuntimeSetSO itemRuntimeSet;
    [SerializeField] private ItemDataSO itemData;

    private void OnEnable()
    {
        itemRuntimeSet.Add(gameObject);
    }

    public string ItemName()
    {
        return itemData.itemName;
    }

    public abstract void PickUp(IHaveInventory inventory);
}
