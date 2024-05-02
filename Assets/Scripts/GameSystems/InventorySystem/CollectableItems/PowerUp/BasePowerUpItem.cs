using System.Collections;
using UnityEngine;

public abstract class BasePowerUpItem : BaseCollectabeItem
{
    [Header("PowerUpData")]
    public GameEventSO onPowerUpStart;
    public GameEventSO onPowerUpEnd;
    public GameObject spriteObject;

    private bool isCollectable;

    private void Awake()
    {
        isCollectable = true;
    }

    public override void PickUp(IHaveInventory inventory)
    {
        if (isCollectable)
        {
            inventory.PickUpItem(this);

            spriteObject.SetActive(false);
            isCollectable = false;

            StartCoroutine(StartPowerUp());
        }
    }

    public abstract IEnumerator StartPowerUp();
}
