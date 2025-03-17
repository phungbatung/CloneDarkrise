using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySaveData 
{
    public int gold;
    public int diamond;
    public int inventorySize;
    public List<ItemInventory> inventoryItems;
    public int equipmentSize;
    public List<ItemInventory> equipedItems;
    
    public InventorySaveData() 
    {
        // For NewGame
        gold = 100000;
        diamond = 100000;
        inventorySize = 48;
        inventoryItems = new List<ItemInventory>();
        for (int i = 0; i < inventorySize; i++)
            inventoryItems.Add(new ItemInventory());
        equipedItems = new List<ItemInventory>();
    }
    public InventorySaveData(int _inventorySize, int _gold, int _diamond, List<ItemInventory> _inventoryItems, List<ItemInventory> _equipedItems) 
    { 
        inventorySize = _inventorySize;
        gold = _gold;
        diamond = _diamond;
        inventoryItems = _inventoryItems;
        equipedItems = _equipedItems;
    }

}
