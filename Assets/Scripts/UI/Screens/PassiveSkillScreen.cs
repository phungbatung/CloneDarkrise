using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkillScreen : BlitzyUI.Screen
{
    public override void OnFocus()
    {
        
    }

    public override void OnFocusLost()
    {
        
    }

    public override void OnPop()
    {
        PopFinished();
    }

    public override void OnPush(Data data)
    {
        PushFinished();
    }

    public override void OnSetup()
    {

    }
}
