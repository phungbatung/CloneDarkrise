using BlitzyUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTower : InteractableObject
{
    public override void InteractAction()
    {
        UIManager.Instance.QueuePush(GameManager.worldMapScreen, null);
    }
}
