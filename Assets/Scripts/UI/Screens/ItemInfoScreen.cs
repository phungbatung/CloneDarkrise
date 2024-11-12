using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoScreen : BlitzyUI.Screen
{
    private ItemInventory itemInventory;


    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemType;
    [SerializeField] private TextMeshProUGUI itemQuality;
    [SerializeField] private TextMeshProUGUI itemLevel;
    [SerializeField] private TextMeshProUGUI itemDescription;

    private RectTransform rect;
    [SerializeField] private RectTransform content;
    [SerializeField] private float maxHeight;

    private List<BtnBaseItemInfo> buttonList;

    private void Awake()
    {
        
    }
    public void SetItemInfo(ItemInventory _itemInventory)
    {
        gameObject.SetActive(true);
        itemInventory = _itemInventory;
        ItemData item = ItemManager.Instance.itemDict[_itemInventory.itemId];
        SetBaseInfo(item);
        SetPropertiesInfo(item);
        CheckForActiveButton(item);
        RefreshContentSize();

    }

    private void SetBaseInfo(ItemData item)
    {
        itemIcon.sprite = item.icon;
        itemName.text = item.name;
        itemType.text = item.type.ToString();
        itemQuality.text = item.quality.ToString();
    }

    private void SetPropertiesInfo(ItemData item)
    {
        string description = "";
        if (item.type == ItemType.Equipment)
        {
            string baseStat = ItemUtilities.GetBaseStatOfEquipment(item.id);
            description += $"Base {baseStat}: {ItemManager.Instance.itemDict[item.id].properties[baseStat]}\n";
            foreach (var property in itemInventory.equipmentProperties.properties)
            {
                string[] values = property.Value.Split(new char[] { ',' });
                foreach (var value in values)
                {
                    description += $"{property.Key} +{value}\n";
                }
            }
        }
        else if (item.type == ItemType.Potion)
        {
            
        }
        else
            description = $"{item.description}\n";
        itemDescription.text = description;
    }

    private void CheckForActiveButton(ItemData item)
    {
        ItemType type = item.type;
        foreach(var button in buttonList)
        {
            if (button.CanBeActive(type))
                button.gameObject.SetActive(true);
            else
                button.gameObject.SetActive(false);
        }    
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
        ItemManager.Instance.EquipItem(itemInventory);
        BlitzyUI.UIManager.Instance.QueuePop(null);
    }

    public void RemoveItem()
    {
        itemInventory.RemoveAll();
        BlitzyUI.UIManager.Instance.QueuePop(null);
    }

    public void AssignPotionToSlot()
    {
        InputManager.Instance.potionSlot.AssignPotion(itemInventory.itemId);
        BlitzyUI.UIManager.Instance.QueuePop(null);
    }

    public void UsePotion()
    {
        ItemManager.Instance.UsePotion(itemInventory);
        BlitzyUI.UIManager.Instance.QueuePop(null);
    }

    public void UseBuff()
    {
        ItemManager.Instance.UseBuff(itemInventory);
        BlitzyUI.UIManager.Instance.QueuePop(null);
    }

    public void UseSkillBook()
    {
        ItemManager.Instance.UseSkillBook(itemInventory);
        BlitzyUI.UIManager.Instance.QueuePop(null);
    }

    public override void OnSetup()
    {
        rect = GetComponent<RectTransform>();
        buttonList = content.GetComponentsInChildren<BtnBaseItemInfo>().ToList();
    }

    public override void OnPush(Data data)
    {
        SetItemInfo(data.Get<ItemInventory>("ItemInventory"));
        PushFinished();
    }

    public override void OnPop()
    {
        PopFinished();
    }

    public override void OnFocus()
    {

    }

    public override void OnFocusLost()
    {

    }
}
