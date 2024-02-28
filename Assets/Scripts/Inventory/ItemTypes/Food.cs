using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory System/Items/HealthPotion")]
public class Food : ConsumableItem
{
    public int HealthPoints;

    public override void Use(IConsume consumer)
    {
        consumer.Use(this);
    }
}