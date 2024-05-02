using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent (typeof(ICollectableItem))]
public class PickUpTrigger : MonoBehaviour
{
    private ICollectableItem collectableItem;

    private void Start()
    {
        collectableItem = GetComponent<ICollectableItem>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        IHaveInventory inventory = other.gameObject.GetComponentInParent<IHaveInventory>();

        if (inventory != null)
        {
            collectableItem.PickUp(inventory);
        }
    }
}
