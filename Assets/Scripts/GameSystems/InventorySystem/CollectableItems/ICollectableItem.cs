
public interface ICollectableItem
{
    public string ItemName();
    public void PickUp(IHaveInventory inventory);
}
