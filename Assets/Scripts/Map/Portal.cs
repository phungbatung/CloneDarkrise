using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : InteractableObject
{
    [SerializeField] private MapInfo linkedMap;

    public override void InteractAction()
    {
        //Call MapInfoPanel with parameter is linkedMap

        //Test
        MapManager.Instance.GoToMapByPortal(linkedMap);
    }
    
    public bool IsLinkedMap(MapInfo map)
    {
        return map.Id == linkedMap.Id;
    }    
}
