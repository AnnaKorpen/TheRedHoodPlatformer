using UnityEngine;

public class CollectableFantasyBust : BaseCollectabeItem, IProduct
{
    [Header("FantasyBustData")]
    [SerializeField] private FloatValueSO fantasyBustBonus;
    [SerializeField] private FloatValueSO playerCurrentFantasyLevel;
    [SerializeField] private GameEventSO onFantasyLevelIncreased;
    [SerializeField] private GameEventSO onFantasyBustCollected;

    private Rigidbody2D rb;

    public override void PickUp(IHaveInventory inventory)
    {
        inventory.PickUpItem(this);
        onFantasyBustCollected?.TriggerEvent();

        playerCurrentFantasyLevel.runtimeValue += fantasyBustBonus.initialValue;
        onFantasyLevelIncreased?.TriggerEvent();

        gameObject.SetActive(false);
    }

    public void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
    }
}
