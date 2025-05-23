using BlitzyUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObject
{
    [SerializeField] private string npcDisplayName;
    [SerializeField] private List<NPC_Option> listOptions;
    public override void InteractAction()
    {
        BlitzyUI.Screen.Data data = new();
        data.Add("npcDisplayName", npcDisplayName);
        data.Add("listOptions", listOptions);
        UIManager.Instance.QueuePush(GameManager.npcOptionSelectorScreen, data);
    }
}
