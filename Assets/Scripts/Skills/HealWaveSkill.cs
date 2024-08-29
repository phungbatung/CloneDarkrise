using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealWaveSkill : Skill
{
    [SerializeField] private int healthToRegen;
    [SerializeField] private int healthPercentToRegen;
    public override void Called()
    {
        base.Called();
        player.stateMachine.ChangeState(player.healState);
    }

    public void Healing()
    {
        player.stats.HealthChange(healthToRegen, healthPercentToRegen);
    }    
}
