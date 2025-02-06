using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public MeleeEnemyIdleState idleState { get; private set; }
    public MeleeEnemyChaseState chaseState { get; private set; }
    public MeleeEnemyJumpState jumpState { get; private set; }
    public MeleeEnemyAttackState attackState { get; private set; }
    public MeleeEnemyDeathState deathState { get; private set; }

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
}
