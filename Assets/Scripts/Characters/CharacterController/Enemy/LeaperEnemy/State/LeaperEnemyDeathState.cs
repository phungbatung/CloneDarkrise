using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaperEnemyDeathState : CharacterState
{
    private LeaperEnemy enemy;
    public LeaperEnemyDeathState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        enemy = _character as LeaperEnemy;
    }
}