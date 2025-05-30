using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCurrencyButton : MonoBehaviour
{
    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(AddCurrency);
    }

    private void AddCurrency()
    {
        ItemManager.Instance.Currency.AddCurrency(100000, 100000);
    }    
}
