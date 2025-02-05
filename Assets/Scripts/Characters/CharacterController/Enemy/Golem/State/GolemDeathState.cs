using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemDeathState : CharacterState
{
    private Golem golem;
    public GolemDeathState(Character _character, StateMachine _stateMachine, string _animBoolName) : base(_character, _stateMachine, _animBoolName)
    {
        golem = _character as Golem;
    }
}
