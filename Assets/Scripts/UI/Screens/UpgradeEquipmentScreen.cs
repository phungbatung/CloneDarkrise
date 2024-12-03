using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeEquipmentScreen : BlitzyUI.Screen
{
    [SerializeField] private EquipmentWorkInventoryUI inventoryUI;
    [SerializeField] private EquipmentToUpgradeSlot equipmentSlot;
    [SerializeField] private TextMeshProUGUI propertiesStatus;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private TextMeshProUGUI priceTMP;
    private string guideText { get;  } = "Drag and drop your equipment hear to upgrade";
    private string maxEnhanceLevelText { get; } = "Your equipment is max enhancement level, try to put another equipment in to upgrade";

    private ItemInventory itemInventory;
    public override void OnFocus()
    {
        inventoryUI.UpdateItemSlot();
    }

    public override void OnFocusLost()
    {

    }

    public override void OnPop()
    {
        PopFinished();
    }

    public override void OnPush(Data data)
    {
        inventoryUI.SwitchToFirstPage();
        SetupPropertiesText();
        PushFinished();
    }

    public override void OnSetup()
    {
        equipmentSlot.OnDropAction += EquipmentSlotOnDropAction;
        equipmentSlot.OnPointerDownAction += EquipmentSlotOnPoiterDownAction;
        upgradeButton.onClick.AddListener(UpgradeButtonAction);
    }

    public void EquipmentSlotOnDropAction(ItemInventory _itemInventory)
    {
        itemInventory=_itemInventory;
        inventoryUI.SetItemToWorkOnGem(_itemInventory, EquipmentSlotOnPoiterDownAction);
        SetupPropertiesText();
    }

    public void EquipmentSlotOnPoiterDownAction()
    {
        itemInventory = null;
        equipmentSlot.SetEmtyItem();
        inventoryUI.RemoveOnWorkItem();
        SetupPropertiesText();
    }

    private void SetupPropertiesText()
    {
        if(itemInventory == null)
        {
            propertiesStatus.text = guideText;
            upgradeButton.gameObject.SetActive(false);
            return;
        }
        if(itemInventory.equipmentProperties.IsMaxEnhanceLevel())
        {
            propertiesStatus.text = maxEnhanceLevelText;
            upgradeButton.gameObject.SetActive(false);
            return;
        }
        propertiesStatus.text = itemInventory.equipmentProperties.GetPropertiesChangeWhenUpgrade();
        priceTMP.text = itemInventory.equipmentProperties.GetUpgradePrice().Value.ToString();
        upgradeButton.gameObject.SetActive(true);
    }    

    private void UpgradeButtonAction()
    {
        if(itemInventory.equipmentProperties.TryUpgrade())
        {
            inventoryUI.UpdateOnWorkItemSlot();
            equipmentSlot.SetItem(itemInventory);
            SetupPropertiesText();
        }
        else
        {
            Debug.Log("You don't have enough money to upgrade this item");
        }
    }
}
