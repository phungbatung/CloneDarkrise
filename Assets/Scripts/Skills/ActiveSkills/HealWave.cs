using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealWave : Skill
{
    protected override void Start()
    {
        base.Start();
    }
    public override void Called()
    {
        base.Called();
        player.stateMachine.ChangeState(player.healState);
    }

    public void Healing()
    {
        SkillLevelData healWaveLevelData = SkillData.levelsData[currentLevel];
        player.stats.HealthIncrement( healWaveLevelData.GetProperty<int>(SkillLevelData.Key.HEALTH_TO_REGEN), 
                           healWaveLevelData.GetProperty<int>(SkillLevelData.Key.HEALTH_PERCENTAGE_TO_REGEN));
    }

    //public override void FillData()
    //{
    //    string fileName = "HealWave";
    //    skillData.skillName = fileName;
    //    skillData.icon = Resources.Load<Sprite>($"SkillDatabase\\Skill_Icon\\{fileName}");
    //    string data = Resources.Load<TextAsset>($"SkillDatabase\\{fileName}").text;
    //    string[] rows = data.Split('\n');
    //    HealWaveLevelData levelData;
    //    for (int i = 1; i < rows.Length; i++)
    //    {
    //        levelData = new();
    //        string[] cells = rows[i].Split(",");
    //        if (int.TryParse(cells[0], out levelData.level))
    //        {
    //            levelData.coolDown = float.Parse(cells[1]);
    //            levelData.manaCost = int.Parse(cells[2]);
    //            levelData.healthToRegen = int.Parse(cells[3]);
    //            levelData.healthPercentageToRegen = int.Parse(cells[4]);
    //            levelData.castSpeed = int.Parse(cells[5]);
    //            levelData.description = cells[6];
    //            skillData.levelsData.Add(levelData);
    //        }
    //    }
    //}

    public override string GetDescription()
    {
        SkillLevelData currentLevelData = SkillData.levelsData[currentLevel] ;
        string desc = $"Health to regen: {currentLevelData.GetProperty<string>(SkillLevelData.Key.HEALTH_TO_REGEN)} + {currentLevelData.GetProperty<string>(SkillLevelData.Key.HEALTH_PERCENTAGE_TO_REGEN)}%\n" +
                        $"Cooldown: {currentLevelData.GetProperty<string>(SkillLevelData.Key.COOLDOWN)}\n" +
                        $"Mana cost: {currentLevelData.GetProperty<string>(SkillLevelData.Key.MANA_COST)}";
        return desc;
    }
}
