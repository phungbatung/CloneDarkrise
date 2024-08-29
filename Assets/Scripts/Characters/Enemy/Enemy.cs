using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [Header("Attack info")]
    [SerializeField] public Transform attackPoint;
    [SerializeField] public float attackRadius;
    [SerializeField] public LayerMask targetLayer;
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
