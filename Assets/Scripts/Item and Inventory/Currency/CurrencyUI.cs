using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gold;
    [SerializeField] private TextMeshProUGUI diamond;

    private void OnEnable()
    {
        SetGold();
        SetDiamond();
        PlayerManager.Instance.Currency.OnGoldChange += SetGold;
        PlayerManager.Instance.Currency.OnDiamondChange += SetDiamond;
    }
    private void OnDisable()
    {
        PlayerManager.Instance.Currency.OnGoldChange -= SetGold;
        PlayerManager.Instance.Currency.OnDiamondChange -= SetDiamond;
    }
    public void SetGold()
    {
        int _gold = PlayerManager.Instance.Currency.Gold;
        gold.text= _gold/10000000<0? _gold.ToString() : $"{((float)(_gold/1000000)/10)}m";
    }

    public void SetDiamond()
    {
        int _diamond = PlayerManager.Instance.Currency.Diamond;
        diamond.text = _diamond / 10000000 < 0 ? _diamond.ToString() : $"{((float)(_diamond / 1000000) / 10)}m";
    }
}
