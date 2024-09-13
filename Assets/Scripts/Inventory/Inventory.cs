using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public ItemDatabase itemDatabase;

    public Dictionary<int, ItemData> itemDict = new Dictionary<int, ItemData>();

    public Transform itemSlotsParent;
    public List<ItemSlot> inventorySlots { get; set; }

    public Transform equipmentSlotsParent;
    public List<ItemSlot> equipmentSlots { get; set; }

    public Transform moveItem;

    public ItemInfo itemInfo;

    public ListItemToPick listItemToPick;

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
    {        ItemSlot emptySlot = null;
        foreach (ItemSlot slot in inventorySlots)
        {
            if (_itemId == slot.itemInventory.itemId && slot.CanBeAdded())
            {
                slot.AddItem(_itemId, properties);
                if (_itemId == InputManager.Instance.potionSlot.itemId)
                    InputManager.Instance.potionSlot.UpdateUI();
                return;
            }
            if (slot.IsEmpty() && emptySlot == null)
                emptySlot = slot;
        }
        if (emptySlot!= null)
        {
            emptySlot.AddItem(_itemId, properties);
            if (_itemId == InputManager.Instance.potionSlot.itemId)
                InputManager.Instance.potionSlot.UpdateUI();
            return;
        }

        Debug.Log("Inventory is full.");
    }

    public void RemoveItem()
    {

    }
    


    #region Equipment
    public void EquipItem(ItemSlot _itemSlot)
    {
        if (itemDict[_itemSlot.itemInventory.itemId].type != ItemType.Equipment)
            return;
        ItemSlot slotToEquip = equipmentSlots[GetEquipmentTypeById(_itemSlot.itemInventory.itemId)];
        if (slotToEquip.itemInventory.itemId != -1)
            PlayerManager.Instance.player.stats.RemoveModifier(slotToEquip.itemInventory.properties);
        ItemSlot.SwapItemSlot(_itemSlot, slotToEquip);
        PlayerManager.Instance.player.stats.AddModifier(slotToEquip.itemInventory.properties);
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
        PlayerManager.Instance.player.stats.RemoveModifier(_itemSlot.itemInventory.properties);
        ItemSlot.SwapItemSlot(_itemSlot, inventorySlots[index]);
    }

    public int GetEquipmentTypeById(int _itemId) => (_itemId / 1000) % 10;
    #endregion

    #region Potion
    public void UsePotion(ItemSlot _itemSlot)
    {
        if (itemDict[_itemSlot.itemInventory.itemId].type != ItemType.Potion)
            return;
        PlayerManager.Instance.player.stats.UsePotion(_itemSlot.itemInventory.itemId);
        _itemSlot.RemoveItem();
    }
    public List<ItemSlot> GetItemSlotById(int _itemId)
    {
        return inventorySlots.Where(i => i.itemInventory.itemId == _itemId).ToList();
    }
    public int GetTotalAmount(int _itemId)
    {
        return inventorySlots.Where(i => i.itemInventory.itemId == _itemId).Sum(i => i.itemInventory.amount);
    }
    #endregion

    #region Buff
    public void UseBuff(ItemSlot _itemSlot)
    {
        if (itemDict[_itemSlot.itemInventory.itemId].type != ItemType.Buff)
            return;
        PlayerManager.Instance.player.stats.UseBuff(_itemSlot.itemInventory.itemId);
        _itemSlot.RemoveItem();
    }
    #endregion

    #region Sorting inventory
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
    #endregion

    #region Item database
    public void GenerateItemDataDictionary()
    {
        foreach (ItemData item in itemDatabase.itemList)
        {
            itemDict[item.id] = item;
        }
    }

    [ContextMenu("Fill up item database")]
    public void FillUpItemDataBase()
    {
        itemDatabase.FillUpDatabase();
    }
    #endregion

}
