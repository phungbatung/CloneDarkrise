using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnUseBuff : BtnBaseItemInfo
{
    protected override void PressEvent()
    {
        itemInfo.UseBuff();
    }
}
