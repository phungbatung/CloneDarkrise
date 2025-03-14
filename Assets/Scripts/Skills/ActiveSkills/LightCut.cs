using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LightCut : Skill
{
    [SerializeField] private GameObject lightPrefabs;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Vector2 slashSize;

    protected override void Start()
    {
        base.Start();
    }
    public override void Called()
    {
        base.Called();
        player.stateMachine.ChangeState(player.lightCut);
    }

    public void Cut()
    {
        float distanceToMove=maxDistance;
        RaycastHit2D hit=Physics2D.Raycast(player.transform.position, new Vector2(player.facingDir, 0), maxDistance, wallLayer);
        if (hit == true)
            distanceToMove = hit.distance;
        player.transform.position = player.transform.position + new Vector3(player.facingDir*(distanceToMove-1f), 0, 0);
        CreateLightSlash();  
    }    

    private void CreateLightSlash()
    {
        GameObject lightSlash = Instantiate(lightPrefabs);
        lightSlash?.GetComponent<LightSlashController>()?.SetUpLightSlash(player, slashSize, this);
    }

    //public override void FillData()
    //{
    //    skillData = new();
    //    string fileName = "LightCut";
    //    skillData.skillName = fileName;
    //    skillData.icon = Resources.Load<Sprite>($"SkillDatabase\\Skill_Icon\\{fileName}");
    //    string data = Resources.Load<TextAsset>($"SkillDatabase\\{fileName}").text;
    //    string[] rows = data.Split('\n');
    //    LightCutLevelData levelData;
    //    for (int i = 1; i < rows.Length; i++)
    //    {
    //        levelData = new();
    //        string[] cells = rows[i].Split(",");
    //        if (int.TryParse(cells[0], out levelData.level))
    //        {
    //            levelData.coolDown = float.Parse(cells[1]);
    //            levelData.manaCost = int.Parse(cells[2]);
    //            levelData.damagePercentage = int.Parse(cells[3]);
    //            levelData.castSpeed = int.Parse(cells[4]);
    //            levelData.description = cells[5];
    //            skillData.levelsData.Add(levelData);
    //        }
    //    }
    //}

    public override string GetDescription()
    {
        SkillLevelData currentLevelData = SkillData.levelsData[currentLevel];
        string desc = $"Damage: {currentLevelData.GetProperty<int>(SkillLevelData.Key.DAMAGE_PERCENTAGE) * 1.0f / 100 * player.stats.damage.GetValue()}\n" +
                        $"Cast speed: {currentLevelData.GetProperty<string>(SkillLevelData.Key.CAST_SPEED)}%\n" +
                        $"Cooldown: {currentLevelData.GetProperty<string>(SkillLevelData.Key.COOLDOWN)}\n" +
                        $"Mana cost: {currentLevelData.GetProperty<string>(SkillLevelData.Key.COOLDOWN)}";
        return desc;
    }
}
