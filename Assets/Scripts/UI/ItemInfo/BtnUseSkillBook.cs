using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUseSkillBook : BtnBaseItemInfo
{
    protected override void PressEvent()
    {
        itemInfo.UseSkillBook();
    }
}
