using BlitzyUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BacpackButton : MonoBehaviour
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ClickEvent);
    }

    public void ClickEvent()
    {
        UIManager.Instance.QueuePush(GameManager.inventoryScreen, null, null, null);
    }
}
