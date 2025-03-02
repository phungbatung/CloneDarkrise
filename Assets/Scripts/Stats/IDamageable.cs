using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(int _damage=0, int _critRate=0, int _critDamage=0, int _armorPenetration=0);
}
