using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimationTrigger : MonoBehaviour
{
    private Wolf wolf;

    private void Awake()
    {
        wolf = GetComponentInParent<Wolf>();
    }
    public void TriggerAnimation()
    {
        wolf.stateMachine.currentState.TriggerCall();
    }

    public void CallStateEvent()
    {
        wolf.stateMachine.currentState.StateEvent();
    }
}
