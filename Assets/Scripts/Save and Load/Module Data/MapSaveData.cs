using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapSaveData
{
    public List<MapSave> MapsData;

    public MapSaveData()
    {
        MapsData = new List<MapSave>();
    }
    public MapSaveData(List<MapData> mapsData)
    {
        MapsData = new();
        foreach (MapData mapData in mapsData)
        {
            MapsData.Add(mapData);
        }
    }

    [Serializable]
    public class MapSave
    {
        public string Id;
        public bool unlocked;

        public MapSave(string id, bool unlocked)
        {
            this.Id = id;
            this.unlocked = unlocked;
        }

        public static implicit operator MapSave(MapData data) => new MapSave(data.MapInfo.Id, data.IsUnlocked());
    }
}
