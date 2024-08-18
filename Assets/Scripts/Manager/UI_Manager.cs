using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;
    public ItemInfo itemInfo;
    public ListItemToPick listItemToPick;
    public Transform mainViewParent;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        itemInfo.gameObject.SetActive(false);
    }
}
