using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public ItemDatabase itemDatabase;

    public Dictionary<int, ItemData> itemsDict = new Dictionary<int, ItemData>();

    public Transform itemSlotsParent;
    public List<ItemSlot> inventorySlots { get; set; }

    public Transform equipmentSlotsParent;
    public List<ItemSlot> equipmentSlots { get; set; }

    public Transform moveItem;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        inventorySlots = itemSlotsParent.GetComponentsInChildren<ItemSlot>().ToList();
        inventorySlots.TrimExcess();
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<ItemSlot>().ToList();
        equipmentSlots.TrimExcess();
        //FillUpItemDataBase();
        //tmp.text = itemDatabase.itemList.Count.ToString();
        GenerateItemDataDictionary();
    }

    public void AddItem(int _itemId, Dictionary<string, string> properties = null)
    {
        ItemSlot emptySlot = null;
        foreach (ItemSlot slot in inventorySlots)
        {
            if (_itemId == slot.itemId && slot.CanBeAdded())
            {
                slot.AddItem(_itemId, properties);
                return;
            }
            if (slot.IsEmpty() && emptySlot == null)
                emptySlot = slot;
        }
        if (emptySlot!= null)
        {
            emptySlot.AddItem(_itemId, properties);
            return;
        }

        Debug.Log("Inventory is full.");
    }

    public void RemoveItem()
    {

    }

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

    public void SortItemByItemType(List<ItemSlot> listItemSlot)
    {
        QuickSort(listItemSlot, 0, listItemSlot.Count - 1, ItemSlot.CompareByItemId);
    }

    public void SortItemByItemQuality(List<ItemSlot> listItemSlot)
    {
        QuickSort(listItemSlot, 0, listItemSlot.Count - 1, ItemSlot.CompareByItemQuality);
    }

    public void QuickSort(List<ItemSlot> listItemSlot, int low, int high, Func<ItemSlot, ItemSlot, int> Compare)
    {
        //Sort by swap value
        if (low < high)
        {
            int pi = Partition(listItemSlot, low, high, Compare);
            QuickSort(listItemSlot, low, pi - 1, Compare);
            QuickSort(listItemSlot, pi + 1, high, Compare);

        }
    }

    public int Partition(List<ItemSlot> listItemSlot, int low, int high, Func<ItemSlot, ItemSlot, int> Compare)
    {
        ItemSlot pivot = listItemSlot[high];
        int i = (low - 1);

        for (int j = low; j <= high - 1; j++)
        {
            if (Compare(listItemSlot[j], pivot) <= 0)
            {
                i++;
                ItemSlot.SwapItemSlot(listItemSlot[i], listItemSlot[j]);
            }
        }
        ItemSlot.SwapItemSlot(listItemSlot[i + 1], listItemSlot[high]);
        return (i + 1);
    }

    public void GenerateItemDataDictionary()
    {
        foreach (ItemData item in itemDatabase.itemList)
        {
            itemsDict[item.id] = item;
        }
    }

    [ContextMenu("Fill up item database")]
    public void FillUpItemDataBase()
    {
        itemDatabase.FillUpDatabase();
    }

}
