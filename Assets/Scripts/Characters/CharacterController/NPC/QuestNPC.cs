using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : InteractableObject
{
    private DialogueSystemTrigger dialogueSystemTrigger { get; set; }
    private void Awake()
    {
        dialogueSystemTrigger = GetComponent<DialogueSystemTrigger>();
    }
    public override void InteractAction()
    {
        
    }
}
