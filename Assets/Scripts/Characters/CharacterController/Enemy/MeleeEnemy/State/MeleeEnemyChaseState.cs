using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyChaseState : CharacterState
{
    private MeleeEnemy enemy;
    public MeleeEnemyChaseState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        enemy = _character as MeleeEnemy;
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
        if (!enemy.IsPlayerInChaseRange())
        {
            stateMachine.ChangeState(enemy.idleState);
            return;
        }    
        if (enemy.IsGrounded() && enemy.IsPlayerInAttackRange())
        {
            stateMachine.ChangeState(enemy.attackState);
            return;
        }
        if (enemy.IsWallDetected()&&enemy.IsGrounded())
        {
            stateMachine.ChangeState(enemy.jumpState);
            return;
        }
        if(!enemy.IsGroundedAhead() && enemy.RawVerticalDistanceToPlayer() >= 0 && enemy.IsGrounded())
        {
            stateMachine.ChangeState(enemy.jumpState);
            return;
        }
        float dir = enemy.player.transform.position.x > enemy.transform.position.x ? 1 : -1;
        enemy.SetVelocity( dir * enemy.moveSpeed , enemy.rb.velocity.y);
    }
}
