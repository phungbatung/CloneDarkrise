using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAnimationTrigger : MonoBehaviour
{
    private MeleeEnemy golem;

    private void Awake()
    {
        golem = GetComponentInParent<MeleeEnemy>();
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
