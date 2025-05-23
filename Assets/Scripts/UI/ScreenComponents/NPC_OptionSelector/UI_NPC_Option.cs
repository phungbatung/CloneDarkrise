using BlitzyUI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_NPC_Option : MonoBehaviour, IPointerClickHandler
{
    private NPC_Option option;
    private TextMeshProUGUI tmp;
    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.Instance.QueuePop();
        QueuePush();
    }

    public void Setup(NPC_Option _option)
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        option = _option;
        tmp.text = $"<indent=7%>{option.displayName}";
        gameObject.SetActive(true);
    }

    public void QueuePush()
    {
        BlitzyUI.Screen.Id  screenId = new BlitzyUI.Screen.Id(option.screenName, option.screenName);
        UIManager.Instance.QueuePush(screenId, null);
    }    


}
