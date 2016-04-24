using UnityEngine;
using System.Collections;

public class InventoryItem : ScriptableObject
{
    [SerializeField]
    private Sprite itemSprite;

    public Sprite ItemSprite
    {
        get { return itemSprite; }
        set { itemSprite = value; }
    }

    [SerializeField]
    private string itemName;

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
}