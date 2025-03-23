using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    public MapInfo MapInfo { get; private set; }
    private bool unlocked { get; set; }

    public MapData(MapInfo mapInfo, bool unlocked)
    {
        this.MapInfo = mapInfo;
        this.unlocked = unlocked;
    }

    public bool IsUnlocked() => unlocked;
    public bool Unlock() => unlocked = true;
}
