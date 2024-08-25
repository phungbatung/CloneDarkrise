using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory
{
    public int itemId { get; set; }
    public int amount { get; set; }

    public Dictionary<string, string> properties;
    public ItemInventory()
    {
        itemId = -1;
        amount = 0;
        properties = new Dictionary<string, string>();
    }
    public ItemInventory(int _itemId, int _amount, Dictionary<string, string> _properties)
    {
        itemId= _itemId;
        amount= _amount;
        properties = _properties;
    }
    public void AddItem(int _id, int _amount = 1, Dictionary<string, string> _properties = null)
    {
        if (itemId == -1)
            itemId = _id;
        if (_properties != null)
            properties = _properties;
        amount += _amount;
    }
    public void AddItem(int _id, Dictionary<string, string> _properties = null)
    {
        if (itemId == -1)
            itemId = _id;
        if (_properties != null)
            properties = _properties;
        amount++;
    }
    public void RemoveItem(int _amount = 1)
    {
        amount -= _amount;
        if (amount <= 0)
            itemId = -1;
        if (amount <= 0)
        {
            itemId = -1;
            properties.Clear();
        }
    }
    public void RemoveAll()
    {
        amount = 0;
        itemId = -1;
        properties.Clear();
    }
    public bool IsEmpty()
    {
        return itemId == -1;
    }
    public bool CanBeAdded(int _addAmount = 1)
    {
        return amount + _addAmount <= Inventory.Instance.itemDict[itemId].maxSize;
    }

    public static int CompareByItemId(ItemInventory itemInventory1, ItemInventory itemInventory2)
    {
        if (itemInventory1.itemId == -1 && itemInventory2.itemId != -1) return 1;
        if (itemInventory1.itemId != -1 && itemInventory2.itemId == -1) return -1;
        if (itemInventory1.itemId == -1 && itemInventory2.itemId == -1) return 0;
        ItemData item1 = Inventory.Instance.itemDict[itemInventory1.itemId];
        ItemData item2 = Inventory.Instance.itemDict[itemInventory2.itemId];
        if (item1.type > item2.type) return 1;
        if (item1.type < item2.type) return -1;
        if (item1.quality < item2.quality) return 1;
        if (item1.quality > item2.quality) return -1;
        return 0;
    }
    public static int CompareByItemQuality(ItemInventory itemInventory1, ItemInventory itemInventory2)
    {
        if (itemInventory1.itemId == -1 && itemInventory2.itemId != -1) return 1;
        if (itemInventory1.itemId != -1 && itemInventory2.itemId == -1) return -1;
        if (itemInventory1.itemId == -1 && itemInventory2.itemId == -1) return 0;
        ItemData item1 = Inventory.Instance.itemDict[itemInventory1.itemId];
        ItemData item2 = Inventory.Instance.itemDict[itemInventory2.itemId];
        if (item1.quality < item2.quality) return 1;
        if (item1.quality > item2.quality) return -1;
        if (item1.type > item2.type) return 1;
        if (item1.type < item2.type) return -1;
        return 0;
    }
}
