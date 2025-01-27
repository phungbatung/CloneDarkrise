using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : CharacterState
{
    protected Player player;
    public PlayerDashState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        player = _character as Player;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.facingDir * player.dashSpeed, 0);

        if (stateTimer <= 0)
            stateMachine.ChangeState(player.idleState);
    }
}
