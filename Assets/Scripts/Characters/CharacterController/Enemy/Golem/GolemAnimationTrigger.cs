using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAnimationTrigger : MonoBehaviour
{
    private Golem golem;

    private void Awake()
    {
        golem = GetComponentInParent<Golem>();
    }
    public void TriggerAnimation()
    {
        golem.stateMachine.currentState.TriggerCall();
    }

    public void CallStateEvent()
    {
        golem.stateMachine.currentState.StateEvent();
    }
}
