using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using JetBrains.Annotations;
using System.Collections.Generic;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    [HideInInspector] public int itemId;
    [HideInInspector] public int amount;


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
    public void RemoveItem(int _id, int _amount=1)
    {
        amount -= _amount;
        if (amount <= 0)
            itemId = -1;
        if (amount <= 0)
        {
            itemId = -1;
        }
        UpdateUI();
    }
    public void RemoveAll(int _id)
    {
        amount=0;
        itemId = -1;
        if (amount <= 0)
        {
            itemId = -1;
        }
        UpdateUI();
    }
    public bool IsEmpty()
    {
        return itemId == -1;
    }
    public bool CanBeAdded(int _addAmount = 1)
    {
        return amount + _addAmount <= Inventory.Instance.itemDatabase.itemDataDictionary[itemId].maxSize;
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
            itemImage.sprite = Inventory.Instance.itemDatabase.itemDataDictionary[itemId].icon;
            if (amount <= 1)
                amountText.text = "";
            else
                amountText.text = amount.ToString();
        }
    }

    //Swap value
    public static void SwapItemSlot(ItemSlot slot1, ItemSlot slot2)
    {
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
    public void AddProperties(Dictionary<string, string> _properties)
    {
        properties = _properties;
    }
    public void RemoveProperties()
    {
        properties.Clear();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.dragging)
            return;
        Debug.Log("click");
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
            if (inventory.itemDatabase.itemDataDictionary[toDropSlot.itemId].type != ItemType.Equipment)
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
            if (inventory.itemDatabase.itemDataDictionary[itemId].type != ItemType.Equipment)
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
}
