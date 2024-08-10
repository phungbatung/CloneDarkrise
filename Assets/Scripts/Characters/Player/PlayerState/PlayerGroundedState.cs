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
        if (!player.IsGrounded())
            stateMachine.ChangeState(player.fallState);
        if (InputManager.Instance.isUpButtonPress)
            stateMachine.ChangeState(player.jumpState);
        if (InputManager.Instance.isDashKeyPress)
            stateMachine.ChangeState(player.dashState);
        if (InputManager.Instance.isBaseAttackPress)
            SkillManager.Instance.baseAttack.Called();
        if (InputManager.Instance.isSkill1Press)
            SkillManager.Instance.healWave.Called();
        if (InputManager.Instance.isSkill2Press)
            SkillManager.Instance.slash.Called();
        if (InputManager.Instance.isSkill3Press)
            SkillManager.Instance.lightCut.Called();
    }
}
