using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ActiveSkillSaveData 
{
    public int skillPoint;
    public SerializableDictionary<int , int> skillData; //<id, level>
    public ActiveSkillSaveData(int _skillPoint, SerializableDictionary<int, int> _skillData)
    {
        skillPoint = _skillPoint;
        skillData = _skillData;
    }

    public ActiveSkillSaveData()
    {
        skillPoint = 0;
        skillData = new();
    }
}
