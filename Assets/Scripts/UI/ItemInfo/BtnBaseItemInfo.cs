using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BtnBaseItemInfo : MonoBehaviour
{
    protected Button button;
    protected ItemInfo itemInfo;
    [SerializeField] List<ItemType> typeToActive;

    protected void Awake()
    {
        button = GetComponent<Button>();
        itemInfo = GetComponentInParent<ItemInfo>();
        button.onClick.AddListener(PressEvent);
    }

    protected abstract void PressEvent();

    public bool CanBeActive(ItemType itemType)
    {
        return typeToActive.Contains(itemType);
    }    
}
