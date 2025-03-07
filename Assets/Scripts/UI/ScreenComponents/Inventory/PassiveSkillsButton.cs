using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveSkillsButton : MonoBehaviour
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ClickEvent);
    }

    public void ClickEvent()
    {
        BlitzyUI.Screen.Data data = new();
        data.Add("SkillTree", PassiveSkills.Instance.skillTree);
        BlitzyUI.UIManager.Instance.QueuePush(GameManager.passiveSkillsScreen, data);
    }
}
