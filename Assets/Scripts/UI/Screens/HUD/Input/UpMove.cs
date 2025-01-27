using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        InputManager.Instance.isUpButtonPress = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InputManager.Instance.isUpButtonPress = false;
    }
}
