using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttackState : CharacterState
{
    private Golem golem;
    public GolemAttackState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        golem = _character as Golem;
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
    }

    public override void StateEvent()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(golem.attackPoint.position, golem.attackRadius, golem.targetLayer);
        foreach (Collider2D collider in colliders)
        {
            IDamageable target = collider.GetComponent<IDamageable>();
            if (target != null)
            {
                golem.stats.DoDamage(target);
            }
        }
    }

}
