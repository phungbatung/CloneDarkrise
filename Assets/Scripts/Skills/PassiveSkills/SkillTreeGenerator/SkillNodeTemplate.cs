using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SkillNodeTemplate : MonoBehaviour
{
    public Image frame;
    public Image icon;

    public int id;
    public string nodeName;
    public string description;
    public List<SkillNodeTemplate> neighbors;
    public SymmetricalType symmetricalType;
    public StatMultiplier multiplier;
    public SerializableDictionary<StatType, string> properties;
    public bool isCloned;
    public bool unlocked;

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
            string value = kvp.Value;
            if(multiplier == StatMultiplier.x2)
            {
                value = (int.Parse(kvp.Value) * 2).ToString();
            }
            if (multiplier == StatMultiplier.x5)
            {
                value = (int.Parse(kvp.Value) * 5).ToString();
            }
            res.Add(kvp.Key.ToString(), value);
        }
        return res;
    }
    public enum StatType
    {
        Attack=0,
        AttackSpeed=1,
        ArmorPenetration=2,
        CriticalRate=3,
        CriticalDamage=4,

        Health=5,
        HealthRegen=6,
        Armor=7,

        Mana=8,
        ManaRegen=9,
        MoveSpeed=10,
    }

    public enum StatMultiplier
    {
        x1 = 0,
        x2 = 1,
        x5 = 2
    } 
    
    public enum SymmetricalType
    {
        None,
        X,
        Y,
        Both,
        Quad
    }    
    public SkillNode GetNode(SkillTreeBaseData stBaseData)
    {
        Image[] imgs = GetComponentsInChildren<Image>();
        frame = imgs[0];
        icon = imgs[2];
        SkillTreeBaseData.SkillNodePrimaryData data = default;
        properties.Clear();
        if (properties.Count ==1)
        {
            nodeName = properties.First().ToString();
            data = stBaseData.data[nodeName];
        }
        else if (properties.Count<=0)
        {
            nodeName = ((StatType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(StatType)).Length)).ToString();
            Debug.Log($"id:{id}, node name:{nodeName}");
            data = stBaseData.data[nodeName];
            properties[(StatType)Enum.Parse(typeof(StatType), nodeName)] = data.baseValue.ToString();
        }
        else
        {
            data = stBaseData.data[nodeName];
        }

        if(multiplier == StatMultiplier.x1)
        {
            transform.localScale = Vector3.one;
        }    
        else if (multiplier == StatMultiplier.x2)
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }    
        else if(multiplier == StatMultiplier.x5)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        }
        if(description.Length <= 0) 
        {
            description = data.description;
        }
        SkillNode node = new(id, transform.position, nodeName, description, data.index, (int)multiplier, GetProperties(), GetAllNeighbor(), unlocked);
        frame.sprite = stBaseData.frameBorder[(int)multiplier];
        icon.sprite = data.icon;
        return node;
    }    
}
