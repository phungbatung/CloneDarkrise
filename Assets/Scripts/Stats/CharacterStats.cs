using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, IDamageable
{
    public Stat damage;
    public Stat attackSpeed;
    public Stat armorPenetration;
    public Stat criticalRate;
    public Stat criticalDamage;

    public Stat maxHealth;
    public Stat healthRegen;
    public Stat armor;

    public Stat maxMana;
    public Stat manaRegen;
    public Stat moveSpeed;

    public int currentHealth;
    public int currentMana;

    public bool isImmortal;

    public Action OnHealthChange;
    public Action OnManaChange;
    public Action Die;

    public virtual void TakeDamage(int _damage = 0, int _critRate = 0, int _critDamage = 0, int _armorPenetration = 0)
    {
        if (isImmortal)
            return;
        int finalDamage=_damage;
        //calculate critical
        bool critical = UnityEngine.Random.Range(0, 100) <= _critRate;
        if (critical)
            finalDamage = (int)(finalDamage * (float)(_critDamage)/100);
        //apply armor
        int finalArmor = armor.GetValue() >  _armorPenetration ? armor.GetValue() - _armorPenetration : 0;
        finalDamage -= finalArmor;

        currentHealth = currentHealth>finalDamage? (currentHealth-finalDamage) : 0;
        if (currentHealth <= 0 && Die!=null)
            Die();
    }

    public virtual void DoDamage(IDamageable target)
    {
        target.TakeDamage(damage.GetValue(), criticalRate.GetValue(), criticalDamage.GetValue(), armorPenetration.GetValue());
    }
}
