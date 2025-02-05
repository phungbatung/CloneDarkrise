using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemChaseState : CharacterState
{
    private Golem golem;
    public GolemChaseState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        golem = _character as Golem;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("chase");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (!golem.IsPlayerInChaseRange())
        {
            stateMachine.ChangeState(golem.idleState);
            return;
        }    
        if (golem.IsPlayerInAttackRange())
        {
            stateMachine.ChangeState(golem.attackState);
            return;
        }
        if (golem.IsWallDetected()|| !golem.IsGroundAhead())
        {
            stateMachine.ChangeState(golem.jumpState);
            return;
        }
        float dir = golem.player.transform.position.x > golem.transform.position.x ? 1 : -1;
        golem.SetVelocity( dir * golem.stats.moveSpeed.GetValue(), golem.rb.velocity.y);
    }
}
