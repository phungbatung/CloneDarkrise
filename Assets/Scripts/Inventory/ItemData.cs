using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None=0,
    Equipment=1,
    Potion=2,
    Buff=3,
    Material=4,
    SkillBook=5,
    Gem=6
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
    // id = abccddd
    // a  : for ItemType
    // b  : for ItemQuality
    // cc : if a is equipment then c is for equipment type, else b = 0 
    // ddd: identity code
    public int id; 
    public string name;
    public Sprite icon;
    public int level;
    public ItemType type;
    public ItemQuality quality;
    public string description;
    public int maxSize;
    public Dictionary<string, string> properties = new Dictionary<string, string>();
}

