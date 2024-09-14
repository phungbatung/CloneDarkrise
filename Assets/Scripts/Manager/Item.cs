using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Item
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

    public static int GetEquipmentTypeById(int _itemId)
    {
        return _itemId/1000%10;
    }

    public static string GetBaseStatOfEquipment(int _itemId)
    {
        int equipmentType = GetEquipmentTypeById(_itemId);
        if (equipmentType == 0) return DAMAGE;
        else if (equipmentType == 1) return ARMOR;
        else if (equipmentType == 2) return ARMOR;
        else if (equipmentType == 3) return MOVE_SPEED;
        else if (equipmentType == 4) return ARMOR;
        else if (equipmentType == 5) return ARMOR;
        else if (equipmentType == 6) return ARMOR;
        else return ARMOR;
    }
}
