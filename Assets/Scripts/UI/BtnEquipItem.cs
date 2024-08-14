using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnEquipItem : MonoBehaviour
{
    private Button equipButton;
    private ItemInfo itemInfo;

    private void Awake()
    {
        equipButton = GetComponent<Button>();
        itemInfo = GetComponentInParent<ItemInfo>();
        equipButton.onClick.AddListener(EquipItem);
    }

    private void EquipItem()
    {
        itemInfo.EquipCurrentItem();
    }
}
