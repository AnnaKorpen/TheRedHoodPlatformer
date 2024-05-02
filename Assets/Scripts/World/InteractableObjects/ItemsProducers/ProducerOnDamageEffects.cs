using UnityEngine;

[RequireComponent(typeof(ObjectHealth))]
[RequireComponent (typeof(CollectableItemsProducer))]
public class ProducerOnDamageEffects : MonoBehaviour
{
    [SerializeField] private FloatValueSO maxHealth;

    private ObjectHealth objectHealth;
    private CollectableItemsProducer itemsProducer;

    private int maxItemsToProduce;
    private float healthPerItem;
    private int itemsProduced;

    private void Awake()
    {
        if (objectHealth == null) 
        {
            objectHealth = GetComponent<ObjectHealth>();
        }

        if (itemsProducer == null)
        {
            itemsProducer = GetComponent<CollectableItemsProducer>();
        }

        SetItemsData();
    }

    private void SetItemsData()
    {
        maxItemsToProduce = itemsProducer.GetMaxItemsAmount();
        healthPerItem = maxHealth.initialValue / maxItemsToProduce;
    }

    public void ProduceItems()
    {
        // Count items to produce after damage (based on current health and amount of items already produced)
        int itemsAmount = (int) (((maxHealth.initialValue - objectHealth.currentHealth) / healthPerItem) - itemsProduced);
        
        itemsProducer.ProduceItems(itemsAmount);

        itemsProduced += itemsAmount;
     
    }
}
