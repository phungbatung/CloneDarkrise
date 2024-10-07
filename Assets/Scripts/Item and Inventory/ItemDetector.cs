using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ItemObject>() != null)
            ItemManager.Instance.listItemToPick.Add(collision.GetComponent<ItemObject>());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ItemObject>() != null)
            ItemManager.Instance.listItemToPick.Remove(collision.GetComponent<ItemObject>());
    }
}
