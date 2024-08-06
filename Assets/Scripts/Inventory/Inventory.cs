using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IDragHandler
{
    public static Inventory Instance;


    public ItemDatabase itemDatabase;

    public Transform itemSlotsParent;
    public List<ItemSlot> itemSlots;

    public Transform moveItem;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        itemSlots = itemSlotsParent.GetComponentsInChildren<ItemSlot>().ToList();

    }


    public void AddItem(int _itemId, Dictionary<string, string> properties = null)
    {
        List<ItemSlot> slots = GetItemSlotById(_itemId);
        foreach (var slot in slots)
        {
            if (slot.CanBeAdded())
            {
                slot.AddItem(_itemId, properties);
                return;
            }
        }
        AddNewItem(_itemId, properties);
    }
    public void AddNewItem(int _itemId, Dictionary<string, string> properties)
    {
        foreach (ItemSlot slot in itemSlots)
        {
            if (slot.IsEmpty())
            {
                slot.AddItem(_itemId, 1 , properties);
                return;
            }
        }
    }
    public void RemoveItem()
    {

    }

    public List<ItemSlot> GetItemSlotById(int _itemId)
    {
        List<ItemSlot> listItem = new List<ItemSlot>();
        foreach (ItemSlot item in itemSlots)
        {
            if (_itemId == item.itemId)
                listItem.Add(item);
        }
        return listItem;
    }
    [ContextMenu("Fill up item database")]
    public void FillUpItemDataBase()
    {
        itemDatabase.FillUpDatabase();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position += (Vector3)eventData.delta;
    }
}
