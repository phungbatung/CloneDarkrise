using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyIdleState : CharacterState
{
    private MeleeEnemy enemy;
    public MeleeEnemyIdleState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        enemy = _character as MeleeEnemy;
    }

    public override void Enter()
    {
        Debug.Log("idle");
        base.Enter();
        enemy.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemy.IsPlayerInChaseRange())
        {
            stateMachine.ChangeState(enemy.chaseState);
        }
    }
}
