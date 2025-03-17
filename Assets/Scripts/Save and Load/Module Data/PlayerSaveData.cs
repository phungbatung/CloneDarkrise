using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerSaveData 
{
    public int level;
    public int exp;

    public PlayerSaveData()
    {
        level = 1;
        exp = 0;
    }
    public PlayerSaveData(int _level, int _exp)
    {
        level = _level;
        exp = _exp;
    }
}
