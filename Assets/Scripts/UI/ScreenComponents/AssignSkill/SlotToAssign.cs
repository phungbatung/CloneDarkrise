using BlitzyUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotToAssign : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image skillIcon;
    private Skill skillToAssign;
    private Skill skill;
    private int slotIndex;

    public void OnPointerClick(PointerEventData eventData)
    {
        SkillManager.Instance.AssignSkillToSlot(skillToAssign, slotIndex);
        UIManager.Instance.QueuePop();
    }

    public void SetSkill(Skill _skill, Skill _skillToAssign, int _slotIndex)
    {
        skill = _skill;
        skillToAssign = _skillToAssign;
        slotIndex = _slotIndex;
        skillIcon.sprite = skill.SkillData.icon;
    }
}
