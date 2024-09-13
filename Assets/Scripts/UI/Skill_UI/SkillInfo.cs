using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfo : MonoBehaviour
{
    private Skill skill;

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI unlockedLevel;
    [SerializeField] private TextMeshProUGUI lockedLevel;

    [SerializeField] private RectTransform content;
    public void UpdateUI(Skill _skill)
    {
        skill = _skill;
        icon.sprite = skill.skillData.icon;
        skillName.text = skill.skillData.skillName;
        level.text = $"LV: {skill.currentLevel}";
        description.text = skill.GetDescription();
        unlockedLevel.text = skill.GetUnlockedLevelDescription();
        lockedLevel.text = skill.GetLockedLevelDescription();
        RefreshContentSize();
    }

    private void RefreshContentSize()
    {
        IEnumerator Routine()
        {
            var csf = content.GetComponent<ContentSizeFitter>();
            csf.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
            yield return null;
            csf.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
        this.StartCoroutine(Routine());
    }

    public void UpgradeSkill()
    {
        skill.Upgrade();
        UpdateUI(skill);
    }
}
