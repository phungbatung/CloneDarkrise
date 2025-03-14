using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData 
{
    public PlayerData PlayerData;
    public SettingData SettingData;
    public ActiveSkillData ActiveSkillData;
    public PassiveSkillData PassiveSkillData;
    public InventoryData InventoryData;
    public BuffData BuffData;
    public GameData() 
    {
        
    }

    public void InitNewGameData()
    {
        PlayerData = new();
        SettingData = new();
        ActiveSkillData = new();
        TextAsset txt = Resources.Load<TextAsset>("SkillTreeData/TestSkillTreeData");
        SkillTree skillTree = JsonUtility.FromJson<SkillTree>(txt.text);
        PassiveSkillData = new(skillTree);
        InventoryData = new();
        BuffData = new();
    }
}
