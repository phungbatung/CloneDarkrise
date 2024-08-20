using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LeftMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] public Sprite pressedSprite;
    private void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = idleSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InputManager.Instance.isLeftButtonPress = true;
        image.sprite = pressedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InputManager.Instance.isLeftButtonPress = false;
        image.sprite = idleSprite;
    }
}
