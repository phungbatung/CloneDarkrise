using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : CharacterState
{
    protected Player player;
    public PlayerAirState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        player = _character as Player;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(xInput * 9f, player.rb.velocity.y);
        if (InputManager.Instance.isSkill1Press)
            stateMachine.ChangeState(player.attackState);
        if (InputManager.Instance.isDashKeyPress)
            stateMachine.ChangeState(player.dashState);
    }
}
