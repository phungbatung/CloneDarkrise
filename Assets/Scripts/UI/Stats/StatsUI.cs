using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damage;
    [SerializeField] private TextMeshProUGUI attackSpeed;
    [SerializeField] private TextMeshProUGUI armorPenetration;
    [SerializeField] private TextMeshProUGUI criticalRate;
    [SerializeField] private TextMeshProUGUI criticalDamage;

    [SerializeField] private TextMeshProUGUI maxHealth;
    [SerializeField] private TextMeshProUGUI healthRegen;
    [SerializeField] private TextMeshProUGUI armor;

    [SerializeField] private TextMeshProUGUI maxMana;
    [SerializeField] private TextMeshProUGUI manaRegen;
    [SerializeField] private TextMeshProUGUI moveSpeed;


    private void OnEnable()
    {
        if (PlayerManager.Instance != null)
            UpdateStatsUI();
    }
    public void UpdateStatsUI()
    {
        CharacterStats stats = PlayerManager.Instance.player.stats;
        damage.text = stats.damage.GetValue().ToString();
        attackSpeed.text = stats.attackSpeed.GetValue().ToString() + "%";
        armorPenetration.text = stats.armorPenetration.GetValue().ToString();
        criticalRate.text = stats.criticalRate.GetValue().ToString() + "%";
        criticalDamage.text = stats.criticalDamage.GetValue().ToString() + "%";
        maxHealth.text = stats.maxHealth.GetValue().ToString();
        healthRegen.text = stats.healthRegen.GetValue().ToString() + "/s";
        armor.text = stats.armor.GetValue().ToString();
        maxMana.text = stats.maxMana.GetValue().ToString();
        manaRegen.text = stats.manaRegen.GetValue().ToString() + "/s";
        moveSpeed.text = stats.moveSpeed.GetValue().ToString();
    }
}
