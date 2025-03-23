using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HUDScreen : BlitzyUI.Screen
{
    [SerializeField] private Transform buffHolder;
    private SkillSlot[] skillSlots;

    private ListItemToPick listItemToPick;
    private InteractionCollector npcInteraction;
    public override void OnFocus()
    {
        PlayerManager.Instance.player.detector.inZoneItem += listItemToPick.Add;
        PlayerManager.Instance.player.detector.outZoneItem += listItemToPick.Remove;
        PlayerManager.Instance.player.detector.inZoneNPC += npcInteraction.Add;
        PlayerManager.Instance.player.detector.outZoneNPC += npcInteraction.Remove;
    }

    public override void OnFocusLost()
    {
        PlayerManager.Instance.player.detector.inZoneItem -= listItemToPick.Add;
        PlayerManager.Instance.player.detector.outZoneItem -= listItemToPick.Remove;
        PlayerManager.Instance.player.detector.inZoneNPC -= npcInteraction.Add;
        PlayerManager.Instance.player.detector.outZoneNPC -= npcInteraction.Remove;
    }

    public override void OnPop()
    {
        SkillManager.Instance.assignEvent -= SetupSkillSlots;
        PopFinished();
    }

    public override void OnPush(Data data)
    {
        SkillManager.Instance.assignEvent += SetupSkillSlots;
        PushFinished();
    }

    public override void OnSetup()
    {
        PlayerManager.Instance.player.stats.BuffManager.buffHolder = buffHolder;
        skillSlots = GetComponentsInChildren<SkillSlot>();
        SetupSkillSlots();
        
        listItemToPick = GetComponentInChildren<ListItemToPick>();
        npcInteraction = GetComponentInChildren<InteractionCollector>();
    }

    public void SetupSkillSlots()
    {
        for (int i = 0; i < skillSlots.Length; i++)
        {
            skillSlots[i].AssignSkill(SkillManager.Instance.assignedSkills[i]);
        }
    }
}
