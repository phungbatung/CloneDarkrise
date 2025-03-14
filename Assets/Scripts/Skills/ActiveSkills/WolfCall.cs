using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCall : Skill
{
    [SerializeField] private GameObject wolfPrefab;
    [SerializeField] private Vector3 spawnPosition;

    protected override void Start()
    {
        base.Start();
    }
    public override void Called()
    {
        base.Called();
        player.stateMachine.ChangeState(player.wolfCall);
    }

    public void WolfsCall()
    {
        SkillLevelData wolfCallLevelData = SkillData.levelsData[currentLevel];
        int quantity = wolfCallLevelData.GetProperty<int>(SkillLevelData.Key.QUANTITY);
        for (int i=0; i< quantity; i++)
        {
            GameObject wolf = Instantiate(wolfPrefab);
            Vector3 offset;
            if (i == 0)
                offset = new Vector3(player.facingDir * spawnPosition.x, spawnPosition.y, spawnPosition.z);
            else if (i == 1)
                offset = new Vector3(-player.facingDir * spawnPosition.x, spawnPosition.y, spawnPosition.z);
            else
                offset = new Vector3(0, spawnPosition.y, spawnPosition.z);
            wolf.GetComponent<Wolf>().SetUpWolf(player, player.transform.position + offset, wolfCallLevelData);
        }
    }

    //public override void FillData()
    //{
    //    skillData = new();
    //    string fileName = "WolfCall";
    //    skillData.skillName = fileName;
    //    skillData.icon = Resources.Load<Sprite>($"SkillDatabase\\Skill_Icon\\{fileName}");
    //    string data = Resources.Load<TextAsset>($"SkillDatabase\\{fileName}").text;
    //    string[] rows = data.Split('\n');
    //    WolfCallLevelData levelData;
    //    for (int i = 1; i < rows.Length; i++)
    //    {
    //        levelData = new();
    //        string[] cells = rows[i].Split(",");
    //        if (int.TryParse(cells[0], out levelData.level))
    //        {
    //            levelData.coolDown = float.Parse(cells[1]);
    //            levelData.manaCost = int.Parse(cells[2]);
    //            levelData.statPercentage = float.Parse(cells[3]);
    //            levelData.quantity = int.Parse(cells[4]);
    //            levelData.lifespan = int.Parse(cells[5]);
    //            levelData.description = cells[6];
    //            skillData.levelsData.Add(levelData);
    //        }
    //    }
    //}

    public override string GetDescription()
    {
        SkillLevelData currentLevelData = SkillData.levelsData[currentLevel] ;
        string desc = $"Damage: {currentLevelData.GetProperty<int>(SkillLevelData.Key.STAT_PERCENTAGE) * 1.0f / 100 * player.stats.damage.GetValue()}\n" +
                        $"Health: {currentLevelData.GetProperty<int>(SkillLevelData.Key.STAT_PERCENTAGE) * 1.0f / 100 * player.stats.maxHealth.GetValue()}\n" +
                        $"Quantity: {currentLevelData.GetProperty<string>(SkillLevelData.Key.QUANTITY)}\n" +
                        $"Lifespan: {currentLevelData.GetProperty<string>(SkillLevelData.Key.LIFESPAN)}\n" +
                        $"Cooldown: {currentLevelData.GetProperty<string>(SkillLevelData.Key.COOLDOWN)}\n" +
                        $"Mana cost: {currentLevelData.GetProperty<string>(SkillLevelData.Key.MANA_COST)}";
        return desc;
    }
}
