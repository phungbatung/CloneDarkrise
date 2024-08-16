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
        itemIcon.sprite = Inventory.Instance.itemDatabase.itemDataDictionary[itemObject.itemId].icon;
        itemName.text = Inventory.Instance.itemDatabase.itemDataDictionary[itemObject.itemId].name;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        itemObject.PickUpItem();
        Destroy(gameObject);
    }


}
