using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AddItemButton : MonoBehaviour
{
    public Button btn;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(AddItem);
    }
    public void AddItem()
    {
        int index = Random.Range(0, Inventory.Instance.itemDatabase.itemsData.Count);
        ItemData itemData = Inventory.Instance.itemDatabase.itemsData[index];
        if (itemData.type == ItemType.Equipment)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            for (int i=1; i<=itemData.quality.GetHashCode();i++)
            {
                int idx = Random.Range(0, itemData.properties.Count);
                var kvp = itemData.properties.ElementAt(idx);
                if (properties.ContainsKey(kvp.Key))
                {
                    properties[kvp.Key] += $",{(int)Random.Range(float.Parse(kvp.Value) * .7f, float.Parse(kvp.Value) * 1.3f)}";
                }
                else
                {
                    properties[kvp.Key] = ((int)Random.Range(float.Parse(kvp.Value) * .7f, float.Parse(kvp.Value) * 1.3f)).ToString();
                }
            }    
        Inventory.Instance.AddItem(itemData.id, properties);
        }    
    }
}
