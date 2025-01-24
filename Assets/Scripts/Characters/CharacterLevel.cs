using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevel : MonoBehaviour
{
    public int level;
    private int exp { get; set; }
    private int expToNextLevel { get; set; }
    private const float EXP_MULTIPLIER = 1.5f;
    public Action OnLevelUp;
    public void GainExp(int _exp)
    {
        exp += _exp;
        while (exp >= expToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        exp -= expToNextLevel;
        level++;
        expToNextLevel = Mathf.RoundToInt(expToNextLevel * EXP_MULTIPLIER);
        OnLevelUp?.Invoke();
    }

    public void LevelUpTo(int targetLevel)
    {
        if (targetLevel <= level)
        {
            return;
        }

        while (level < targetLevel)
        {
            exp += expToNextLevel;
            LevelUp();
        }
    }
}
