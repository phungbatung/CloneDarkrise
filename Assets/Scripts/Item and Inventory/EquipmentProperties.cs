using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentProperties
{
    public Dictionary<string, string> properties;
    public int unlockedGemAmount;
    public int[] gemsId;
    public int enhanceLevel;

    public EquipmentProperties(Dictionary<string, string> _properties)
    {
        properties = _properties;
        unlockedGemAmount = 0;
        gemsId = new int[3];
    }
    public void UnlockGemSlot()
    {
        unlockedGemAmount += 1;
    }
}
