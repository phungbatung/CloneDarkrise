using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData 
{
    public PlayerSaveData PlayerData;
    public SettingSaveData SettingData;
    public ActiveSkillSaveData ActiveSkillData;
    public PassiveSkillSaveData PassiveSkillData;
    public InventorySaveData InventoryData;
    public BuffSaveData BuffData;
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
