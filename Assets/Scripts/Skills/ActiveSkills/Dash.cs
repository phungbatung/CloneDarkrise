using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Skill
{
    protected override void Start()
    {
        base.Start();
    }
    public override void Called()
    {
        base.Called();
        player.stateMachine.ChangeState(player.dashState);
    }

    //public override void FillData()
    //{
    //    string fileName = "Dash";
    //    skillData.skillName = fileName;
    //    skillData.icon = Resources.Load<Sprite>($"SkillDatabase\\Skill_Icon\\{fileName}");
    //    string data = Resources.Load<TextAsset>($"SkillDatabase\\{fileName}").text;
    //    string[] rows = data.Split('\n');
    //    DashLevelData levelData;
    //    for (int i = 1; i < rows.Length; i++)
    //    {
    //        levelData = new();
    //        string[] cells = rows[i].Split(",");
    //        if (int.TryParse(cells[0], out levelData.level))
    //        {
    //            levelData.coolDown = float.Parse(cells[1]);
    //            levelData.manaCost = int.Parse(cells[2]);
    //            levelData.description = cells[3];
    //            skillData.levelsData.Add(levelData);
    //        }
    //    }
    //}

    public override string GetDescription()
    {
        SkillLevelData currentLevelData = SkillData.levelsData[currentLevel];
        string desc = $"Cooldown: {currentLevelData.GetProperty<string>(SkillLevelData.Key.COOLDOWN)}\n" +
                        $"Mana cost: {currentLevelData.GetProperty<string>(SkillLevelData.Key.MANA_COST)}";
        return desc;
    }
}
