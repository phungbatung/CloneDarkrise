using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BlitzyUI.Screen;

[CreateAssetMenu(fileName = "MapInfo", menuName = "Data/MapInfo")]
public class MapInfo : ScriptableObject
{
    public string Id;
    public bool IsSafetyZone;

    public GameObject MapPrefab;

    private void Awake()
    {
#if UNITY_EDITOR
        Id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }

    private void OnValidate()
    {
        #if UNITY_EDITOR
        Id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}
