using BlitzyUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PressEvent);
    }

    private void PressEvent()
    {
        UIManager.Instance.QueuePush(GameManager.gemInsertionScreen, null);
    }
}
