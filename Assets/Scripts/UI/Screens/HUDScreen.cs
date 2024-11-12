using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScreen : BlitzyUI.Screen
{
    [SerializeField] private Transform buffHolder;
    private SkillSlot[] skillSlots;

    public override void OnFocus()
    {

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

        PushFinished();
    }

    public override void OnSetup()
    {
        PlayerManager.Instance.player.stats.BuffManager.buffHolder = buffHolder;
        skillSlots = GetComponentsInChildren<SkillSlot>();
        SetupSkillSlots();
        SkillManager.Instance.assignEvent += SetupSkillSlots;
    }

    public void SetupSkillSlots()
    {
        for (int i = 0; i < skillSlots.Length; i++)
        {
            skillSlots[i].AssignSkill(SkillManager.Instance.assignedSkills[i]);
        }
    }
}
