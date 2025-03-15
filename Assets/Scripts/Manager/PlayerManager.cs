using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, ISaveManager
{
    public static PlayerManager Instance;
    public Player player;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void LoadData(GameData gameData)
    {
        PlayerData LoadData = gameData.PlayerData;
        player.levels.SetLevel(LoadData.level, LoadData.exp);
    }

    public void SaveData(ref GameData gameData)
    {
        PlayerData saveData = new PlayerData(player.levels.Level, player.levels.Exp);
        gameData.PlayerData = saveData;
    }
}
