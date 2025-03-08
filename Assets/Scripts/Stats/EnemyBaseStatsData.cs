using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBaseStats", menuName = "Data/EnemyBaseStatsData")]
public class EnemyBaseStatsData : ScriptableObject
{
    public int damage;
    public int armorPenetration;
    public int criticalRate;
    public int criticalDamage;
    public int maxHealth;
    public int armor;

}
