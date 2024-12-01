using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentProperties
{
    public Dictionary<string, string> baseProperties { get; private set; }
    public Dictionary<string, string> properties {  get; private set; }
    private int gemSlotsLimit { get; set; } = 3;
    public int unlockedGemsSlot { get; private set; }
    public int[] gems { get; private set; }
    public int enhanceLevel { get; private set; }
    private int maxEnhanceLevel { get; } = 20;

    public EquipmentProperties(Dictionary<string, string> _baseProperties, Dictionary<string, string> _properties)
    {
        baseProperties = _baseProperties;
        properties = _properties;
        unlockedGemsSlot = 0;
        gems = new int[gemSlotsLimit];
        for (int i =0; i<gems.Length; i++)
        {
            gems[i] = -1;
        }
    }

    public void UnlockGemSlot()
    {
        if (unlockedGemsSlot >= gemSlotsLimit)
            return;

        unlockedGemsSlot += 1;
    }

    public bool TryPutGemToSlot(int slotIndex, ItemInventory item)
    {
        if (slotIndex>=unlockedGemsSlot || item.itemId == -1 || ItemManager.Instance.itemDict[item.itemId].type != ItemType.MagicDust)
            return false;
        gems[slotIndex] = item.itemId;
        item.RemoveItem();
        return true;
    }

    public bool TryRemoveGemFromSlot(int slotIndex)
    {
        if (ItemManager.Instance.CanBeAdded(gems[slotIndex]))
        {
            ItemManager.Instance.AddItem(gems[slotIndex]);
            gems[slotIndex] = -1;
            return true;
        }

        return false;      
    }

    public Dictionary<string, string> GetProperties()
    {
        Dictionary<string, string> _properties = new();
        //add base properties
        foreach(KeyValuePair<string, string> kvp in baseProperties)
        {
            if (_properties.ContainsKey(kvp.Key))
            {
                _properties[kvp.Key] += $",{(int)(float.Parse(kvp.Value) * GetEnhanceValue())}";
            }
            else
            {
                _properties[kvp.Key] = ((int)(float.Parse(kvp.Value) * GetEnhanceValue())).ToString();
            }
        }
        //add properties
        foreach (KeyValuePair<string, string> kvp in properties)
        {
            if (_properties.ContainsKey(kvp.Key))
            {
                _properties[kvp.Key] += $",{(int)(float.Parse(kvp.Value) * GetEnhanceValue())}";
            }
            else
            {
                _properties[kvp.Key] = ((int)(float.Parse(kvp.Value) * GetEnhanceValue())).ToString();
            }
        }
        //add gem properties
        for(int i=0; i<unlockedGemsSlot; i++)
        {
            if (gems[i] == -1)
                continue;
            ItemData item = ItemManager.Instance.itemDict[gems[i]];
            foreach (KeyValuePair<string, string> kvp in item.properties)
            {
                if (_properties.ContainsKey(kvp.Key))
                {
                    _properties[kvp.Key] += $",{kvp.Value}";
                }
                else
                {
                    _properties[kvp.Key] = kvp.Value;
                }
            }
        }
        return _properties;
    }

    public void Upgrade()
    {
        if (enhanceLevel >=maxEnhanceLevel)
        {
            return;
        }
        enhanceLevel++;
    }

    public bool IsMaxEnhanceLevel() => enhanceLevel >= maxEnhanceLevel;

    public void Downgrade()
    {
        if (enhanceLevel <=0)
        {
            return;
        }
        enhanceLevel--;
    }

    public float GetEnhanceValue() => Mathf.Pow(1.05f, enhanceLevel);

    public float GetEnhanceValueAtLevel(int _level) => Mathf.Pow(1.05f, _level);

    public string GetPropertyAtCurrentLevel(string _property)
    {
        return ((int)(float.Parse(properties[_property]) * GetEnhanceValue())).ToString();
    }

    public string GetPropertyAtNextLevel(string _property)
    {
        return ((int)(float.Parse(properties[_property]) * GetEnhanceValueAtLevel(enhanceLevel+1))).ToString();
    }

}
