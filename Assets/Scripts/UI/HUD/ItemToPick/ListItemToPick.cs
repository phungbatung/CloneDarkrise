using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListItemToPick : MonoBehaviour
{
    private Dictionary<ItemObject,ItemToPick> listItemToPick = new Dictionary<ItemObject, ItemToPick>();
    [SerializeField] private GameObject itemToPickPrefab;
    [SerializeField] private Transform itemToPickParent;

    private void Start()
    {
        PlayerManager.Instance.player.detector.onZoneItem += Add;
        PlayerManager.Instance.player.detector.outZoneItem += Remove;
    }

    private void OnDestroy()
    {
        PlayerManager.Instance.player.detector.onZoneItem -= Add;
        PlayerManager.Instance.player.detector.outZoneItem -= Remove;
    }
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
        Destroy(listItemToPick[_itemObject].gameObject);
        listItemToPick.Remove(_itemObject);
    }
}
