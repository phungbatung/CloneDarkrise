using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class SkillLevelData
{
    public int level;
    public float coolDown;
    public int manaCost;
    public string description;

    public string GetLevelDescription() => $"LV{level}: {description}\n";
}
