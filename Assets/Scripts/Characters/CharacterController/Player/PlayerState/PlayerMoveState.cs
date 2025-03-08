using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.anim.speed = (100f + player.stats.moveSpeed.GetValue()) / 100f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.anim.speed = 1;
        player.SetVelocity(xInput * player.moveSpeed * (100f + player.stats.moveSpeed.GetValue()) / 100f, player.rb.velocity.y);
        if (xInput == 0)
            player.stateMachine.ChangeState(player.idleState);
    }
}
