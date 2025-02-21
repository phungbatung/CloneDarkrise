using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkillScreen : BlitzyUI.Screen
{
    private UI_SkillTree skillTreeUI;
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
        SkillTree skillTree = data.Get<SkillTree>("SkillTree");
        skillTreeUI.SetupData(skillTree);
    }

    public override void OnSetup()
    {
        skillTreeUI = GetComponentInChildren<UI_SkillTree>();
    }
}
