using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    public GolemAttackState attackState { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        attackState = new GolemAttackState(this, stateMachine, "attack");
        stateMachine.InitialState(attackState);
    }
}
