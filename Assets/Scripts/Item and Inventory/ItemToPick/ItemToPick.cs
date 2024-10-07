using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemToPick : MonoBehaviour, IPointerClickHandler
{
    private Image itemIcon;
    private TextMeshProUGUI itemName;
    private ItemObject itemObject;


    private void Awake()
    {
        itemIcon = GetComponent<Image>();
        itemName = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetUpUI(ItemObject _itemObject)
    {
        itemObject = _itemObject;
        itemIcon.sprite = ItemManager.Instance.itemDict[itemObject.itemId].icon;
        itemName.text = ItemManager.Instance.itemDict[itemObject.itemId].name;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        itemObject.PickUpItem();
        Destroy(gameObject);
    }


}
