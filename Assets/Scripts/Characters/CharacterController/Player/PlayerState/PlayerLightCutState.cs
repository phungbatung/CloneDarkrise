using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightCutState : CharacterState
{
    protected Player player;
    public PlayerLightCutState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
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
        SkillManager.Instance.lightCut.Cut();
    }
}
