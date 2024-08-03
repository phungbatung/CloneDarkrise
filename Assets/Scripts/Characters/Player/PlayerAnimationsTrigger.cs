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

    public void PrimaryAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackPoint.position, player.attackRadius);
        foreach (Collider2D collider in colliders)
        {
            IDamageable target = collider.GetComponent<IDamageable>();
            if (target != null)
            {
                player.stats.DoDamage(target);
            }
        }
    }
}
