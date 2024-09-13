using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BtnBaseItemInfo : MonoBehaviour
{
    protected Button button;
    protected ItemInfo itemInfo;

    protected void Awake()
    {
        button = GetComponent<Button>();
        itemInfo = GetComponentInParent<ItemInfo>();
        button.onClick.AddListener(PressEvent);
    }

    protected abstract void PressEvent();
}
