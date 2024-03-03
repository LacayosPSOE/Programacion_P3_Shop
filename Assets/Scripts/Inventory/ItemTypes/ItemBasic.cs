using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory System/Items/Item")]
public class ItemBasic : ScriptableObject
{
    public string _name;
    public Sprite _imageUI;
    public bool _isStackable;
    public int _cost = 20;
}