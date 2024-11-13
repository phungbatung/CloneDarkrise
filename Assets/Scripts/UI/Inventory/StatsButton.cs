using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsButton : MonoBehaviour
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ClickEvent);
    }

    public void ClickEvent()
    {
        BlitzyUI.UIManager.Instance.QueuePush(GameManager.statsScreen, null, null, null);
    }
}
