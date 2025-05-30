using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(LevelUp);
    }

    private void LevelUp()
    {
        PlayerManager.Instance.player.levels.LevelUp();
    }
}
