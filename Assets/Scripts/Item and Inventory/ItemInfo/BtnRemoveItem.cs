using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnRemoveItem : BtnBaseItemInfo
{
    protected override void PressEvent()
    {
        itemInfo.RemoveItem();
    }
}
