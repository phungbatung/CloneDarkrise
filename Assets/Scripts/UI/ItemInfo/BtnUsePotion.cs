using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnUsePotion : BtnBaseItemInfo
{
    protected override void PressEvent()
    {
        itemInfo.UsePotion();
    }
}
