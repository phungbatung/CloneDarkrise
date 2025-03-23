using BlitzyUI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_MapNode : MonoBehaviour, IPointerClickHandler
{
    private Image icon;
    private TextMeshProUGUI mapName;

    [SerializeField] private MapInfo mapInfo;
    [SerializeField] private Color blur;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (mapInfo == null)
            return;
        MapData mapData = MapManager.Instance.MapsData[mapInfo.Id];
        if (mapData.IsUnlocked())
        {
            MapManager.Instance.GoToMapByTeleportTower(mapInfo);
            UIManager.Instance.QueuePop();
        }
        else
        {
            Debug.Log($"{mapInfo.Name} is locked!");
        }
    }

    private void OnEnable()
    {
        mapName = GetComponentInChildren<TextMeshProUGUI>();
        icon = GetComponentInChildren<Image>();


        if (mapInfo != null)
        {
            mapName.text = mapInfo.Name;
            MapData mapData = MapManager.Instance.MapsData[mapInfo.Id];
            if (mapData.IsUnlocked())
            {
                icon.color = Color.white;
            }
            else
            { 
                icon.color = blur;
            }
        }
        else
        {
            mapName.text = "Unknown";
            icon.color = blur;
        }
    }



    private void OnValidate()
    {
        mapName = GetComponentInChildren<TextMeshProUGUI>();
        if (mapInfo != null)
            mapName.text = mapInfo.Name;
        else
            mapName.text = "Unknown";
    }
}
