using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using JetBrains.Annotations;
using System.Collections.Generic;
using System;
using Unity.Mathematics;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public int itemId { get; set; }
    public int amount { get; set; }


    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI amountText;

    public Dictionary<string, string> properties;
    private void Awake()
    {
        itemId = -1;
        amount = 0;
        properties = new Dictionary<string, string>();
        UpdateUI();
    }
    public void AddItem(int _id, int _amount = 1, Dictionary<string, string> _properties = null)
    {
        if (itemId == -1)
            itemId = _id;
        if (_properties != null)
            properties = _properties;
        amount += _amount;
        UpdateUI();
    }
    public void AddItem(int _id, Dictionary<string, string> _properties = null)
    {
        if (itemId == -1)
            itemId = _id;
        if (_properties != null)
            properties = _properties;
        amount ++;
        UpdateUI();
    }
    public void RemoveItem(int _amount=1)
    {
        amount -= _amount;
        if (amount <= 0)
            itemId = -1;
        if (amount <= 0)
        {
            itemId = -1;
            properties.Clear();
        }
        UpdateUI();
    }
    public void RemoveAll()
    {
        amount=0;
        itemId = -1;
        properties.Clear();
        UpdateUI();
    }
    public bool IsEmpty()
    {
        return itemId == -1;
    }
    public bool CanBeAdded(int _addAmount = 1)
    {
        return amount + _addAmount <= Inventory.Instance.itemsDict[itemId].maxSize;
    }
    public void UpdateUI()
    {
        if (itemId == -1)
        {
            itemImage.color = new Color(1, 1, 1, 0);
            itemImage.sprite = null;
            amountText.text = "";
        }
        else
        {
            itemImage.color = new Color(1, 1, 1, 1);
            itemImage.sprite = Inventory.Instance.itemsDict[itemId].icon;
            if (amount <= 1)
                amountText.text = "";
            else
                amountText.text = amount.ToString();
        }
    }

    public static void SwapItemSlot(ItemSlot slot1, ItemSlot slot2)
    {
        //Swap value
        int tempId = slot1.itemId;
        slot1.itemId = slot2.itemId;
        slot2.itemId = tempId;

        int tempAmount = slot1.amount;
        slot1.amount = slot2.amount;
        slot2.amount = tempAmount;

        Dictionary<string, string> tempProperties = slot1.properties;
        slot1.properties = slot2.properties;
        slot2.properties = tempProperties;

        slot1.UpdateUI();
        slot2.UpdateUI();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.dragging)
            return;
        if (itemId == -1)
            return;
        UI_Manager.Instance.itemInfo.SetItemInfo(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemImage.raycastTarget = false;
        itemImage.transform.SetParent(Inventory.Instance.moveItem);
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
        Inventory inventory = Inventory.Instance;

        //Case: slot to drop is equipment slot
        if (Inventory.Instance.equipmentSlots.Contains(this)) 
        {
            //Two equipped item are not the same type
            if (inventory.equipmentSlots.Contains(toDropSlot))
                return;
            //Cannot drop none equipment to equipment slot
            if (inventory.itemsDict[toDropSlot.itemId].type != ItemType.Equipment)
                return;
            //Cannot drop equipment other than the equipment type of this equipment slot
            if (inventory.GetEquipmentTypeById(toDropSlot.itemId) != inventory.equipmentSlots.IndexOf(this))
                return;
            //Equip
            inventory.EquipItem(toDropSlot);
            return;
        }

        //Case: slot to drop is inventory slot
        //Check if to drop slot is from equipment slot
        if (Inventory.Instance.equipmentSlots.Contains(toDropSlot))
        {
            //if slot to drop is empty then move item from equipment slot to this slot
            if (itemId ==-1)
            {
                inventory.UnequipItem(toDropSlot, inventory.inventorySlots.IndexOf(this));
                return;
            }
            //Cannot swap item from equipment slot to none equipment
            if (inventory.itemsDict[itemId].type != ItemType.Equipment)
                return;
            //Cannot swap item from equipment slot to another equipment of different type
            if (inventory.GetEquipmentTypeById(itemId) != inventory.GetEquipmentTypeById(toDropSlot.itemId))
                return;
            //Equip this item if it is equipment of the same type
            inventory.EquipItem(this);
            return;
        }
        //Swap two item from inventory
        SwapItemSlot(this, toDropSlot);
    }

    public static int CompareByItemId(ItemSlot slot1, ItemSlot _itemSlot)
    {
        if (slot1.itemId == -1 && _itemSlot.itemId != -1) return 1;
        if (slot1.itemId != -1 && _itemSlot.itemId == -1) return -1;
        if (slot1.itemId == -1 && _itemSlot.itemId == -1) return 0;
        ItemData item1 = Inventory.Instance.itemsDict[slot1.itemId];
        ItemData item2 = Inventory.Instance.itemsDict[_itemSlot.itemId];
        if (item1.type > item2.type) return 1;
        if (item1.type<item2.type) return -1;
        if (item1.quality<item2.quality) return 1;
        if (item1.quality > item2.quality) return -1;
        return 0;
    }
    public static int CompareByItemQuality(ItemSlot slot1, ItemSlot slot2)
    {
        if (slot1.itemId == -1 && slot2.itemId != -1) return 1;
        if (slot1.itemId != -1 && slot2.itemId == -1) return -1;
        if (slot1.itemId == -1 && slot2.itemId == -1) return 0;
        ItemData item1 = Inventory.Instance.itemsDict[slot1.itemId];
        ItemData item2 = Inventory.Instance.itemsDict[slot2.itemId];
        if (item1.quality<item2.quality) return 1;
        if (item1.quality > item2.quality) return -1;
        if (item1.type > item2.type) return 1;
        if (item1.type<item2.type) return -1;
        return 0;
    }
}
