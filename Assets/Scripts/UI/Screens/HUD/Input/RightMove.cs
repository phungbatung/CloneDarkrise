using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RightMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
        InputManager.Instance.isRightButtonPress = true;
        image.sprite = pressedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InputManager.Instance.isRightButtonPress = false;
        image.sprite = idleSprite;
    }
}
