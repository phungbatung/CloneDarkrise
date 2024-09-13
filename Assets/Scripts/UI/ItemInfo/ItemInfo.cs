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
        gameObject.SetActive(false);
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
        RefreshContentSize();
        
    }

    private void RefreshContentSize()
    {
        IEnumerator Routine()
        {
            var csf = content.GetComponent<ContentSizeFitter>();
            csf.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
            yield return null;
            csf.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            yield return null;
            float height = maxHeight;
            if (content.sizeDelta.y < height)
                height = content.sizeDelta.y;
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, height);
        }
        this.StartCoroutine(Routine());
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
        gameObject.SetActive(false);
    }
    public void UsePotion()
    {
        Inventory.Instance.UsePotion(itemSlot);
        gameObject.SetActive(false);
    }
    public void UseBuff()
    {
        Inventory.Instance.UseBuff(itemSlot);
        gameObject.SetActive(false);
    }
}
