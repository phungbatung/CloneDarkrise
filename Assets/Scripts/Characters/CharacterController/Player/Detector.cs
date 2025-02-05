using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public delegate void ItemDetectEvent(ItemObject item);
    public ItemDetectEvent inZoneItem { get; set; }
    public ItemDetectEvent outZoneItem { get; set; }

    public Action<NPC> inZoneNPC { get; set; }
    public Action<NPC> outZoneNPC { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemObject itemObject = collision.GetComponent<ItemObject>();
        if (itemObject != null)
            inZoneItem?.Invoke(itemObject);

        NPC npc = collision.GetComponent<NPC>();
        if (npc != null)
            inZoneNPC?.Invoke(npc);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ItemObject itemObject = collision.GetComponent<ItemObject>();
        if (itemObject != null)
            outZoneItem?.Invoke(itemObject);
        NPC npc = collision.GetComponent<NPC>();
        if (npc != null)
            outZoneNPC?.Invoke(npc);
    }
}
