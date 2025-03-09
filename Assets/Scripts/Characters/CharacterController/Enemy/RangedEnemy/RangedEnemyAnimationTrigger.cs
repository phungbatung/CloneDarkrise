using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAnimationTrigger : MonoBehaviour
{
    private RangedEnemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<RangedEnemy>();
    }
    public void TriggerAnimation()
    {
        enemy.stateMachine.currentState.TriggerCall();
    }

    public void CallStateEvent()
    {
        enemy.stateMachine.currentState.StateEvent();
    }
}
