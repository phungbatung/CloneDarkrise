using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttackState : CharacterState
{
    private MeleeEnemy enemy;
    public MeleeEnemyAttackState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        enemy = _character as MeleeEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetZeroVelocity();
        if (enemy.facingDir * enemy.RawHorizontalDistanceToPlayer() < 0)
            enemy.Flip();
        Debug.Log("attack");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(0, enemy.rb.velocity.y);
        if (triggerCalled)
            stateMachine.ChangeState(enemy.idleState);
    }

    public override void StateEvent()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackPoint.position, enemy.attackRadius, enemy.targetLayer);
        foreach (Collider2D collider in colliders)
        {
            IDamageable target = collider.GetComponent<IDamageable>();
            if (target == null)
            {
                continue;
            }
            enemy.stats.DoDamage(target);
        }
    }

}
