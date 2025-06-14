using BlitzyUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static readonly BlitzyUI.Screen.Id fpsScreen = new BlitzyUI.Screen.Id("FPS", "FPS");
    public static readonly BlitzyUI.Screen.Id hudScreen = new BlitzyUI.Screen.Id("HUD", "HUD");
    public static readonly BlitzyUI.Screen.Id inventoryScreen = new BlitzyUI.Screen.Id("Inventory", "Inventory");
    public static readonly BlitzyUI.Screen.Id itemInfoScreen = new BlitzyUI.Screen.Id("ItemInfo", "ItemInfo");
    public static readonly BlitzyUI.Screen.Id activeSkillsScreen = new BlitzyUI.Screen.Id("ActiveSkills", "ActiveSkills");
    public static readonly BlitzyUI.Screen.Id passiveSkillsScreen = new BlitzyUI.Screen.Id("PassiveSkills", "PassiveSkills");
    public static readonly BlitzyUI.Screen.Id assignSkillsScreen = new BlitzyUI.Screen.Id("AssignSkill", "AssignSkill");
    public static readonly BlitzyUI.Screen.Id statsScreen = new BlitzyUI.Screen.Id("Stats", "Stats");
    public static readonly BlitzyUI.Screen.Id gemInsertionScreen = new BlitzyUI.Screen.Id("GemInsertion", "GemInsertion");
    public static readonly BlitzyUI.Screen.Id upgradeEquipmentScreen = new BlitzyUI.Screen.Id("UpgradeEquipment", "UpgradeEquipment");
    public static readonly BlitzyUI.Screen.Id worldMapScreen = new BlitzyUI.Screen.Id("WorldMap", "WorldMap");
    public static readonly BlitzyUI.Screen.Id npcOptionSelectorScreen = new BlitzyUI.Screen.Id("NPC_OptionSelectorScreen", "NPC_OptionSelectorScreen");
    public static readonly BlitzyUI.Screen.Id revivePopup = new BlitzyUI.Screen.Id("RevivePopup", "RevivePopup");


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        //Physics2D.callbacksOnDisable = false;
    }
    void Start()
    {
        UnityEngine.Screen.orientation = ScreenOrientation.LandscapeLeft;
        Application.targetFrameRate = 120;
        QualitySettings.vSyncCount = 0;
        UIManager.Instance.QueuePush(fpsScreen, null, null, null);
        UIManager.Instance.QueuePush(hudScreen, null, null, null);
    }
}
