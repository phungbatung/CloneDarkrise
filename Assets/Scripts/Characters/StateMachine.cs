using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public CharacterState currentState;

    public void InitialState(CharacterState _initState)
    {
        currentState = _initState;
        currentState.Enter();
    }

    public void ChangeState(CharacterState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
