using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : Skill
{
    [SerializeField] private Vector2 attackPoint;
    [SerializeField] private float attackRadius;

    protected override void Start()
    {
        base.Start();
    }
    public override void Called()
    {
        base.Called();
        player.stateMachine.ChangeState(player.slashState);
    }

    public void Attack()
    {
        SlashLevelData slashLevelData = skillData.levelsData[currentLevel] as SlashLevelData;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position + player.facingDir * (Vector3)attackPoint, attackRadius, player.targetLayer);
        foreach (Collider2D collider in colliders)
        {
            IDamageable target = collider.GetComponent<IDamageable>();
            if (target != null)
            {
                player.stats.DoDamage(target, slashLevelData.damagePercentage);
            }
        }
    }

    public override void FillData()
    {
        skillData = new();
        string fileName = "Slash";
        skillData.skillName = fileName;
        skillData.icon = Resources.Load<Sprite>($"SkillDatabase\\Skill_Icon\\{fileName}");
        string data = Resources.Load<TextAsset>($"SkillDatabase\\{fileName}").text;
        string[] rows = data.Split('\n');
        SlashLevelData levelData;
        for (int i = 1; i < rows.Length; i++)
        {
            levelData = new();
            string[] cells = rows[i].Split(",");
            if (int.TryParse(cells[0], out levelData.level))
            {
                levelData.coolDown = float.Parse(cells[1]);
                levelData.manaCost = int.Parse(cells[2]);
                levelData.damagePercentage = int.Parse(cells[3]);
                levelData.castSpeed = int.Parse(cells[4]);
                levelData.description = cells[5];
                skillData.levelsData.Add(levelData);
            }
        }
    }

    public override string GetDescription()
    {
        SlashLevelData currentLevelData = skillData.levelsData[currentLevel] as SlashLevelData;
        string desc = $"Damage: {currentLevelData.damagePercentage * 1.0f / 100 * player.stats.damage.GetValue()}\n" +
                        $"Cast speed: {currentLevelData.castSpeed}%\n" +
                        $"Cooldown: {currentLevelData.coolDown}\n" +
                        $"Mana cost: {currentLevelData.manaCost}";
        return desc;
    }
}
