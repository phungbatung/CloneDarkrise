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

    int i = 0;
    private void OnEnable()
    {
        Debug.Log($"{i++}");
        Debug.Log($"{(equipedItem != null)}");
        //if (equipedItem != null)
        //    UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        for (int i = 0; i < itemSlots.Length; i++) 
        {
            itemSlots[i].UpdateUI(equipedItem[i]);
        }
    }
}
