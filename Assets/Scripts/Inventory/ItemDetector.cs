using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UI_Manager.Instance.listItemToPick.Add(collision.GetComponent<ItemObject>());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        UI_Manager.Instance.listItemToPick.Remove(collision.GetComponent<ItemObject>());
    }
}
