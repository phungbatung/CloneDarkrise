using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Data/SkillData")]
public class SkillData : ScriptableObject
{
    public int id;
    public Sprite icon;
    public string skillName;
    public List<SkillLevelData> levelsData = new();
}
