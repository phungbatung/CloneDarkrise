using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnUseBuff : MonoBehaviour
{
    private Button useBuffButton;
    private ItemInfo itemInfo;

    private void Awake()
    {
        useBuffButton = GetComponent<Button>();
        itemInfo = GetComponentInParent<ItemInfo>();
        useBuffButton.onClick.AddListener(UseBuff);
    }

    private void UseBuff()
    {
        itemInfo.UseBuff();
    }
}
