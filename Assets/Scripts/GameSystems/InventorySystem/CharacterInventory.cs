using UnityEngine;

public class CharacterInventory : MonoBehaviour, IHaveInventory
{
    [SerializeField] private InventorySO chatacterInventory;  

    public void PickUpItem(ICollectableItem item)
    {
        chatacterInventory.PickUpItem(item);
    }
}
