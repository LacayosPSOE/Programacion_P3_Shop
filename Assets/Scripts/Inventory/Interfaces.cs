// SOLID: Interfaces

public interface IPickUp 
{
    void PickUp(ICanBePicked item);
}

public interface ICanBePicked
{
    void PickedUp();
    ItemBasic GetItem();
}

public interface IConsume
{
    void Use(ConsumableItem item);
}
