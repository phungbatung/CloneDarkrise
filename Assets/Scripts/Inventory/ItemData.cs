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
    // id = abcddd
    // a  : for ItemType
    // b  : for ItemQuality
    // c  : type of item of type a (Ex: if a is equipment then c is for equipment type)
    // ddd: identity code
    public int id; 
    public string name;
    public Sprite icon;
    public int level;
    public ItemType type;
    public ItemQuality quality;
    public string description;
    public int maxSize;
    public SerializableDictionary<string, string> properties = new SerializableDictionary<string, string>();
}
//Equipment type(c)
//1 Sword
//2 Shield
//3 Gauntlet
//4 Boots
//5 ChestPlate
//6 Pants
//7 Helmet
//8 Ring

