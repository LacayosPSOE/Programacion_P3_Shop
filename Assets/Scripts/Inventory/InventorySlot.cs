using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot 
{
    public int Amount => _amount;
    public ItemBasic Item => _item;

    [SerializeField]
    private ItemBasic _item;
    [SerializeField]
    private int _amount;

    public InventorySlot(ItemBasic item)
    {
        this._item = item;
        _amount = 1;
    }

    internal bool HasItem(ItemBasic item)
    {
        return item == _item;
    }

    internal bool CanHold(ItemBasic item)
    {
        if (item.IsStackable) return (item == _item);

        return false;
    }

    internal void AddOne()
    {
        _amount++;
    }

    internal void RemoveOne()
    {
        _amount--;
    }

    public bool IsEmpty()
    {
        return _amount < 1;
    }
}


