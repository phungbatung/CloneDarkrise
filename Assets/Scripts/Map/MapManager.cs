using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour, ISaveManager
{

    public static MapManager Instance { get; private set; }
    public SerializableDictionary<string, MapData> MapsData { get; private set; }
    private CurrentMap currentMap;
    [SerializeField] private MapInfo respawnMap;

    private void Awake()
    {
        if (Instance==null)
            Instance = this;
        else
            Destroy(gameObject);


    }

    private void Start()
    {
        Respawn();
        
    }
    public void InitMapsData()
    {

    }    

    public void Respawn()
    {
        GoToMapByTeleportTower(respawnMap);
    }
    public void GoToMapByTeleportTower(MapInfo destinationInfo)
    {
        Map destinationMap = CreateMap(destinationInfo);

        destinationMap.JoinMapByTeleportTower();

        currentMap = new CurrentMap(destinationInfo, destinationMap);

        if(destinationInfo.IsSafetyZone)
        {
            respawnMap = destinationInfo;
        }    
    }

    public void GoToMapByPortal(MapInfo destinationInfo)
    {
        Map destinationMap = CreateMap(destinationInfo);

        destinationMap.JoinMapByPortal(currentMap.MapInfo);

        currentMap = new CurrentMap(destinationInfo, destinationMap);
    }
    
    public Map CreateMap(MapInfo mapInfo)
    {
        Map destinationMap = Instantiate(mapInfo.MapPrefab).GetComponent<Map>();
        if (destinationMap == null)
        {
            Debug.LogError($"Cannot create map name: \"{mapInfo.Id}\"");
        }

        //Destroy old map
        if (currentMap != null)
        {
            Destroy(currentMap.Map.gameObject);
        }

        //if (!MapsData[mapInfo.Id].IsUnlocked())
        //    MapsData[mapInfo.Id].Unlock();
        return destinationMap;
    }

      


    public void SaveData(ref GameData gameData)
    {

    }

    public void LoadData(GameData gameData)
    {

    }
}
