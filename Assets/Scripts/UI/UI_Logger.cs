using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Logger : MonoBehaviour
{
    public static UI_Logger instance;
    private TextMeshProUGUI tmp;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        tmp = GetComponent<TextMeshProUGUI>();
    }

    public void SetLog(string log)
    {
        tmp.text = $"Log: \"{log}\"";
    }
}
