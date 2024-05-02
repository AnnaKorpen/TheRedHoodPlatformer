
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Inventory System/Item Type", order = 51)]
public class ItemTypeSO: ScriptableObject 
{
    public ItemDataSO itemInType;
    public int itemQuantity;
}
