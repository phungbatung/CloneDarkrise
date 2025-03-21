using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    private List<Enemy> enemies;
    private List<Portal> portals;
    private TeleportTower teleportTower;
    private void Awake()
    {
        enemies = GetComponentsInChildren<Enemy>().ToList();
        portals = GetComponentsInChildren<Portal>().ToList();
        teleportTower = GetComponentInChildren<TeleportTower>();
    }
    public void JoinMapByTeleportTower()
    {
        PlayerManager.Instance.player.transform.position = teleportTower.transform.position;
    }
    public void JoinMapByPortal(MapInfo fromMap)
    {
        Portal entryPortal = GetEntryPortal(fromMap);
        PlayerManager.Instance.player.transform.position = entryPortal.transform.position;
    }    
    public Portal GetEntryPortal(MapInfo fromMap)
    {
        Portal entryPortal = null;
        foreach (var portal in portals)
        {
            if (portal.IsLinkedMap(fromMap))
            {
                entryPortal = portal;
                break;
            }    
        }    
        return entryPortal;

    }    
}
