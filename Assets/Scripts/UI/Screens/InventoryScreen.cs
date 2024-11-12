using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreen : BlitzyUI.Screen
{
    private InventoryUI inventoryUI;
    private EquipmentUI equipmentUI;

    private CanvasGroup canvasGroup;
    public override void OnFocus()
    {
        canvasGroup.blocksRaycasts = true;
       
        inventoryUI.UpdateItemSlot();
        equipmentUI.UpdateItemSlot();
    }

    public override void OnFocusLost()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public override void OnPop()
    {
        PopFinished();
    }

    public override void OnPush(Data data)
    {
        inventoryUI.SwitchToFirstPage();
        PushFinished();
    }

    public override void OnSetup()
    {
        inventoryUI = GetComponentInChildren<InventoryUI>();
        equipmentUI = GetComponentInChildren<EquipmentUI>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }
}
