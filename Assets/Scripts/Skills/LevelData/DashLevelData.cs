using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashLevelData : SkillLevelData
{
    public override string ToString()
    {
        return $"Cooldown: {coolDown}\nManaCost: {manaCost}";
    }
}
