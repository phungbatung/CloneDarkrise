using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyDeathState : CharacterState
{
    private RangedEnemy enemy;
    public RangedEnemyDeathState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        enemy = _character as RangedEnemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
