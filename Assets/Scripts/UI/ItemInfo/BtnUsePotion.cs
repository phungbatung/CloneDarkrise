using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnUsePotion : MonoBehaviour
{
    private Button usePotionButton;
    private ItemInfo itemInfo;

    private void Awake()
    {
        usePotionButton = GetComponent<Button>();
        itemInfo = GetComponentInParent<ItemInfo>();
        usePotionButton.onClick.AddListener(UsePotion);
    }

    private void UsePotion()
    {
        itemInfo.UsePotion();
    }
}
