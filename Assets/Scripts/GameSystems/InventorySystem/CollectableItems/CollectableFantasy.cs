using UnityEngine;

public class CollectableFantasy : BaseCollectabeItem, IProduct
{
    [Header("FantasyData")]
    [SerializeField] private FloatValueSO fantasyBonus;
    [SerializeField] private FloatValueSO playerCurrentFantasyLevel;
    [SerializeField] private GameEventSO onFantasyLevelIncreased;

    private Rigidbody2D rb;

    public override void PickUp(IHaveInventory inventory)
    {
        inventory.PickUpItem(this);

        playerCurrentFantasyLevel.runtimeValue += fantasyBonus.initialValue;
        onFantasyLevelIncreased?.TriggerEvent();

        gameObject.SetActive(false);
    }

    public void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
    }
}
