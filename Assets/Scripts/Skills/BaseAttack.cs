using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : Skill
{
    [SerializeField] Vector2[] attackPoint;
    [SerializeField] private float[] attackRadius;
    public override void Called()
    {
        player.stateMachine.ChangeState(player.attackState);
    }

    public void Attack(int comboIndex)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position + player.facingDir * (Vector3)attackPoint[comboIndex], attackRadius[comboIndex]);
        foreach (Collider2D collider in colliders)
        {
            IDamageable target = collider.GetComponent<IDamageable>();
            if (target != null)
            {
                player.stats.DoDamage(target);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint[0], attackRadius[0]);
    }
}
