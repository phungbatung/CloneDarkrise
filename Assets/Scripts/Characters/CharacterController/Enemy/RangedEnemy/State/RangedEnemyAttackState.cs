using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttackState : CharacterState
{
    private RangedEnemy enemy;
    public RangedEnemyAttackState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        enemy = _character as RangedEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetZeroVelocity();
        if (enemy.facingDir * enemy.RawHorizontalDistanceToPlayer() < 0)
            enemy.Flip();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(0, enemy.rb.velocity.y);
        if (triggerCalled)
            stateMachine.ChangeState(enemy.idleState);
    }

    public override void StateEvent()
    {
        Projectile projectile = enemy.CreateProjectile();
        Vector2 flyDir = enemy.player.transform.position - enemy.playerCheck.position;
        projectile.SetupProjectile(enemy.stats, enemy.targetLayer, enemy.playerCheck.position, 
                                    flyDir, enemy.playerCheckDistance, enemy.SetCanBeChase);
        enemy.canBeChase = false;
    }
}
