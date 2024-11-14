using BlitzyUI;
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

    [SerializeField] private TextMeshProUGUI skillPoint;
    [SerializeField] private RectTransform container;

    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button assignButton;


    private void Awake()
    {
        upgradeButton.onClick.AddListener(UpgradeSkill);
        assignButton.onClick.AddListener(AssignSkill);
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

        if(skill == SkillManager.Instance.dash)
            assignButton.gameObject.SetActive(false);
        else
            assignButton.gameObject.SetActive(true);

        RefreshContentSize();

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

    public void AssignSkill()
    {
        BlitzyUI.Screen.Data data = new();
        data.Add("Skill", skill);
        UIManager.Instance.QueuePush(GameManager.assignSkillsScreen, data, null, null);
    }
}
