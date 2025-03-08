using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyJumpState : CharacterState
{
    private MeleeEnemy enemy;
    public MeleeEnemyJumpState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        enemy = _character as MeleeEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        float dir = enemy.player.transform.position.x > enemy.transform.position.x ? 1 : -1;
        enemy.SetVelocity(dir * enemy.moveSpeed*1.5f, enemy.jumpForce);
        Debug.Log("jump");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(enemy.facingDir * enemy.stats.moveSpeed.GetValue() * 1.5f, enemy.rb.velocity.y);
        if (enemy.IsGrounded())
            stateMachine.ChangeState(enemy.idleState);
    }
}
