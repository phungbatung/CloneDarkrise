using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public bool canBeChase { get; set; } = true;
    [SerializeField] private Projectile projectile;
    protected override void Awake()
    {
        base.Awake();
        idleState = new RangedEnemyIdleState(this, stateMachine, "idle");
        chaseState = new RangedEnemyChaseState(this, stateMachine, "move");
        jumpState = new RangedEnemyJumpState(this, stateMachine, "jump");
        attackState = new RangedEnemyAttackState(this, stateMachine, "attack");
        deathState = new RangedEnemyDeathState(this, stateMachine, "death");

        stateMachine.InitialState(idleState);
    }
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    public RaycastHit2D IsPlayerInAttackRange()
    {
        Vector2 dir = player.transform.position - playerCheck.position;
        RaycastHit2D playerDetected = Physics2D.Raycast(playerCheck.position, dir, playerCheckDistance, playerLayer);
        RaycastHit2D wallDetected = Physics2D.Raycast(playerCheck.position, dir, playerCheckDistance, groundLayer);

        if (wallDetected)
        {
            if (wallDetected.distance < playerDetected.distance)
            {
                Debug.Log($"wall: {wallDetected.distance}, player: {playerDetected.distance}");
                return default;
            }
        }

        return playerDetected;
    }

    public Projectile CreateProjectile()
    {
        return Instantiate(projectile);
    }
    public void SetCanBeChase() => canBeChase = true;

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        if (player!=null) 
            Gizmos.DrawLine(playerCheck.position, player.transform.position);
    }
}
