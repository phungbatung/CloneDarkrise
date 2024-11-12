using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using JetBrains.Annotations;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using BlitzyUI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public ItemInventory itemInventory;

    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI amountText;

    private void Awake()
    {
        
    }
    public void UpdateUI()
    {
        if (itemInventory.itemId == -1)
        {
            itemImage.color = new Color(1, 1, 1, 0);
            itemImage.sprite = null;
            amountText.text = "";
        }
        else
        {
            itemImage.color = new Color(1, 1, 1, 1);
            itemImage.sprite = ItemManager.Instance.itemDict[itemInventory.itemId].icon;
            if (itemInventory.amount <= 1)
                amountText.text = "";
            else
                amountText.text = itemInventory.amount.ToString();
        }
    }
    public void UpdateUI(ItemInventory _itemInventory)
    {
        itemInventory = _itemInventory;
        if (_itemInventory.IsEmpty())
        {
            itemImage.color = new Color(1, 1, 1, 0);
            itemImage.sprite = null;
            amountText.text = "";
        }
        else
        {
            itemImage.color = new Color(1, 1, 1, 1);
            itemImage.sprite = ItemManager.Instance.itemDict[_itemInventory.itemId].icon;
            if (_itemInventory.amount <= 1)
                amountText.text = "";
            else
                amountText.text = _itemInventory.amount.ToString();
        }
    }
    public void AddItem(int _id, int _amount = 1)
    {
        itemInventory.AddItem(_id, _amount);
        UpdateUI();
    }
    public void AddItem(int _id, Dictionary<string, string> _properties = null)
    {
        itemInventory.AddItem(_id, _properties);
        UpdateUI();
    }
    public void RemoveItem(int _amount=1)
    {
        itemInventory.RemoveItem(_amount);
        UpdateUI();
    }
    public void RemoveAll()
    {
        itemInventory.RemoveAll();
        UpdateUI();
    }
    public bool IsEmpty()
    {
        return itemInventory.IsEmpty();
    }
    public bool CanBeAdded(int _addAmount = 1)
    {
        return itemInventory.CanBeAdded(_addAmount);
    }

    public static void SwapItemSlot(ItemSlot slot1, ItemSlot slot2)
    {
        ItemInventory temp = slot1.itemInventory;
        slot1.itemInventory = slot2.itemInventory;
        slot2.itemInventory = temp;

        slot1.UpdateUI();
        slot2.UpdateUI();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.dragging)
            return;
        if (itemInventory.itemId == -1)
            return;
        BlitzyUI.Screen.Data data = new BlitzyUI.Screen.Data();
        data.Add("ItemInventory", itemInventory);
        UIManager.Instance.QueuePush(GameManager.itemInfoScreen, data, null, null);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemImage.raycastTarget = false;
        Transform tempParent = GetComponentInParent<BlitzyUI.Screen>().transform;
        if (tempParent == null)    
            Debug.LogError("The screen parent of this item slot is not found!");
        itemImage.transform.SetParent(tempParent);
        itemImage.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemImage.transform.position += (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemImage.raycastTarget = true;
        itemImage.transform.SetParent(this.transform);
        RectTransform rectTransform = itemImage.transform as RectTransform;
        rectTransform.anchoredPosition = Vector3.zero;
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemSlot toDropSlot = eventData.pointerDrag.GetComponent<ItemSlot>();
        ItemManager inventory = ItemManager.Instance;

        //Case: slot to drop is equipment slot
        if (ItemManager.Instance.equipedItems.Contains(itemInventory)) 
        {
            //Two equipped item are not the same type
            if (inventory.equipedItems.Contains(toDropSlot.itemInventory))
                return;
            //Cannot drop non-equipment to equipment slot
            if (inventory.itemDict[toDropSlot.itemInventory.itemId].type != ItemType.Equipment)
                return;
            //Cannot drop equipment of different type in this equipment slot
            if (inventory.GetEquipmentTypeById(toDropSlot.itemInventory.itemId) != inventory.equipedItems.IndexOf(itemInventory))
                return;
            //Equip
            inventory.EquipItem(toDropSlot.itemInventory);
            return;
        }

        //Case: slot to drop is inventory slot
        //Check if to drop slot is from equipment slot
        if (ItemManager.Instance.equipedItems.Contains(toDropSlot.itemInventory))
        {
            //if slot to drop is empty then move item from equipment slot to this slot
            if (itemInventory.itemId ==-1)
            {
                inventory.UnequipItem(toDropSlot.itemInventory, itemInventory);
                return;
            }
            //Cannot swap item from equipment slot to none equipment
            if (inventory.itemDict[itemInventory.itemId].type != ItemType.Equipment)
                return;
            //Cannot swap item from equipment slot to another equipment of different type
            if (inventory.GetEquipmentTypeById(itemInventory.itemId) != inventory.GetEquipmentTypeById(toDropSlot.itemInventory.itemId))
                return;
            //Equip this item if it is equipment of the same type
            inventory.EquipItem(itemInventory);
            return;
        }
        //Swap two item from inventory
        SwapItemSlot(this, toDropSlot);
    }

    public static int CompareByItemId(ItemSlot slot1, ItemSlot slot2)
    {
        return ItemInventory.CompareByItemType(slot1.itemInventory, slot2.itemInventory);
    }
    public static int CompareByItemQuality(ItemSlot slot1, ItemSlot slot2)
    {
        return ItemInventory.CompareByItemQuality(slot1.itemInventory, slot2.itemInventory);
    }
}
