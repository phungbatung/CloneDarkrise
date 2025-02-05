using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class WolfMoveState : CharacterState
{
    private Wolf wolf;
    public WolfMoveState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        wolf = _character as Wolf;
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
        wolf.SetVelocity( wolf.facingDir * wolf.stats.moveSpeed.GetValue(), 0);

        if (wolf.facingDir * (wolf.transform.position.x - wolf.player.transform.position.x) > 0)
            wolf.Flip();
        if (wolf.IsWallDetected())
            stateMachine.ChangeState(wolf.jumpState);
        if (wolf.HorizontalDistanceToPlayer() <= wolf.maxDistanceXToPlayer)
            stateMachine.ChangeState(wolf.idleState);
        if (wolf.IsDetectEnenmy())
            stateMachine.ChangeState(wolf.battleState);
    }
}
