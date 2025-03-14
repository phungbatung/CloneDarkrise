using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData 
{
    public int level;
    public int exp;

    public PlayerData()
    {
        level = 1;
        exp = 0;
    }
}
