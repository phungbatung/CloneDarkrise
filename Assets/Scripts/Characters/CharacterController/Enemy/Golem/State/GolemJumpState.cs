using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemJumpState : CharacterState
{
    private Golem golem;
    public GolemJumpState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        golem = _character as Golem;
    }

    public override void Enter()
    {
        base.Enter();
        golem.SetVelocity(golem.facingDir * golem.stats.moveSpeed.GetValue()*1.5f, golem.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (golem.IsGrounded())
            stateMachine.ChangeState(golem.idleState);
    }
}
