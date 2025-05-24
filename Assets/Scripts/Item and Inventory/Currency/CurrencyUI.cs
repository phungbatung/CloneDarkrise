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
        if (ItemManager.Instance != null)
            ItemManager.Instance.Currency.OnCurrencyChange -= SetCurrency;
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
        return Utils.ConvertToKMB(m);
    }    
}
