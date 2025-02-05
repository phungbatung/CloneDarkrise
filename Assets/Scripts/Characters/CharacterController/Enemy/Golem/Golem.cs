using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    public GolemIdleState idleState { get; private set; }
    public GolemChaseState chaseState { get; private set; }
    public GolemJumpState jumpState { get; private set; }
    public GolemAttackState attackState { get; private set; }
    public GolemDeathState deathState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        idleState = new GolemIdleState(this, stateMachine, "idle");
        chaseState = new GolemChaseState(this, stateMachine, "move");
        jumpState = new GolemJumpState(this, stateMachine, "jump");
        attackState = new GolemAttackState(this, stateMachine, "attack");
        deathState = new GolemDeathState(this, stateMachine, "death");

        stateMachine.InitialState(idleState);
    }
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }
}
