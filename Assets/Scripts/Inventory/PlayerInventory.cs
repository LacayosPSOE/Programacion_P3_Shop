using UnityEngine;

public class PlayerInventory : MonoBehaviour, IPickUp
{
    public Inventory Inventory;
    public int _money;
    public void PickUp(ICanBePicked item)
    {
        Inventory.AddItem(item.GetItem());
    }
}