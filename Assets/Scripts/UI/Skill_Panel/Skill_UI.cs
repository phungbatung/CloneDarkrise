using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skill_UI : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image icon;
    private Skill skill;
    private SkillInfo skillInfo;

    public void OnPointerDown(PointerEventData eventData)
    {
        skillInfo.UpdateUI(skill);
    }

    public void SetSkill(Skill _skill, SkillInfo _skillInfo)
    {
        skill = _skill;
        skillInfo = _skillInfo;
        icon.sprite = skill.skillData.icon;
    }
}
