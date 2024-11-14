using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttackState : CharacterState
{
    private Wolf wolf;
    public WolfAttackState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
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
        wolf.SetVelocity(0, wolf.rb.velocity.y);
        if (triggerCalled)
            stateMachine.ChangeState(wolf.battleState);
    }
    public override void StateEvent()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(wolf.attackPoint.position, wolf.attackRadius, wolf.enemyLayer);
        foreach (Collider2D collider in colliders)
        {
            IDamageable target = collider.GetComponent<IDamageable>();
            if (target != null)
            {
                wolf.stats.DoDamage(target);
            }
        }
    }

}
