using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;


    public ItemDatabase itemDatabase;

    public Transform itemSlotsParent;
    public List<ItemSlot> inventorySlots;

    public Transform equipmentSlotsParent;
    public List<ItemSlot> equipmentSlots;

    public Transform moveItem;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        inventorySlots = itemSlotsParent.GetComponentsInChildren<ItemSlot>().ToList();
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<ItemSlot>().ToList();
    }


    public void AddItem(int _itemId, Dictionary<string, string> properties = null)
    {
        //Try to add item to available slot
        List<ItemSlot> slots = GetItemSlotByItemId(_itemId);
        foreach (var slot in slots)
        {
            if (slot.CanBeAdded())
            {
                slot.AddItem(_itemId, properties);
                return;
            }
        }
        //Add item to first empty slot
        foreach (ItemSlot slot in inventorySlots)
        {
            if (slot.IsEmpty())
            {
                slot.AddItem(_itemId, 1, properties);
                return;
            }
        }

        Debug.Log("Inventory is full.");
    }
    public void RemoveItem()
    {

    }

    public void EquipItem(ItemSlot _itemSlot)
    {
        ItemSlot slotToEquip = equipmentSlots[GetEquipmentTypeById(_itemSlot.itemId)];
        if (slotToEquip.itemId != -1)
            PlayerManager.Instance.player.stats.RemoveModifier(slotToEquip.properties);
        ItemSlot.SwapItemSlot(_itemSlot, slotToEquip);
        PlayerManager.Instance.player.stats.AddModifier(slotToEquip.properties);    
    }
    
    public void UnequipItem(ItemSlot _itemSlot, int _indexToPutUnequipItem = -1)
    {
        int index;
        if (_indexToPutUnequipItem != -1)
            index = _indexToPutUnequipItem;
        else
            index = GetFirstEmptySlotInInventory();
        if (index == -1)
            return;
        PlayerManager.Instance.player.stats.RemoveModifier(_itemSlot.properties);
        ItemSlot.SwapItemSlot(_itemSlot, inventorySlots[index]);
    }
    public int GetEquipmentTypeById(int _itemId) => (_itemId / 1000) % 10;

    public List<ItemSlot> GetItemSlotByItemId(int _itemId)
    {
        List<ItemSlot> listItem = new List<ItemSlot>();
        foreach (ItemSlot item in inventorySlots)
        {
            if (_itemId == item.itemId)
                listItem.Add(item);
        }
        return listItem;
    }
    public int GetFirstEmptySlotInInventory()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].IsEmpty())
            {
                return i;
            }
        }
        return -1;
    }
    [ContextMenu("Fill up item database")]
    public void FillUpItemDataBase()
    {
        itemDatabase.FillUpDatabase();
    }

}
