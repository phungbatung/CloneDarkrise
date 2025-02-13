using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnAssignPotionToSlot : BtnBaseItemInfo
{
    protected override void PressEvent()
    {
        itemInfo.AssignPotionToSlot();
    }
}
