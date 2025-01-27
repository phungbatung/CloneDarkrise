using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsTrigger : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
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
