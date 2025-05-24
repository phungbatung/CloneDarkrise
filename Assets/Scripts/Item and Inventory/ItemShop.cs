using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShop
{
    public ItemShop(ItemInventory _item, KeyValuePair<CurrencyType, int> _price)
    {
        item = _item;
        price = _price;
    }
    public  ItemInventory item { get; private set; }
    public KeyValuePair<CurrencyType, int> price { get; private set; }

    public bool PurchaseThisItem()
    {
        if(ItemManager.Instance.Currency.IsHaveEnoughMoney(price) && ItemManager.Instance.TryAddItem(item))
        {
            ItemManager.Instance.Currency.TrySubtractCurrency(price);
            Debug.Log("Purchase successful!");
            return true;
        }
        Debug.Log("Purchase failed!");
        return false;
    }
}
