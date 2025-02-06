using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyDeathState : CharacterState
{
    private MeleeEnemy enemy;
    public MeleeEnemyDeathState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        enemy = _character as MeleeEnemy;
    }
}
