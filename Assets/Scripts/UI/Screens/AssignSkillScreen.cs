using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignSkillScreen : BlitzyUI.Screen
{
    private SkillToAssign skillToAssign;
    [SerializeField] private SlotToAssign slotToAssignPrefab;
    [SerializeField] private Transform slotsToAssignParent;

    private List<SlotToAssign> slotsToAssign;

    private CanvasGroup canvasGroup;
    public override void OnFocus()
    {
        canvasGroup.blocksRaycasts = true;
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
        Skill skill = data.Get<Skill>("Skill");
        skillToAssign.SetSkillIcon(skill);
        Skill[] assignedSkills = SkillManager.Instance.assignedSkills;

        for (int i=1; i < assignedSkills.Length; i++)
        {
            slotsToAssign[i-1].SetSkill(assignedSkills[i], skill, i);
        }
        PushFinished();
    }

    public override void OnSetup()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        skillToAssign = GetComponentInChildren<SkillToAssign>();
        slotsToAssign = new();
        for (int i = 1; i < SkillManager.Instance.assignedSkills.Length; i++)
        {
            slotsToAssign.Add(Instantiate(slotToAssignPrefab, slotsToAssignParent));
        }
    }
}
