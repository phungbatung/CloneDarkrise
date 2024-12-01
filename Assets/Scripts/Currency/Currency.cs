using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrencyType
{
    Gold,
    Diamond
}
public class Currency
{
    public int Gold { get; set; }
    public Action OnGoldChange { get; set; }
    public int Diamond { get; set; }
    public Action OnDiamondChange { get; set; }
    public Currency(int gold, int diamond)
    {
        Gold = gold;
        Diamond = diamond;
    }
    public Currency() 
    {
        Gold = 0;
        Diamond = 0;
    }

    public void AddCurrency(int _currency, CurrencyType _type)
    {
        if (_currency <= 0)
            return;

        if(_type == CurrencyType.Gold)
        {
            Gold += _currency;
            OnGoldChange?.Invoke();
        }
        else
        {
            Diamond += _currency;
            OnDiamondChange?.Invoke();
        } 
    }

    public bool TrySubtractCurrency(int _currency, CurrencyType _type)
    {
        if(_currency < 0)
        {
            Debug.LogError("The money to subtract is less than zero");
            return false;
        }

        if(_type == CurrencyType.Gold)
        {
            if(_currency < Gold)
                return false;
            Gold -= _currency;
            OnGoldChange?.Invoke();
            return true;
        }
        else
        {
            if (_currency < Diamond)
                return false;
            Diamond -= _currency;
            OnDiamondChange?.Invoke();
            return true;
        }
    }

}
