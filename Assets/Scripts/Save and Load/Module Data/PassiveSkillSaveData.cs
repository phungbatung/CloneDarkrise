using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PassiveSkillSaveData 
{
    public SkillTree skillTree;

    public PassiveSkillSaveData()
    {
         
    }
    public PassiveSkillSaveData(SkillTree _skillTree)
    {
        skillTree = _skillTree;
    }
}
