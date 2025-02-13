using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillNodeTemplate : MonoBehaviour
{
    public int id;
    public List<SkillNodeTemplate> neighbors;
    public SymmetricalType symmetricalType;
    public StatMultiplier multiplier;
    public SerializableDictionary<StatType, string> properties;
    public bool isCloned;

    public List<int> GetAllNeighbor()
    {
        List<int> res = new List<int>();
        foreach (SkillNodeTemplate node in neighbors)
        {
            res.Add(node.id);
        }
        return res;
    }
    public SerializableDictionary<string, string> GetProperties()
    {
        SerializableDictionary<string, string> res = new();
        foreach (var kvp in properties)
        {
            res.Add(kvp.Key.ToString(), kvp.Value);
        }
        return res;
    }
    public enum StatType
    {
        Attack,
        AttackSpeed,
        ArmorPenetration,
        CriticalRate,
        CriticalDamage,

        Health,
        HealthRegen,
        Armor,

        Mana,
        ManaRegen,
        MoveSpeed,
    }

    public enum StatMultiplier
    {
        x1 = 1,
        x2 = 2,
        x5 = 5
    } 
    
    public enum SymmetricalType
    {
        None,
        X,
        Y,
        Both,
        Quad
    }    
}
