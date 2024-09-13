using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlashState : CharacterState
{
    protected Player player;
    public PlayerSlashState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
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
        player.SetZeroVelocity();
        base.Update();
        if (triggerCalled)
            stateMachine.ChangeState(player.idleState);
    }
    public override void StateEvent()
    {
        SkillManager.Instance.slash.Attack();
    }
}
