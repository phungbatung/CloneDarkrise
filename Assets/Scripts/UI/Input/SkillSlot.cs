using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;
    private TextMeshProUGUI textCoolDown;
    public bool isPressed { get; set; }
    private void Awake()
    {
        textCoolDown = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (gameObject.name=="Dash")
        {
            Debug.Log(image.color.a);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPressed = false;
    }

    public void DoCooldown(float _cooldownTimer, float _coolDown)
    {
        if (_cooldownTimer <= 0)
        {
            image.fillAmount = 1;
            textCoolDown.text = "";
            return;
        }
        image.fillAmount = (_coolDown - _cooldownTimer)/_coolDown;
        textCoolDown.text = ((int)_cooldownTimer).ToString();
    }
}
