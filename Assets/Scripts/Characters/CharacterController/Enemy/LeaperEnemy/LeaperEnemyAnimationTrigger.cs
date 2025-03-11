using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaperEnemyAnimationTrigger : MonoBehaviour
{
    private LeaperEnemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<LeaperEnemy>();
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