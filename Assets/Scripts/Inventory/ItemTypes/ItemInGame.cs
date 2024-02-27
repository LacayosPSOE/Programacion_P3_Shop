using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInGame: MonoBehaviour, ICanBePicked
{
    public ItemBasic Item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var picker = other.GetComponent<IPickUp>();

        if (picker != null)
        {
            picker.PickUp(this);
            PickedUp();
        }
    }

    public void PickedUp()
    {
        Destroy(gameObject);
    }

    public ItemBasic GetItem()
    {
        return Item;
    }
}
