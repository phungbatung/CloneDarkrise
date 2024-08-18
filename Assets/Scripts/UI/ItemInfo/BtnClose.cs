using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClose : MonoBehaviour
{
    private Button closeButton;
    [SerializeField] private GameObject gameObjectToClose;

    private void Awake()
    {
        closeButton  = GetComponent<Button>();
        closeButton.onClick.AddListener(Close);
    }

    private void Close()
    {
        gameObjectToClose.SetActive(false);
    }
}
