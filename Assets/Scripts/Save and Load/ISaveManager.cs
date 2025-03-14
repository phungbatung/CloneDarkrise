using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveManager
{
    public void SaveData(ref GameData gameData);
    public void LoadData(GameData gameData);
}
