using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, IDamageable
{
    #region Stats
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
    #endregion

    public bool isImmortal;

    #region Event
    public Action OnHealthChange;
    public Action OnManaChange;
    public Action Die;
    #endregion

    //To get Stat by key of item property quickly
    protected Dictionary<string, Stat> getStat = new Dictionary<string, Stat>();
    private void Awake()
    {
        getStat[Constant.DAMAGE] = damage;
        getStat[Constant.ATTACK_SPEED] = attackSpeed;
        getStat[Constant.ARMOR_PENETRATION] = armorPenetration;
        getStat[Constant.CRITICAL_RATE] = criticalRate;
        getStat[Constant.CRITICAL_DAMAGE] = criticalDamage;
        getStat[Constant.HEALTH] = maxHealth;
        getStat[Constant.HEALTH_REGEN] = healthRegen;
        getStat[Constant.ARMOR] = armor;
        getStat[Constant.MANA] = maxMana;
        getStat[Constant.MANA_REGEN] = manaRegen;
        getStat[Constant.MOVE_SPEED] = moveSpeed;
    }
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

    public virtual void AddModifier(Dictionary<string, string> _properties)
    {
        foreach (KeyValuePair<string, string> property in _properties)
        {
            getStat[property.Key].AddModifier(int.Parse(property.Value));
        }
    }
    public virtual void RemoveModifier(Dictionary<string, string> _properties)
    {
        foreach (KeyValuePair<string, string> property in _properties)
        {
            getStat[property.Key].RemoveModifier(int.Parse(property.Value));
        }
    }
}
