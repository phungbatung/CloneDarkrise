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

    public Action OnHealthChanged { get; set; }
    public Action OnManaChanged { get; set; }
    public Action OnDied { get; set; }

    //To get Stat by key of item property quickly
    private Dictionary<string, Stat> getStatByName = new();

    [SerializeField] private GameObject buffPrefab;
    [SerializeField] private Transform buffHolder;

    private Dictionary<int, Stat> getStatByBuffType = new();    //<buffType, Stat>
    public Dictionary<int, StatBuff> buffDict = new();  //<buffType, StatBuff>


    private void Awake()
    {
        InitGetStatByNameDict();
        InitGetStatByBuffTypeDict();
        currentHealth = maxHealth.GetValue();
    }

    private void InitGetStatByBuffTypeDict()
    {
        getStatByBuffType[1] = damage;
        getStatByBuffType[2] = maxHealth;
    }

    private void InitGetStatByNameDict()
    {
        getStatByName[ItemUtilities.DAMAGE] = damage;
        getStatByName[ItemUtilities.ATTACK_SPEED] = attackSpeed;
        getStatByName[ItemUtilities.ARMOR_PENETRATION] = armorPenetration;
        getStatByName[ItemUtilities.CRITICAL_RATE] = criticalRate;
        getStatByName[ItemUtilities.CRITICAL_DAMAGE] = criticalDamage;
        getStatByName[ItemUtilities.HEALTH] = maxHealth;
        getStatByName[ItemUtilities.HEALTH_REGEN] = healthRegen;
        getStatByName[ItemUtilities.ARMOR] = armor;
        getStatByName[ItemUtilities.MANA] = maxMana;
        getStatByName[ItemUtilities.MANA_REGEN] = manaRegen;
        getStatByName[ItemUtilities.MOVE_SPEED] = moveSpeed;
    }

    public void TakeDamage(int _damage = 0, int _critRate = 0, int _critDamage = 0, int _armorPenetration = 0)
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

        HealthIncrement(-finalDamage);
        if (currentHealth <= 0 && OnDied!=null)
            OnDied();
    }

    public void DoDamage(IDamageable target, float damagePercentage = 100f)
    {
        target.TakeDamage((int)(damage.GetValue() * (damagePercentage/100)), criticalRate.GetValue(), criticalDamage.GetValue(), armorPenetration.GetValue());
    }

    public void AddModifier(Dictionary<string, string> _properties, int _itemId = -1)
    {
        if (_itemId != -1)
        {
            string baseStat = ItemUtilities.GetBaseStatOfEquipment(_itemId);
            getStatByName[baseStat].AddModifier(int.Parse(ItemManager.Instance.itemDict[_itemId].properties[baseStat]));
        }
        foreach (KeyValuePair<string, string> property in _properties)
        {
            if (getStatByName.TryGetValue(property.Key, out Stat stat))
            {
                string[] values = property.Value.Split(',');
                foreach (string value in values)
                {
                        stat.AddModifier(int.Parse(value));
                }
            }
        }
    }

    public void RemoveModifier(Dictionary<string, string> _properties, int _itemId=-1)
    {
        if (_itemId != -1)
        {
        string baseStat = ItemUtilities.GetBaseStatOfEquipment(_itemId);
        getStatByName[baseStat].RemoveModifier(int.Parse(ItemManager.Instance.itemDict[_itemId].properties[baseStat]));
        }
        foreach (KeyValuePair<string, string> property in _properties)
        {
            if (getStatByName.TryGetValue(property.Key, out Stat stat))
            {
                string[] values = property.Value.Split(',');
                foreach (string value in values)
                {
                    stat.RemoveModifier(int.Parse(value));
                }
            }
        }
    }

    public void HealthIncrement(int _health = 0, int _healthPercentage = 0)
    {
        currentHealth += _health;
        currentHealth += (int)Mathf.Floor(maxHealth.GetValue() * _healthPercentage * 1f / 100);
        if (currentHealth > maxHealth.GetValue())
            currentHealth = maxHealth.GetValue();
        else if (currentHealth < 0)
            currentHealth = 0;
        OnHealthChanged?.Invoke();
    }
    
    public virtual void ManaChange(int _mana = 0, int _manaPercentage = 0)
    {
        currentMana += _mana;
        currentMana +=  (int)Mathf.Floor(maxHealth.GetValue() * _manaPercentage * 1f / 100);
        if (currentMana > maxMana.GetValue())
            currentMana = maxMana.GetValue();
        else if (currentMana < 0)
            currentMana = 0;
        OnManaChanged?.Invoke();
    }

    public void UsePotion(int _itemId)
    {
        ItemData item =  ItemManager.Instance.itemDict[_itemId];
        if (item.type != ItemType.Potion)
            return;
        if (item.properties.TryGetValue(ItemUtilities.HEALTH, out string _health))
        {
            HealthIncrement(int.Parse(_health));
        }
        if (item.properties.TryGetValue(ItemUtilities.MANA, out string _mana))
        {
            ManaChange(int.Parse(_mana));
        }
    }

    public void UseBuff(int _itemId)
    {
        int buffType = GetBuffType(_itemId);
        if (buffDict.TryGetValue(buffType, out StatBuff statBuff))
            statBuff?.EndBuff();
        GameObject buff = Instantiate(buffPrefab);
        buff.transform.SetParent(buffHolder);
        buffDict[buffType] = buff.GetComponent<StatBuff>();
        buffDict[buffType].StartBuff(_itemId, buffType);
    }
    public int GetBuffType(int _itemId)
    {
        return (ItemManager.Instance.itemDict[_itemId].id / 1000) % 10;
    }

}
