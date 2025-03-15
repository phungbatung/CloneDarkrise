using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevel : MonoBehaviour
{
    public int Level { get; protected set; }
    public int Exp { get; protected set; }
    public int ExpToNextLevel { get; protected set; }

    private const int BASE_EXP_TO_NEXT_LEVEL = 100;

    private const float EXP_MULTIPLIER = 1.5f;

    public Action<int, int, int> OnGainExp { get; set; }
    public Action<int> OnLevelUp { get; set; }

    protected virtual void Awake()
    {
        
    }


    public void GainExp(int _expGain)
    {
        Exp += _expGain;
        while (Exp >= ExpToNextLevel)
        {
            LevelUp();
        }
        OnGainExp?.Invoke(_expGain, Exp, ExpToNextLevel);
    }
    private void LevelUp()
    {
        Exp -= ExpToNextLevel;
        Level++;
        UpdateExpToNextLevel();
        OnLevelUp?.Invoke(Level);
    }

    private void UpdateExpToNextLevel()
    {
        ExpToNextLevel = (int)(BASE_EXP_TO_NEXT_LEVEL * Mathf.Pow(EXP_MULTIPLIER, Level));
    }    
    public void LevelUpTo(int targetLevel)
    {
        if (targetLevel <= Level)
        {
            return;
        }

        while (Level < targetLevel)
        {
            Exp += ExpToNextLevel;
            LevelUp();
        }
    }

    public void SetLevel(int _level, int _exp)
    {
        Level = _level;
        Exp = _exp;
        UpdateExpToNextLevel();
        OnLevelUp?.Invoke(Level);
        OnGainExp?.Invoke(_exp, Exp, ExpToNextLevel);
    }    
}
