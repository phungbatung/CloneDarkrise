using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointUI : MonoBehaviour
{
    private TextMeshProUGUI skillPoint;
    private void Awake()
    {
        skillPoint = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void UpdateUI(int _skillPoint)
    {
       skillPoint.text = _skillPoint.ToString();
    }
}
