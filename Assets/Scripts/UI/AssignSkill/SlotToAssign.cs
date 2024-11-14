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
        Debug.Log("log1");
        UIManager.Instance.QueuePop();
        Debug.Log("log2");
    }

    public void SetSkill(Skill _skill, Skill _skillToAssign, int _slotIndex)
    {
        skill = _skill;
        skillToAssign = _skillToAssign;
        slotIndex = _slotIndex;
        skillIcon.sprite = skill.skillData.icon;
    }
}
