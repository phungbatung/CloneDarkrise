using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAnimationTrigger : MonoBehaviour
{
    private MeleeEnemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<MeleeEnemy>();
    }
    public void TriggerAnimation()
    {
        enemy?.stateMachine.currentState.TriggerCall();
    }

    public void CallStateEvent()
    {
        enemy.stateMachine.currentState.StateEvent();
    }
}
