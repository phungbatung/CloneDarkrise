using BlitzyUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevivePopup : BlitzyUI.Screen
{
    private Button reviveButton;
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
        reviveButton = GetComponentInChildren<Button>();
        reviveButton.onClick.AddListener(Revive);
    }

    public void Revive()
    {
        PlayerManager.Instance.player.Revive();
        MapManager.Instance.Respawn();
        UIManager.Instance.QueuePopTo(GameManager.hudScreen, false);
    }    
}
