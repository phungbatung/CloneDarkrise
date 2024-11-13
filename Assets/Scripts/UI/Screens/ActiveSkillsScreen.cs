using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveSkillsScreen : BlitzyUI.Screen
{
    [SerializeField] private GameObject skillUIPrefab;
    [SerializeField] private Transform skillUIParent;
    [SerializeField] private TextMeshProUGUI skillPoint;

    private SkillInfo skillInfo;
    public override void OnFocus()
    {

    }

    public override void OnFocusLost()
    {

    }

    public override void OnPop()
    {
        SkillManager.Instance.OnSkillPointChange -= UpdateSkillPoint;
        PopFinished();
    }

    public override void OnPush(Data data)
    {
        SkillManager.Instance.OnSkillPointChange += UpdateSkillPoint;
        skillInfo.UpdateUI(SkillManager.Instance.GetComponent<Skill>());
        UpdateSkillPoint();
        PushFinished();
    }

    public override void OnSetup()
    {
        skillInfo = GetComponentInChildren<SkillInfo>();
        Skill[] skills = SkillManager.Instance.GetComponents<Skill>();
        foreach (Skill skill in skills)
        {
            GameObject skillUI = Instantiate(skillUIPrefab, skillUIParent);
            skillUI.GetComponent<Skill_UI>().SetSkill(skill, skillInfo);
        }
    }

    public void UpdateSkillPoint()
    {
        skillPoint.text = SkillManager.Instance.skillPoint.ToString();
    }
}
