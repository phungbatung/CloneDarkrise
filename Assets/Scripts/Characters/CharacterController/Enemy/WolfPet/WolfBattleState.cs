using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class WolfBattleState : CharacterState
{
    private Wolf wolf;
    public WolfBattleState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
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
        if (!wolf.IsDetectEnenmy())
            stateMachine.ChangeState(wolf.idleState);
        else
            if (wolf.facingDir * (wolf.transform.position.x - wolf.IsDetectEnenmy().transform.position.x) > 0)
                wolf.Flip();
        if (wolf.IsEnemyInAttackRange())
        {
            stateMachine.ChangeState(wolf.attackState);
            return;
        }
        wolf.SetVelocity(wolf.facingDir * wolf.moveSpeed, 0);
    }
}
