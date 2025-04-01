using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemInventory
{
    public int itemId;
    public int amount;
    public EquipmentProperties equipmentProperties;


    public ItemInventory()
    {
        itemId = -1;
        amount = 0;
    }

    public ItemInventory(int _itemId, int _amount, EquipmentProperties _equipmentProperties)
    {
        itemId = _itemId;
        amount = _amount;
        equipmentProperties = _equipmentProperties;
    }

    public void AddItem(int _id, int _amount = 1)
    {
        if (itemId == -1)
            itemId = _id;
        amount += _amount;
    }
    public void AddItem(int _id, Dictionary<string, string> _properties = null)
    {
        if (itemId == -1)
            itemId = _id;

        if (_properties != null)
        {
            equipmentProperties = new(ItemUtilities.GetBaseProperties(_id) ,_properties);
        }
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
            equipmentProperties = null;
        }
    }
    public void RemoveAll()
    {
        amount = 0;
        itemId = -1;
        equipmentProperties = null;
    }
    public bool IsEmpty()
    {
        return itemId == -1;
    }
    public bool CanBeAdded(int _itemId, int _addAmount = 1)
    {
        return itemId == _itemId && amount + _addAmount <= ItemManager.Instance.itemDict[itemId].maxSize;
    }


    public static void Swap(ref ItemInventory item1, ref ItemInventory item2)
    {
        ItemInventory temp = item1;
        item1 = item2;
        item2 = temp;
    }
    public static void SwapValue(ItemInventory item1, ItemInventory item2)
    {
        if(item1 == null)
        {
            Debug.Log("item1 is null");
        }
        if (item2 == null)
        {
            Debug.Log("item2 is null");
        }
        (item1.itemId, item2.itemId) = (item2.itemId, item1.itemId);
        (item1.amount, item2.amount) = (item2.amount, item1.amount);
        (item1.equipmentProperties, item2.equipmentProperties) = (item2.equipmentProperties, item1.equipmentProperties);
    }
    public void Clone(ItemInventory _itemInventory)
    {
        itemId = _itemInventory.itemId;
        amount = _itemInventory.amount;
        equipmentProperties = _itemInventory.equipmentProperties;
    }
    public static int CompareByItemType(ItemInventory itemInventory1, ItemInventory itemInventory2)
    {
        if (itemInventory1.itemId == -1 && itemInventory2.itemId != -1) return 1;
        if (itemInventory1.itemId != -1 && itemInventory2.itemId == -1) return -1;
        if (itemInventory1.itemId == -1 && itemInventory2.itemId == -1) return 0;
        ItemData item1 = ItemManager.Instance.itemDict[itemInventory1.itemId];
        ItemData item2 = ItemManager.Instance.itemDict[itemInventory2.itemId];
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
        ItemData item1 = ItemManager.Instance.itemDict[itemInventory1.itemId];
        ItemData item2 = ItemManager.Instance.itemDict[itemInventory2.itemId];
        if (item1.quality < item2.quality) return 1;
        if (item1.quality > item2.quality) return -1;
        if (item1.type > item2.type) return 1;
        if (item1.type < item2.type) return -1;
        return 0;
    }
}
