using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public delegate void ItemDetectEvent(ItemObject item);
    public ItemDetectEvent onZoneItem;
    public ItemDetectEvent outZoneItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemObject itemObject = collision.GetComponent<ItemObject>();
        if (itemObject != null)
            onZoneItem?.Invoke(itemObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ItemObject itemObject = collision.GetComponent<ItemObject>();
        if (itemObject != null)
            outZoneItem?.Invoke(itemObject);
    }
}
