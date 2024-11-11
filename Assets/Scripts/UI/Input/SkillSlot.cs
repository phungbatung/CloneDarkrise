using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    private Skill skill;
    public Image image;
    private TextMeshProUGUI textCoolDown;
    public bool isPressed { get; set; }
    private void Awake()
    {
        textCoolDown = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        skill.isPressed = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        skill.isPressed = false;
    }

    public void DoCooldown()
    {
        float  _cooldownTimer = skill.cooldownTimer;
        float _coolDown = skill.skillData.levelsData[skill.currentLevel].coolDown;
        if (_cooldownTimer <= 0)
        {
            image.fillAmount = 1;
            textCoolDown.text = "";
            return;
        }
        image.fillAmount = (_coolDown - _cooldownTimer)/_coolDown;
        textCoolDown.text = ((int)_cooldownTimer).ToString();
    }

    public void AssignSkill(Skill _skill)
    {
        if (skill!=null)
        {
            skill.coolDownEvent -= DoCooldown;
        }

        skill = _skill;
        image.sprite = skill.skillData.icon;
        skill.coolDownEvent += DoCooldown;
    }
}
