using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ActiveSkillData 
{
    public int skillPoint;
    public SerializableDictionary<int , int> skillData; //<id, level>
    public ActiveSkillData(int _skillPoint, SerializableDictionary<int, int> _skillData)
    {
        skillPoint = _skillPoint;
        skillData = _skillData;
    }

    public ActiveSkillData()
    {
        skillPoint = 0;
        skillData = new();
    }
}
