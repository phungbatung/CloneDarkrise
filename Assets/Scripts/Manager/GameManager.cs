using BlitzyUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static readonly BlitzyUI.Screen.Id fpsScreen = new BlitzyUI.Screen.Id("FPS", "FPS");
    public static readonly BlitzyUI.Screen.Id hudScreen = new BlitzyUI.Screen.Id("HUD", "HUD");
    public static readonly BlitzyUI.Screen.Id inventoryScreen = new BlitzyUI.Screen.Id("Inventory", "Inventory");
    public static readonly BlitzyUI.Screen.Id itemInfoScreen = new BlitzyUI.Screen.Id("ItemInfo", "ItemInfo");
    public static readonly BlitzyUI.Screen.Id activeSkillsScreen = new BlitzyUI.Screen.Id("ActiveSkills", "ActiveSkills");
    public static readonly BlitzyUI.Screen.Id passiveSkillsScreen = new BlitzyUI.Screen.Id("PassiveSkills", "PassiveSkills");
    public static readonly BlitzyUI.Screen.Id assignSkillsScreen = new BlitzyUI.Screen.Id("AssignSkill", "AssignSkill");
    public static readonly BlitzyUI.Screen.Id statsScreen = new BlitzyUI.Screen.Id("Stats", "Stats");

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        UnityEngine.Screen.orientation = ScreenOrientation.LandscapeLeft;
        UIManager.Instance.QueuePush(fpsScreen, null, null, null);
        UIManager.Instance.QueuePush(hudScreen, null, null, null);
    }
}
