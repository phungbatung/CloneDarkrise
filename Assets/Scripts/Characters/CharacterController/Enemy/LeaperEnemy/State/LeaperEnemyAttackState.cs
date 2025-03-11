using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class LeaperEnemyAttackState : CharacterState
{
    private LeaperEnemy enemy;
    private bool isOutOfTheGround;
    public LeaperEnemyAttackState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        enemy = _character as LeaperEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        if (enemy.facingDir * enemy.RawHorizontalDistanceToPlayer() < 0)
            enemy.Flip();

        enemy.SetZeroVelocity();
        isOutOfTheGround = false;
        enemy.DoJumpToPlayer();
        Debug.Log("attack");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (isOutOfTheGround && enemy.IsGrounded())
        {
            Debug.Log("do attack");
            enemy.Attack();
            stateMachine.ChangeState(enemy.idleState);
        }
        isOutOfTheGround = isOutOfTheGround || !enemy.IsGrounded();
            
    }

    private void DoJump()
    {
        float v0 = enemy.jumpForce;
        float g = -enemy.rb.gravityScale * Physics2D.gravity.y;
        float t = v0 / g + Mathf.Sqrt(2 * (v0 * v0 / (2 * g) - enemy.RawVerticalDistanceToPlayer()) / g); //Physic formular
        float xVelocity = (enemy.player.transform.position.x - enemy.transform.position.x) / t;
        enemy.SetVelocity(xVelocity, enemy.jumpForce);
        
    }
}