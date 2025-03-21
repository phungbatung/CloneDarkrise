using BlitzyUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_BlackSmith : InteractableObject
{
    public override void InteractAction()
    {
        UIManager.Instance.QueuePush(GameManager.upgradeEquipmentScreen, null);
    }
}
