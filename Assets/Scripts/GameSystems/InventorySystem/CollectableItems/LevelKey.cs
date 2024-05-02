using UnityEngine;

public class LevelKey : BaseCollectabeItem
{
    [SerializeField] private GameEventSO onKeyCollected;

    public override void PickUp(IHaveInventory inventory)
    {
        inventory.PickUpItem(this);

        onKeyCollected?.TriggerEvent();

        gameObject.SetActive(false);
    }
}
