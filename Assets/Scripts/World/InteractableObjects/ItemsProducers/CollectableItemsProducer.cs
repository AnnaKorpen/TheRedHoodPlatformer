using UnityEngine;

public class CollectableItemsProducer : BaseItemsProducer
{
    [SerializeField] private ObjectPool productPool;

    public void ProduceMaxItems()
    {
        ProduceItems(productPool.GetObjectAmount());
    }

    public override void ProduceItems(int itemsNumber)
    {
        for (int i = 0; i < itemsNumber; i++)
        {
            ProduceItem();
        }
    }

    private void ProduceItem()
    {
        GameObject productGameObject = productPool.GetPooledObject();

        if (productGameObject == null) return;

        IProduct product = productGameObject.GetComponent<IProduct>();

        if (product != null)
        {
            productGameObject.SetActive(true);
            productGameObject.transform.position = transform.position;
            product.Initialize();
        }
    }

    public int GetMaxItemsAmount()
    {
        return productPool.GetObjectAmount();
    }
}
