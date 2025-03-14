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
    public int Diamond { get; set; }
    public Action OnCurrencyChange { get; set; }
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

    public void AddCurrency(CurrencyType _type, int _currency)
    {
        if (_currency <= 0)
            return;

        if(_type == CurrencyType.Gold)
        {
            Gold += _currency;
        }
        else
        {
            Diamond += _currency;
        }
        OnCurrencyChange?.Invoke();
    }
    public void AddCurrency(int _gold, int _diamond)
    {
        Gold += _gold;
        Diamond += _diamond;
        OnCurrencyChange?.Invoke();
    }
    public bool TrySubtractCurrency(CurrencyType _type, int _currency)
    {
        if(_currency < 0)
        {
            Debug.LogError("The money to subtract is less than zero");
            return false;
        }

        if(_type == CurrencyType.Gold)
        {
            if(_currency > Gold)
                return false;
            Gold -= _currency;
            OnCurrencyChange?.Invoke();
            return true;
        }
        else
        {
            if (_currency > Diamond)
                return false;
            Diamond -= _currency;
            OnCurrencyChange?.Invoke();
            return true;
        }
    }

    public bool TrySubtractCurrency(KeyValuePair<CurrencyType, int> kvp)
    {
        return(TrySubtractCurrency(kvp.Key, kvp.Value));
    }

    public bool IsHaveEnoughMoney(CurrencyType _type, int _currency)
    {
        if(_type == CurrencyType.Gold && _currency < Gold)
            return true;
        if (_type == CurrencyType.Diamond && _currency < Diamond)
            return true;
        return false;
    }

    public bool IsHaveEnoughMoney(KeyValuePair<CurrencyType, int> kvp)
    {
        return IsHaveEnoughMoney(kvp.Key, kvp.Value);
    }
}
