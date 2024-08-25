using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    private RectTransform rect;
    [SerializeField] private RectTransform content;
    [SerializeField] private float maxHeight;

    [SerializeField] private BtnEquipItem equipButton;
    [SerializeField] private BtnRemoveItem removeItem;

    private ItemSlot itemSlot;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemType;
    [SerializeField] private TextMeshProUGUI itemQuality;
    [SerializeField] private TextMeshProUGUI itemLevel;
    [SerializeField] private TextMeshProUGUI itemDescription;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    public void SetItemInfo(ItemSlot _itemSlot)
    {
        gameObject.SetActive(true);
        itemSlot = _itemSlot;
        ItemData item = Inventory.Instance.itemDict[_itemSlot.itemInventory.itemId];
        itemIcon.sprite = item.icon;
        itemName.text = item.name;
        itemType.text = item.type.ToString();
        itemQuality.text = item.quality.ToString();
        string description = "";
        if (item.type == ItemType.Equipment)
        {
            foreach (var property in _itemSlot.itemInventory.properties)
            {
                string[] values = property.Value.Split(new char[] { ',' });
                foreach (var value in values)
                {
                    description += $"{property.Key} +{value}\n";
                }
            }
        }
        else
            description = $"{item.description}\n";
        itemDescription.text = description;
        //float height = maxHeight;
        //if (content.sizeDelta.y < height)
        //    height = content.sizeDelta.y;
        //rect.sizeDelta = new Vector2(content.sizeDelta.x, height);
    }
    public void EquipCurrentItem()
    {
        Inventory.Instance.EquipItem(itemSlot);
        gameObject.SetActive(false);
    }
    public void RemoveItem()
    {
        itemSlot.RemoveAll();
        gameObject.SetActive(false);
    }
    public void AssignPotionToSlot()
    {
        InputManager.Instance.potionSlot.AssignPotion(itemSlot.itemInventory.itemId);
    }
    public void UsePotion()
    {
        Inventory.Instance.UsePotion(itemSlot);
        gameObject.SetActive(false);
    }
}
