using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory Inventory;
    public InventoryUIElement ElementPrefab;
    public bool _isPlayer;

    private List<GameObject> _shownObjects;

    private void Start()
    {
        ShowInventory(Inventory);
    }

    private void OnEnable()
    {
        Inventory.OnInventoryChange += UpdateInventory;
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChange -= UpdateInventory;
    }

    private void UpdateInventory()
    {
        ClearInventory();
        ShowInventory(Inventory);
    }

    private void ClearInventory()
    {
        foreach (var item in _shownObjects)
        {
            if (item) Destroy(item);
        }

        _shownObjects.Clear();
    }

    private void ShowInventory(Inventory inventory)
    {
        if (_shownObjects == null) _shownObjects = new List<GameObject>();
        if (_shownObjects.Count > 0) ClearInventory();

        for (int i = 0; i < inventory.Length; i++)
        {
            _shownObjects.Add(MakeNewEntry(inventory.GetSlot(i)));
        }
    }

    private GameObject MakeNewEntry(InventorySlot inventorySlot)
    {
        var element = GameObject.Instantiate(ElementPrefab, Vector3.zero, Quaternion.identity, transform);
        element.SetStuff(inventorySlot, this);
        return element.gameObject;
    }

    public void ItemUsed(ItemBasic item)
    {
        Inventory.RemoveItem(item);
    }
}