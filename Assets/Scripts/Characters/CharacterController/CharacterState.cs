using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState
{
    public Character character;
    public StateMachine stateMachine;
    public string animBoolName;

    public float xInput;
    public float yVelocity;
    public bool triggerCalled=false;
    public float stateTimer;
    public CharacterState (Character _character, StateMachine _stateMachine, string _animBoolName)
    {
        character = _character;
        stateMachine = _stateMachine;
        animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        character.anim.SetBool(animBoolName, true);
        //Debug.Log(this.GetType().Name);
    }

    public virtual void Exit() 
    {
        triggerCalled = false;
        character.anim.SetBool(animBoolName, false);
    }

    public virtual void Update()
    {
        xInput = InputManager.Instance.horizontalInput;
        stateTimer -= Time.deltaTime;
    }

    public virtual void TriggerCall() => triggerCalled = true;
    public virtual void StateEvent()
    {

    }
    public virtual void PlaySFX()
    {

    }
}
