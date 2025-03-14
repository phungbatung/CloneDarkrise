using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkills : MonoBehaviour, ISaveManager
{
    public static PassiveSkills Instance {  get; private set; }

    public SkillTree skillTree { get; private set; }


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        InitSkillTree();
    }

    public void InitSkillTree()
    {
        TextAsset txt = Resources.Load<TextAsset>("SkillTreeData/TestSkillTreeData");
        skillTree = JsonUtility.FromJson<SkillTree>(txt.text);
    }

    public void SaveData(ref GameData gameData)
    {
        PassiveSkillData dataSave = new PassiveSkillData(skillTree);
        gameData.PassiveSkillData = dataSave;
    }

    public void LoadData(GameData gameData)
    {
        skillTree = gameData.PassiveSkillData.skillTree;
        foreach(var node in skillTree.skillNodes)
        {
            if (node.unlocked)
            {
                skillTree.ApplyStat(node);
            }    
        }    
    }
}
