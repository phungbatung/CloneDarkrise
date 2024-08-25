using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField]private int baseValue;
    public int BaseValue { get { return baseValue; } set {  baseValue = value; } }
    [SerializeField]private List<int> modifiers;
    public Action modifierEvent;
    public void AddModifier(int _modifier )
    {
        modifiers.Add(_modifier);
        if (modifierEvent != null)
            modifierEvent();
    }

    public void RemoveModifier(int _modifier)
    {
        modifiers.Remove(_modifier);
        if (modifierEvent != null)
            modifierEvent();
    }

    public int GetValue()
    {
        int totalValue = baseValue;
        foreach (int modifier in modifiers) 
        {
            totalValue += modifier;
        }
        return totalValue;
    }
}
