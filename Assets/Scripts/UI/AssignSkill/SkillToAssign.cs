using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillToAssign : MonoBehaviour
{
    [SerializeField] private Image skillIcon;

    public void SetSkillIcon(Skill skill)
    {
        skillIcon.sprite = skill.skillData.icon;
    }
}
