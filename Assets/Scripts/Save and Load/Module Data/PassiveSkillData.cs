using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PassiveSkillData 
{
    public SkillTree skillTree;

    public PassiveSkillData()
    {
         
    }
    public PassiveSkillData(SkillTree _skillTree)
    {
        skillTree = _skillTree;
    }
}
