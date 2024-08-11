using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWolfCallState : CharacterState
{
    private Player player;
    public PlayerWolfCallState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
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
        player.SetZeroVelocity();
        if (triggerCalled)
            stateMachine.ChangeState(player.idleState);
    }
    public override void StateEvent()
    {
        SkillManager.Instance.wolfCall.WolfsCall();
    }

}
