using BlitzyUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Eleonore : InteractableObject
{
    public override void InteractAction()
    {
        UIManager.Instance.QueuePush(GameManager.gemInsertionScreen, null);
    }
}
