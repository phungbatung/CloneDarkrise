using System.Collections;
using System.Collections.Generic;
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
        Inventory.Instance.AddItem(Inventory.Instance.itemDatabase.itemsData[index].id);
    }
}
