using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListItemToPick : MonoBehaviour
{
    private Dictionary<ItemObject,ItemToPick> listItemToPick = new Dictionary<ItemObject, ItemToPick>();
    [SerializeField] private GameObject itemToPickPrefab;
    [SerializeField] private Transform itemToPickParent;

    public void Add(ItemObject _itemObject)
    {
        GameObject itemToPickGO = Instantiate(itemToPickPrefab);
        itemToPickGO.transform.SetParent(itemToPickParent);

        ItemToPick item = itemToPickGO.GetComponent<ItemToPick>();
        listItemToPick[_itemObject] = item;

        item.SetUpUI(_itemObject);
    }
    public void Remove(ItemObject _itemObject)
    {
        if(_itemObject == null || !listItemToPick.ContainsKey(_itemObject) )
            return;
        Destroy(listItemToPick[_itemObject].gameObject);
        listItemToPick.Remove(_itemObject);
    }
}
