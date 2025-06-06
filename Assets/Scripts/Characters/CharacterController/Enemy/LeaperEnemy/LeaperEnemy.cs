using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaperEnemy : Enemy
{
    private float maxJumpHeight;
    private float waitToJumpTime = 1f;
    protected override void Awake()
    {
        base.Awake();
        idleState = new LeaperEnemyIdleState(this, stateMachine, "idle");
        chaseState = new LeaperEnemyChaseState(this, stateMachine, "move");
        jumpState = new LeaperEnemyJumpState(this, stateMachine, "jump");
        attackState = new LeaperEnemyAttackState(this, stateMachine, "attack");
        deathState = new LeaperEnemyDeathState(this, stateMachine, "death");

        stateMachine.InitialState(idleState);
    }

    protected override void Start()
    {
        base.Start();
        float t = - jumpForce / (rb.gravityScale * Physics2D.gravity.y);
        maxJumpHeight = jumpForce * t + 0.5f * (rb.gravityScale * Physics2D.gravity.y) * t * t;
    }
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    public bool IsPlayerInAttackRange()
    {
        return HorizontalDistanceToPlayer() <= playerCheckDistance && VerticalDistanceToPlayer()<= maxJumpHeight;
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

    public void DoJumpToPlayer()
    {
        StartCoroutine(JumpToPlayer());
    }
    private IEnumerator JumpToPlayer()
    {
        yield return new WaitForSeconds(waitToJumpTime);
        float v0 = jumpForce;
        float g = -rb.gravityScale * Physics2D.gravity.y;
        float t = v0 / g + Mathf.Sqrt(2 * (v0 * v0 / (2 * g) - RawVerticalDistanceToPlayer()) / g); //Physic formular
        float xVelocity = (player.transform.position.x - transform.position.x) / t;
        SetVelocity(xVelocity, jumpForce);
    }
        
}