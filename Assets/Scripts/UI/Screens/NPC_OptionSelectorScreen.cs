using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC_OptionSelectorScreen : BlitzyUI.Screen
{
    [SerializeField] private Transform listOptionsParent;
    [SerializeField] private UI_NPC_Option optionTemplate;
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
        for (int i = 0; i < listOptionsParent.childCount; i++)
            Destroy(listOptionsParent.GetChild(i).gameObject);

        if(data.TryGet("listOptions", out List<NPC_Option> options))
        {
            foreach(var option in options)
            {
                Instantiate(optionTemplate, listOptionsParent).Setup(option);
            }
        }
        else
        {
            Debug.LogError("Cannot find list option from NPC");
        }
        PushFinished();
    }

    public override void OnSetup()
    {

    }
}
