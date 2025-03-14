using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillLevelData
{
    public SerializableDictionary<string, string> properties;

    public SkillLevelData() 
    {
        properties = new();
    }


    public T GetProperty<T>(string key)
    {
        if (properties.TryGetValue(key, out string value))
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Cannot change type '{value}' to {typeof(T)}");
            }
        }
        throw new KeyNotFoundException($"Key '{key}' not found in dictionary.");
    }

    public bool TryGetProperty<T>(string key, out T value)
    {
        if (properties.TryGetValue(key, out string strValue))
        {
            try
            {
                value = (T)Convert.ChangeType(strValue, typeof(T));
                return true;
            }
            catch
            {
                value = default;
                return false;
            }
        }

        value = default;
        return false;
    }


    public static class Key
    {
        public static readonly string LEVEL = "Level";
        public static readonly string COOLDOWN = "Cooldown";
        public static readonly string MANA_COST = "ManaCost";
        public static readonly string HIT_COMBO = "HitCombo";
        public static readonly string DAMAGE_PERCENTAGE = "DamagePercentage";
        public static readonly string DESCRIPTION = "Description";
        public static readonly string HEALTH_TO_REGEN = "HealthToRegen";
        public static readonly string HEALTH_PERCENTAGE_TO_REGEN = "HealthPercentageToRegen";
        public static readonly string CAST_SPEED = "CastSpeed";
        public static readonly string STAT_PERCENTAGE = "StatPercentage";
        public static readonly string QUANTITY = "Quantity";
        public static readonly string LIFESPAN = "Lifespan";
    }
}
