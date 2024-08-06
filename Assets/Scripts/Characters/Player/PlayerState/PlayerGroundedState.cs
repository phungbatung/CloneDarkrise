using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : CharacterState
{
    protected Player player;

    public PlayerGroundedState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
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
        if (!player.Grounded())
            stateMachine.ChangeState(player.fallState);
        if (InputManager.Instance.isUpButtonPress)
            stateMachine.ChangeState(player.jumpState);
        if (InputManager.Instance.isSkill1Press)
            stateMachine.ChangeState(player.attackState);
        if (InputManager.Instance.isDashKeyPress)
            stateMachine.ChangeState(player.dashState);

        if (Input.GetKeyDown(KeyCode.E))
            stateMachine.ChangeState(player.slashState);
    }
}
