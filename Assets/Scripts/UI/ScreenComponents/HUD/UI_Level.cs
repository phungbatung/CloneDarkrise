using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Level : MonoBehaviour
{
    private TextMeshProUGUI level;
    private void Awake()
    {
        level = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        UpdateLevel(PlayerManager.Instance.player.levels);
        PlayerManager.Instance.player.levels.OnLevelUpdate += UpdateLevel;
    }

    private void OnDestroy()
    {
        if(PlayerManager.Instance!=null && PlayerManager.Instance.player!=null)
            PlayerManager.Instance.player.levels.OnLevelUpdate -= UpdateLevel;
    }
    public void UpdateLevel(CharacterLevel charLevel)
    {
        level.text = $"LV: {charLevel.Level} + {Mathf.Floor(charLevel.Exp*1000f/charLevel.ExpToNextLevel)/10}%";
    }
}
