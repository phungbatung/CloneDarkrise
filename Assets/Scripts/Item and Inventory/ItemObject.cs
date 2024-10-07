using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    public int itemId;
    public Dictionary<string, string> properties = new Dictionary<string, string>();

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetUpItem(int _itemId, Vector3 _dropPosition)
    {
        itemId = _itemId;
        ItemData itemData = ItemManager.Instance.itemDict[_itemId];
        if (itemData.type == ItemType.Equipment)
        {
            for (int i = 1; i <= itemData.quality.GetHashCode(); i++)
            {
                int idx = UnityEngine.Random.Range(0, itemData.properties.Count);
                var kvp = itemData.properties.ElementAt(idx);
                if (properties.ContainsKey(kvp.Key))
                {
                    properties[kvp.Key] += $",{(int)UnityEngine.Random.Range(float.Parse(kvp.Value) * .7f, float.Parse(kvp.Value) * 1.3f)}";
                }
                else
                {
                    properties[kvp.Key] = ((int)UnityEngine.Random.Range(float.Parse(kvp.Value) * .7f, float.Parse(kvp.Value) * 1.3f)).ToString();
                }
            }
        }
        sr.sprite = itemData.icon;
        transform.position = _dropPosition;
        rb.velocity = new Vector2(UnityEngine.Random.Range(-5.0f, 5.0f), 5);
    }

    public void PickUpItem()
    {
        if (properties.Count == 0)
            ItemManager.Instance.AddItem(itemId);
        else
            ItemManager.Instance.AddItem(itemId, properties);
        Destroy(gameObject);
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //    {
    //        rb.gravityScale = 0;
    //        rb.velocity = Vector2.zero;
    //    }
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
    //    {
    //        rb.velocity = new Vector2(rb.velocity.x, 0);
    //    }
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    {
    //        UI_Manager.Instance.listItemToPick.Add(this);
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
    //        UI_Manager.Instance.listItemToPick.Remove(this);
    //}

}

