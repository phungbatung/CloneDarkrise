using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TestCode : InteractableObject
{
    private DialogueSystemTrigger dialogueTrigger;
    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueSystemTrigger>();
    }
    public override void InteractAction()
    {
        dialogueTrigger.OnUse();
    }
}
