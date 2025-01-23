using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None=0,
    Equipment=1,
    Potion=2,
    SkillBook=3,
    Buff = 4,
    MagicDust=5,
    Material=6
}
public enum ItemQuality
{
    None=0,
    Rare=1,
    Epic=2,
    Legend=3
}
[System.Serializable]
public class ItemData
{
    
    public int id;
    public string name;
    public Sprite icon;
    public int level;
    public ItemType type;
    public ItemQuality quality;
    public string description;
    public int maxSize;
    public int sellPrice;
    public SerializableDictionary<string, string> properties = new SerializableDictionary<string, string>();

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
}
// id = abcddd
// a  : for ItemType
// b  : for ItemQuality
// c  : type of item of type a (Ex: if a is equipment then c is for equipment type)
// ddd: identity code

//Equipment type(c)
//0 Sword
//1 Shield
//2 Gauntlet
//3 Boots
//4 ChestPlate
//5 Pants
//6 Helmet
//7 Ring

