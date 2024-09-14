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

    private Button upgradeButton;
    [SerializeField] private TextMeshProUGUI skillPoint;
    [SerializeField] private RectTransform container;


    private void Awake()
    {
        upgradeButton = GetComponentInChildren<Button>();
        upgradeButton.onClick.AddListener(UpgradeSkill);
    }
    private void OnEnable()
    {
        if (skill != null)
            UpdateUI(skill);
    }
    public void UpdateUI(Skill _skill)
    {
        skill = _skill;
        icon.sprite = skill.skillData.icon;
        skillName.text = skill.skillData.skillName;
        level.text = $"LV: {skill.currentLevel}";
        skillPoint.text = skill.GetPointToUpgradeNextLevel().ToString();
        description.text = skill.GetDescription();
        unlockedLevel.text = skill.GetUnlockedLevelDescription();
        lockedLevel.text = skill.GetLockedLevelDescription();

        RefreshContentSize();
        Debug.Log("log");

    }

    private void RefreshContentSize()
    {
        IEnumerator Routine()
        {
            ContentSizeFitter skillCFS = content.GetComponent<ContentSizeFitter>();
            ContentSizeFitter containerCFS = content.GetComponent<ContentSizeFitter>();
            skillCFS.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
            containerCFS.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
            yield return null;
            skillCFS.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            containerCFS.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
        this.StartCoroutine(Routine());
    }

    public void UpgradeSkill()
    {
        skill.Upgrade();
        UpdateUI(skill);
    }
}
