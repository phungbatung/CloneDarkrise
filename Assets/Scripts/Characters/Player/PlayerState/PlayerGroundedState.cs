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
        if (SkillManager.Instance.dash.CanBeUse())
            SkillManager.Instance.dash.Called();
        if (SkillManager.Instance.baseAttack.CanBeUse())
            SkillManager.Instance.baseAttack.Called();
        if (SkillManager.Instance.healWave.CanBeUse())
            SkillManager.Instance.healWave.Called();
        if (SkillManager.Instance.slash.CanBeUse())
            SkillManager.Instance.slash.Called();
        if (SkillManager.Instance.lightCut.CanBeUse())
            SkillManager.Instance.lightCut.Called();
        if (SkillManager.Instance.wolfCall.CanBeUse())
            SkillManager.Instance.wolfCall.Called();
    }
}
