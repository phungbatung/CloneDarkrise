using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnRemoveItem : MonoBehaviour
{
    private Button btnRemoveItem;
    private ItemInfo itemInfo;

    private void Awake()
    {
        btnRemoveItem = GetComponent<Button>();
        itemInfo = GetComponentInParent<ItemInfo>();
        btnRemoveItem.onClick.AddListener(RemoveItem);
    }
    private void RemoveItem()
    {
        itemInfo.RemoveItem();
    }
}
