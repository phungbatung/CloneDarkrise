using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimationTrigger : MonoBehaviour
{
    private Wolf player;

    private void Awake()
    {
        player = GetComponentInParent<Wolf>();
    }
    public void TriggerAnimation()
    {
        player.stateMachine.currentState.TriggerCall();
    }

    public void CallStateEvent()
    {
        player.stateMachine.currentState.StateEvent();
    }
}
