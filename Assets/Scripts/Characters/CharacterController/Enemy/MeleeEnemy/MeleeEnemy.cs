using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    

    protected override void Awake()
    {
        base.Awake();
        idleState = new MeleeEnemyIdleState(this, stateMachine, "idle");
        chaseState = new MeleeEnemyChaseState(this, stateMachine, "move");
        jumpState = new MeleeEnemyJumpState(this, stateMachine, "jump");
        attackState = new MeleeEnemyAttackState(this, stateMachine, "attack");
        deathState = new MeleeEnemyDeathState(this, stateMachine, "death");

        stateMachine.InitialState(idleState);
    }
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    public RaycastHit2D IsPlayerInAttackRange()
    {
        return Physics2D.Raycast(playerCheck.position, Vector2.right, playerCheckDistance, playerLayer);
    }
    public override void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, targetLayer);
        foreach (Collider2D collider in colliders)
        {
            IDamageable target = collider.GetComponent<IDamageable>();
            if (target == null)
            {
                continue;
            }
            stats.DoDamage(target);
        }
    }
}
