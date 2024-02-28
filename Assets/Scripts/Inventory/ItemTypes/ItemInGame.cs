using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemInGame : MonoBehaviour, ICanBePicked
{
    public ItemBasic Item;

    private Canvas _canvas;
    private GraphicRaycaster _raycaster;
    private Transform _parent;
    private ItemBasic _item;
    private InventoryUI _inventory;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _parent = transform.parent;

        // Start moving object from the beginning!
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0)
            / transform.lossyScale.x; // Thanks to the canvas scaler we need to devide pointer delta by canvas scale to match pointer movement.

        // We need a few references from UI
        if (!_canvas)
        {
            _canvas = GetComponentInParent<Canvas>();
            _raycaster = _canvas.GetComponent<GraphicRaycaster>();
        }

        // Change parent of our item to the canvas
        transform.SetParent(_canvas.transform, true);

        // And set it as last child to be rendered on top of UI
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Continue moving object around screen
        transform.localPosition +=
            new Vector3(eventData.delta.x, eventData.delta.y, 0) /
            transform.lossyScale.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Find objects within canvas
        var results = new List<RaycastResult>();
        _raycaster.Raycast(eventData, results);
        foreach (var hit in results)
        {
            Debug.Log(hit.gameObject.name);
        }

        // Find scene objects
        RaycastHit2D hitData = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if (hitData)
        {
            var consumer = hitData.collider.GetComponent<IConsume>();
            bool consumable = _item is ConsumableItem;

            if ((consumer != null) && consumable)
            {
                (_item as ConsumableItem).Use(consumer);
                _inventory.ItemUsed(_item);
            }

            // Changing parent to new inventory
            transform.SetParent(hitData.transform);
        }

        // And centering item position
        transform.localPosition = Vector3.zero;
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