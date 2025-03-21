using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentMap
{
    public MapInfo MapInfo { get; private set; }
    public Map Map { get; private set; }

    public CurrentMap(MapInfo mapInfo, Map map)
    {
        MapInfo = mapInfo;
        Map = map;
    }
}
