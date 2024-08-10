using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : CharacterState
{
    protected Player player;

    protected int airComboCounter=0;
    protected int airComboStack=2;
    protected float airLastTimeAttack=0;
    
    protected int groundComboCounter=0;
    protected int groundComboStack=3;
    protected float groundLastTimeAttack=0;


    protected float timeBreakCombo=4f;

    public PlayerPrimaryAttack(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        player = _character as Player;
    }

    public override void Enter()
    {
        base.Enter();
        xInput = 0;
        player.SetZeroVelocity();
        if (player.IsGrounded())
        {
            player.anim.SetBool("grounded", true);
            if (groundComboCounter >= groundComboStack || (Time.time - groundLastTimeAttack) > timeBreakCombo)
            {
                groundComboCounter = 0;
            }
            player.anim.SetInteger("groundCounter", groundComboCounter);
            groundComboCounter++;
        }
        else
        {
            player.anim.SetBool("grounded", false);
            if (airComboCounter >= airComboStack || (Time.time - airLastTimeAttack) > timeBreakCombo)
            {
                airComboCounter = 0;
                
            }
            player.anim.SetInteger("airCounter", airComboCounter);
            airComboCounter++; 
        }
    }

    public override void Exit()
    {
        base.Exit();
        if (player.IsGrounded())
            groundLastTimeAttack = Time.time;
        else
            airLastTimeAttack = Time.time;
    }

    public override void Update()
    {
        base.Update();
        player.SetZeroVelocity();
        if (triggerCalled)
            if (player.IsGrounded())
                stateMachine.ChangeState(player.idleState);
            else
                stateMachine.ChangeState(player.fallState);
    }

    public override void StateEvent()
    {
        if (player.IsGrounded())
            SkillManager.Instance.baseAttack.Attack(groundComboCounter-1);
        else
            SkillManager.Instance.baseAttack.Attack(airComboCounter-1);
            
    }
}
