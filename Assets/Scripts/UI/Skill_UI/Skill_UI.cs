using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skill_UI : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image icon;
    private Skill skill;

    public void OnPointerDown(PointerEventData eventData)
    {
        SkillManager.Instance.skillInfo.UpdateUI(skill);
    }

    public void SetSkill(Skill _skill)
    {
        skill = _skill;
        icon.sprite = skill.skillData.icon;
    }
}
