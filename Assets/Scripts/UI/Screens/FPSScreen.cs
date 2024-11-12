using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSScreen : BlitzyUI.Screen
{
    private TextMeshProUGUI tmp;
    [SerializeField] private float fpsLimitPerSec;

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
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(UpdateFPS());
    }
    
    private IEnumerator UpdateFPS()
    {
        WaitForSeconds second= new WaitForSeconds(1/ fpsLimitPerSec);
        while (true)
        {
            tmp.text = $"FPS: {Mathf.RoundToInt(1.0f/Time.deltaTime)}";
            yield return second;
        }
    }
}
