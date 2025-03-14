using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gold;
    [SerializeField] private TextMeshProUGUI diamond;


    public void SetCurrency()
    {
        int _gold = ItemManager.Instance.Currency.Gold;
        gold.text = _gold / 10000000 < 0 ? _gold.ToString() : $"{((float)(_gold / 1000000) / 10)}m";
        int _diamond = ItemManager.Instance.Currency.Diamond;
        diamond.text = _diamond / 10000000 < 0 ? _diamond.ToString() : $"{((float)(_diamond / 1000000) / 10)}m";
    }    
}
