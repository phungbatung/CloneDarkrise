using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : Skill
{
    [SerializeField] private Vector2 attackPoint;
    [SerializeField] private float attackRadius;
    public override void Called()
    {
        base.Called();
        player.stateMachine.ChangeState(player.slashState);
    }

    public void AttackSlash()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position + player.facingDir * (Vector3)attackPoint, attackRadius);
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
