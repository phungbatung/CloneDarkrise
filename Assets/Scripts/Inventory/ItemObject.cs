using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private int itemId;
    private Dictionary<string, string> properties;

    public void SetUpItem(int _itemId, Dictionary<string, string> _properties)
    {
        itemId = _itemId;
        properties = _properties;
    }
}
