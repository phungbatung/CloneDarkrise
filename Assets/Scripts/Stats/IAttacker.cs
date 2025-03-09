using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker 
{
    public void DoDamage(IDamageable target, float damagePercentage = 100f);
    public void OnAttackDealt(IDamageable target);
}
