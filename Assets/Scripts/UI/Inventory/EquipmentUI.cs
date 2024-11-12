using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    private ItemSlot[] itemSlots;
    public List<ItemInventory> equipedItem => ItemManager.Instance.equipedItems;

    private void Awake()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>();
    }

    public void UpdateItemSlot()
    {
        for (int i = 0; i < itemSlots.Length; i++) 
        {
            itemSlots[i].UpdateUI(equipedItem[i]);
        }
    }
}
