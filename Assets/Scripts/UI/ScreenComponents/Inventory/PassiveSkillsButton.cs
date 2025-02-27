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
        TextAsset txt = Resources.Load<TextAsset>("SkillTreeData/TestSkillTreeData");

        SkillTree skillTree = JsonUtility.FromJson<SkillTree>(txt.text);
        data.Add("SkillTree", skillTree);
        BlitzyUI.UIManager.Instance.QueuePush(GameManager.passiveSkillsScreen, data);
    }
}
