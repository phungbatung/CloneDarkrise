using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnEquipItem : BtnBaseItemInfo
{
    protected override void PressEvent()
    {
        itemInfo.EquipCurrentItem();
    }
}
