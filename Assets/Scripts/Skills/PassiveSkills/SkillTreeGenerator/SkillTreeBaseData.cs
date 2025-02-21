using System;
using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
# endif

[CreateAssetMenu(fileName = "SkillTreeBaseData", menuName ="Data/SkillTreeBaseData")]
public class SkillTreeBaseData : ScriptableObject
{
    public SerializableDictionary<string, SkillNodePrimaryData> data;
    public List<Sprite> frameBorder;
    [ContextMenu("CreateBaseData")]
    private void CreateBaseData()
    {
        foreach (var temp in Enum.GetNames(typeof (SkillNodeTemplate.StatType)))
        {
            data[temp] = new (data.Count);
        }
        SaveAsset(this);
    }
#if UNITY_EDITOR
    void SaveAsset(UnityEngine.Object @object)
    {
        EditorUtility.SetDirty(@object);
        AssetDatabase.SaveAssets();
    }
#endif
    [Serializable]    
    public class SkillNodePrimaryData
    {
        public int index;
        public int baseValue;
        public string description;
        public Sprite icon;
        public SkillNodePrimaryData(int _index)
        {
            index = _index;
            description = "*stat values increase with your level";
        }
    }
}
