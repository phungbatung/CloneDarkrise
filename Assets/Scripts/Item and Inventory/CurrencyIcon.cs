using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCurrencyIcon", menuName = "Data/CurrencyIcon")]
public class CurrencyIcon : ScriptableObject
{

    public SerializableDictionary<CurrencyType, Sprite> IconDict;


    [ContextMenu("GenerateIconDictionary")]
    public void GenerateIconDictionary()
    {
        IconDict.Clear();
        foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
        {
            IconDict.Add(type, null);
        }
    }
}
