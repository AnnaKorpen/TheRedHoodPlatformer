using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Inventory System/Inventory", order = 51)]
public class InventorySO : ScriptableObject
{
    public List<ItemTypeSO> itemTypes;

    public void PickUpItem(ICollectableItem item)
    {
        ItemTypeSO itemType = FindItemType(item);

        if (itemType != null)
        {
            itemType.itemQuantity += 1;
        }
    }

    public ItemTypeSO ShowItem(string itemName)
    {
        for (int i = 0; i < itemTypes.Count; i++)
        {
            if (itemTypes[i].itemInType.itemName == itemName)
            {
                return itemTypes[i];
            }
        }

        return null;
    }

    public void ClearInventory()
    {
        for (int i = 0; i < itemTypes.Count; i++)
        {
            itemTypes[i].itemQuantity = 0;
        }
    }

    private ItemTypeSO FindItemType(ICollectableItem item)
    {
        for (int i = 0; i < itemTypes.Count; i++)
        {
            if (itemTypes[i].itemInType.itemName == item.ItemName())
            {
                return itemTypes[i];
            }
        }

        return null;
    }
}
