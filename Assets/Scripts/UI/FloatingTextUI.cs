using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingTextUI : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    private RectTransform rect;
    [SerializeField] private float startOffset;
    [SerializeField] private float floatingDistance;
    [SerializeField] private float floatingTime;
    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        rect = GetComponent<RectTransform>();
    }
    public void SetupText(string _text, Color _color)
    {
        tmp.text = _text;
        tmp.color = _color;
        Floating();
    }
    public void Floating()
    {
        rect.transform.localPosition = new Vector2(0, startOffset);
        tmp.color = new Color(1,1,1,1);
        transform.DOMoveY(transform.position.y + floatingDistance, floatingTime);
        tmp.DOFade(0, floatingTime);
    }
}
