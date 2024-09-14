using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    private Button upgradeButton;
    private SkillInfo skillInfo;

    [SerializeField] TextMeshProUGUI pointToUpgrade;

    private void Awake()
    {
        upgradeButton = GetComponent<Button>();
        skillInfo = GetComponentInParent<SkillInfo>();
        upgradeButton.onClick.AddListener(skillInfo.UpgradeSkill);
    }


}
