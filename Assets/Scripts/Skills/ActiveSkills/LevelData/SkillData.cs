using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillData
{
    public Sprite icon;
    public string skillName;
    public List<SkillLevelData> levelsData = new();
}
