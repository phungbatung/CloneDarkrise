using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowFPS : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    private int targetFPS=60;
    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        Application.targetFrameRate = targetFPS;
        StartCoroutine(UpdateFPS());
    }
    
    private IEnumerator UpdateFPS()
    {
        WaitForSeconds second= new WaitForSeconds(1.0f);
        while (true)
        {
            tmp.text = $"FPS: {Mathf.RoundToInt(1.0f/Time.deltaTime)}";
            yield return second;
        }
    }
}
