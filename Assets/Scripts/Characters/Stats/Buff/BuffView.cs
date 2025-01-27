using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI timeLeft;

    public void SetIcon(Sprite _icon)
    {
        icon.sprite = _icon;
    }

    public void SetTimeLeft(float _timeLeft)
    {
        if (_timeLeft < 60)
            timeLeft.text = $"{_timeLeft}sec";
        else
            timeLeft.text = $"{Mathf.FloorToInt(_timeLeft / 60)} min";
    }

    public void EndBuff()
    {
        Destroy(gameObject);
    }
}
