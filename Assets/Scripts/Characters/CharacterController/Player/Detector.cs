using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public delegate void ItemDetectEvent(ItemObject item);
    public ItemDetectEvent inZoneItem { get; set; }
    public ItemDetectEvent outZoneItem { get; set; }

    public Action<InteractableObject> inZoneNPC { get; set; }
    public Action<InteractableObject> outZoneNPC { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemObject itemObject = collision.GetComponent<ItemObject>();
        if (itemObject != null)
            inZoneItem?.Invoke(itemObject);

        InteractableObject npc = collision.GetComponent<InteractableObject>();
        if (npc != null)
            inZoneNPC?.Invoke(npc);
        
        CurrencyObject currencyObject = collision.GetComponent<CurrencyObject>();
        if(currencyObject != null)
            currencyObject.PickUp();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ItemObject itemObject = collision.GetComponent<ItemObject>();
        if (itemObject != null)
            outZoneItem?.Invoke(itemObject);
        InteractableObject npc = collision.GetComponent<InteractableObject>();
        if (npc != null)
            outZoneNPC?.Invoke(npc);
    }
}
