using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BtnBaseItemInfo : MonoBehaviour
{
    protected Button button;
    protected ItemInfoScreen itemInfo;
    [SerializeField] List<ItemType> typeToActive;

    protected void Awake()
    {
        button = GetComponent<Button>();
        itemInfo = GetComponentInParent<ItemInfoScreen>();
        button.onClick.AddListener(PressEvent);
    }

    protected abstract void PressEvent();

    public bool CanBeActive(ItemType itemType)
    {
        return typeToActive.Contains(itemType);
    }    
}
