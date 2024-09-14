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
        HealWaveLevelData healWaveLevelData = skillData.levelsData[currentLevel] as HealWaveLevelData;
        player.stats.HealthChange( healWaveLevelData.healthToRegen, healWaveLevelData.healthPercentageToRegen);
    }

    public override void FillData()
    {
        string fileName = "HealWave";
        skillData.skillName = fileName;
        skillData.icon = Resources.Load<Sprite>($"SkillDatabase\\Skill_Icon\\{fileName}");
        string data = Resources.Load<TextAsset>($"SkillDatabase\\{fileName}").text;
        string[] rows = data.Split('\n');
        HealWaveLevelData levelData;
        for (int i = 1; i < rows.Length; i++)
        {
            levelData = new();
            string[] cells = rows[i].Split(",");
            if (int.TryParse(cells[0], out levelData.level))
            {
                levelData.coolDown = float.Parse(cells[1]);
                levelData.manaCost = int.Parse(cells[2]);
                levelData.healthToRegen = int.Parse(cells[3]);
                levelData.healthPercentageToRegen = int.Parse(cells[4]);
                levelData.castSpeed = int.Parse(cells[5]);
                levelData.description = cells[6];
                skillData.levelsData.Add(levelData);
            }
        }
    }

    public override string GetDescription()
    {
        HealWaveLevelData currentLevelData = skillData.levelsData[currentLevel] as HealWaveLevelData;
        string desc = $"Health to regen: {currentLevelData.healthToRegen} + {currentLevelData.healthPercentageToRegen}%\n" +
                        $"Cooldown: {currentLevelData.coolDown}\n" +
                        $"Mana cost: {currentLevelData.manaCost}";
        return desc;
    }
}
