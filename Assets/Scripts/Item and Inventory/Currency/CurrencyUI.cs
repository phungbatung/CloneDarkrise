using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gold;
    [SerializeField] private TextMeshProUGUI diamond;

    private void Start()
    {
        SubEvent();
    }

    private void OnDestroy()
    {
        if (ItemManager.Instance!=null)
            UnsubEvent();
    }

    public void SubEvent()
    {
        SetCurrency();
        ItemManager.Instance.Currency.OnCurrencyChange += SetCurrency;
    }

    public void UnsubEvent()
    {
        ItemManager.Instance.Currency.OnCurrencyChange += SetCurrency;
    }    
    public void SetCurrency()
    {
        int _gold = ItemManager.Instance.Currency.Gold;
        gold.text = GetMoney(_gold);
        int _diamond = ItemManager.Instance.Currency.Diamond;
        diamond.text = GetMoney(_diamond);
    }

    public string GetMoney(int m)
    {
        if (m < 1000)
        {
            return m + "";
        }
        if (m < 1000000)
        {
            return $"{m / 1000} K";
        }
        if (m < 1000000000)
        {
            return $"{m / 1000000} M";
        }
        return $"{m / 1000000000} B";
    }    
}
