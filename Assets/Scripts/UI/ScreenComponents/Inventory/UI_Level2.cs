using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Level2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI exp;
    [SerializeField] private Image expBar;

    private void Start()
    {
        UpdateLevel(PlayerManager.Instance.player.levels);
        PlayerManager.Instance.player.levels.OnLevelUpdate += UpdateLevel;
    }

    private void OnDestroy()
    {
        if (PlayerManager.Instance != null && PlayerManager.Instance.player != null)
            PlayerManager.Instance.player.levels.OnLevelUpdate -= UpdateLevel;
    }
    public void UpdateLevel(CharacterLevel charLevel)
    {
        level.text = $"LV: {charLevel.Level}";
        exp.text = $"{Utils.ConvertToKMB(charLevel.Exp)}/{Utils.ConvertToKMB(charLevel.ExpToNextLevel)}";
        expBar.fillAmount = charLevel.Exp * 1.0f / charLevel.ExpToNextLevel;
    }
}
