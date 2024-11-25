using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public enum EquipmentType
{
    Sword = 0,
    Shield = 1,
    Gauntlet = 2,
    Boots = 3,
    ChestPlate = 4,
    Pants = 5,
    Helmet = 6,
    Ring = 7
}
public enum BuffType
{
    Offensive = 0,
    Deffensive = 1
}
public class ItemUtilities
{
    public const string DAMAGE = "Attack";
    public const string ATTACK_SPEED = "AttackSpeed";
    public const string ARMOR_PENETRATION = "ArmorPenetration";
    public const string CRITICAL_RATE = "CriticalRate";
    public const string CRITICAL_DAMAGE = "CriticalDamage";


    public const string HEALTH = "Health";
    public const string HEALTH_REGEN = "HealthRegen";
    public const string ARMOR = "Armor";

    public const string MANA = "Mana";
    public const string MANA_REGEN = "ManaRegen";
    public const string MOVE_SPEED = "MoveSpeed";

    public const string COOLDOWN = "CoolDown";
    public const string DURATION = "Duration";

    public const string HEALTH_BUFF = "HealthBuff";
    public const string DAMAGE_BUFF = "DamageBuff";

    public const string SKILL_POINT = "SkillPoint";

    public static EquipmentType GetEquipmentTypeById(int _itemId)
    {
        return (EquipmentType)(_itemId/1000%10);
    }

    public static string GetBaseStatOfEquipment(int _itemId)
    {
        EquipmentType equipmentType = GetEquipmentTypeById(_itemId);
        if (equipmentType == EquipmentType.Sword) return DAMAGE;
        else if (equipmentType == EquipmentType.Boots) return MOVE_SPEED;
        else return ARMOR;
    }

    public static BuffType GetBuffTypeById(int _itemId)
    {
        return (BuffType)(_itemId / 1000 % 10);
    }

    public static Dictionary<string, string> GetBaseProperties(int _itemId)
    {
        Dictionary<string, string> dict = new();
        ItemData item = ItemManager.Instance.itemDict[_itemId];
        string baseProperties = GetBaseStatOfEquipment(_itemId);
        dict.Add(baseProperties, item.properties[baseProperties]);
        return dict;
    }
}
