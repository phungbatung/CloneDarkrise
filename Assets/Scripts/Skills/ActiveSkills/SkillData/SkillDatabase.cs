using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillDatabase", menuName = "Data/SkillDatabase")]
public class SkillDatabase : ScriptableObject
{
    public SerializableDictionary<string, SkillData> skillsDataDict;

    private string dataPath = "SkillData/Data";
    private string iconPath = "SkillData/Icon";

    [ContextMenu("Fill up skill database")]
    public void FillUpSkillDatabase()
    {
        skillsDataDict = new();
        TextAsset[] listText = Resources.LoadAll<TextAsset>(dataPath);
        Sprite[] listIcon = Resources.LoadAll<Sprite>(iconPath);
        Debug.Log(listText.Length + " " +listIcon.Length );
        SkillData skillData;
        for (int i = 0; i < listText.Length; i++)
        {
            Debug.Log(i);
            skillData = CreateSkillData(i, listText[i].name, listIcon[i], listText[i].text);
            skillsDataDict.Add(skillData.skillName, skillData);
        }
    }

    public SkillData CreateSkillData(int id, string name, Sprite icon, string levelsData)
    {
        SkillData skillData = new SkillData();
        skillData.id = id;
        skillData.skillName = name;
        skillData.icon = icon;
        string[] lines = levelsData.Split('\n');
        string[] keys = lines[0].Split(',');
        for (int i=1; i < keys.Length; i++)
        {
            SkillLevelData levelData = new SkillLevelData();
            string[] values = lines[i].Split(",");
            if (values.Length != keys.Length)
                continue;
            for(int j=0; j < values.Length; j++)
            {
                levelData.properties.Add(keys[j], values[j]);
            }
            skillData.levelsData.Add(levelData);
        }
        return skillData;
    }

}

