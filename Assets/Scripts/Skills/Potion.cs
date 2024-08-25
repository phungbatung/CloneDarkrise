using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Skill
{
    private ItemSlot itemSlot;
    public override void Called()
    {
        base.Called();
        Inventory.Instance.UsePotion(itemSlot);
    }
    
    public void AssignSlotPotion(ItemSlot _itemSLot)
    {
        itemSlot = _itemSLot;
    }
}
