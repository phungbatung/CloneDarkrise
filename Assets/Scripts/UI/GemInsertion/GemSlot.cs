using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GemSlot : MonoBehaviour, IDropHandler, IPointerDownHandler
{
    public int slotIndex { get; set; }
    public ItemInventory itemInventory { get; set; }

    [Header("Component")]
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemProperties;

    [Header("Locked sprite")]
    [SerializeField] private Sprite lockedSprite;
    private string lockedMessage = "Unlock for 0 gold";

    public Action<int, ItemSlot> OnDropEvent { get; set; }
    public Action<int> PointerDownEvent { get; set; }

    public void SetLocked()
    {
        itemIcon.sprite = lockedSprite;
        itemProperties.text = lockedMessage;
    }
    public void SetProperties(int gemId)
    {
        if(gemId == -1)
        {
            itemIcon.color = new Color(1, 1, 1, 0);
            itemIcon.sprite = null;
            itemProperties.text = "Gem socket";
            return;
        }
        ItemData item = ItemManager.Instance.itemDict[gemId];
        itemIcon.sprite = item.icon;
        itemIcon.color = new Color(1, 1, 1, 1);
        string properties = "";
        foreach(var property in  item.properties)
        {
            properties += $"+{property.Value} {property.Key}\n";
        }
        itemProperties.text = properties;
    }
    public void OnDrop(PointerEventData eventData)
    {
        ItemSlot itemSlot = eventData.pointerDrag.GetComponent<ItemSlot>();

        if(itemSlot != null)
            OnDropEvent?.Invoke(slotIndex, itemSlot);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PointerDownEvent?.Invoke(slotIndex);
    }
}
