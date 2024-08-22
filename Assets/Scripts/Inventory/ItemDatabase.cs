using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Data/ItemDataBase")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> itemList = new List<ItemData>();
  
    public void FillUpDatabase()
    {
        Dictionary<int, ItemData> itemDict = new Dictionary<int, ItemData>();
        itemList.Clear();
        FillUpGeneralData(itemDict); //fill common properties
        FillUpEquipmentProperties(itemDict);
        FillUpPotionProperties(itemDict);
        FillUpSkillBookProperties(itemDict);
        FillUpBuffProperties(itemDict);
        FillUpMagicDustProperties(itemDict);
        SaveAsset(this);
    }
    void SaveAsset(Object @object)
    {
        EditorUtility.SetDirty(@object);
        AssetDatabase.SaveAssets();
    }
    private void FillUpGeneralData(Dictionary<int, ItemData> itemDataDictionary)
    {
        string[] paths = { "Rare", "Epic", "Legend" };
        List<Sprite> sprites = new List<Sprite>();
        foreach (var path in paths)
        {
            sprites.AddRange(Resources.LoadAll<Sprite>($"ItemDataBase\\ItemIcons\\{path}"));
        }

        string itemsInfo = Resources.Load<TextAsset>("ItemDataBase\\ItemInfo").text;
        string[] listItemInfo = itemsInfo.Split(new char[] { '\n' });
        ItemData item = new ItemData();
        for (int i = 1; i < listItemInfo.Length - 1; i++)
        {
            string[] data = listItemInfo[i].Split(new char[] { ',' });
            if (data[0] != "")
            {
                item = new ItemData();
                item.id = int.Parse(data[0]);
                item.type = (ItemType)(int.Parse(data[0]) / 100000);
                item.quality = (ItemQuality)((int.Parse(data[0]) / 10000) % 10);
                item.name = data[1];
                item.icon = sprites.Single(s => s.name == data[2]);
                item.level = int.Parse(data[3]);
                item.description = data[4];
                item.maxSize = int.Parse(data[5]);
                itemList.Add(item);
                itemDataDictionary[item.id] = item;
                //Debug.Log($"{itemDataDictionary[item.id].id}");
            }
        }
    }

    private void FillUpEquipmentProperties(Dictionary<int, ItemData> itemDataDictionary)
    {
        string equipmentsData = Resources.Load<TextAsset>("ItemDataBase\\EquipmentData").text;
        string[] listEquipmentData = equipmentsData.Split(new char[] { '\n' });
        ItemData item;
        string[] propertiesName = { "", Constant.DAMAGE, Constant.ATTACK_SPEED, Constant.ARMOR_PENETRATION, 
                                        Constant.CRITICAL_RATE, Constant.CRITICAL_DAMAGE, Constant.HEALTH, Constant.HEALTH_REGEN,
                                        Constant.ARMOR, Constant.MANA, Constant.MANA_REGEN, Constant.MOVE_SPEED};
        for (int i = 1; i < listEquipmentData.Length; i++)
        {
            string[] data = listEquipmentData[i].Split(new char[] { ',', '\r' });
            if (int.TryParse(data[0], out int _id))
            {
                item = itemDataDictionary[_id];
                for (int j = 1; j < data.Length; j++)
                {
                    if (data[j] != "0" && data[j].Length!=0)
                        item.properties[propertiesName[j]] = data[j];
                }
            }
        }
    }

    private void FillUpPotionProperties(Dictionary<int, ItemData> itemDataDictionary)
    {
        string potionsData = Resources.Load<TextAsset>("ItemDataBase\\PotionData").text;
        string[] listPotionData = potionsData.Split(new char[] { '\n' });
        ItemData item;
        string[] propertiesName = { "", Constant.HEALTH, Constant.MANA, Constant.COOLDOWN};
        for (int i=1; i<listPotionData.Length; i++)
        {
            string[] data = listPotionData[i].Split(new char[] { ',', '\r' });
            if (int.TryParse(data[0], out int _id))
            {
                item = itemDataDictionary[_id];
                for (int j = 1; j < data.Length; j++)
                {
                    if (data[j] != "0" && data[j].Length != 0)
                        item.properties[propertiesName[j]] = data[j];
                }
            }
        }
    }

    private void FillUpSkillBookProperties(Dictionary<int, ItemData> itemDataDictionary)
    {
        string skillBooksData = Resources.Load<TextAsset>("ItemDataBase\\SkillBookData").text;
        string[] listSkillBookData = skillBooksData.Split(new char[] { '\n' });
        ItemData item;
        
        for (int i = 1; i < listSkillBookData.Length; i++)
        {
            string[] data = listSkillBookData[i].Split(new char[] { ',', '\r' });
            if (data[0] != "")
            {
                item = itemDataDictionary[int.Parse(data[0])];
                if (data[1] != "0")
                    item.properties[Constant.SKILL_POINT] = data[1];
            }
        }
    }

    private void FillUpBuffProperties(Dictionary<int, ItemData> itemDataDictionary)
    {
        string buffsData = Resources.Load<TextAsset>("ItemDataBase\\BuffData").text;
        string[] listBuffData = buffsData.Split(new char[] { '\n' });
        ItemData item;
        string[] propertiesName = { "", Constant.HEALTH, Constant.MANA, Constant.COOLDOWN };
        for (int i = 1; i < listBuffData.Length; i++)
        {
            string[] data = listBuffData[i].Split(new char[] { ',', '\r' });
            if (int.TryParse(data[0], out int _id))
            {
                item = itemDataDictionary[_id];
                for (int j = 1; j < data.Length; j++)
                {
                    if (data[j] != "0" && data[j].Length != 0)
                        item.properties[propertiesName[j]] = data[j];
                }
            }
        }
    }

    private void FillUpMagicDustProperties(Dictionary<int, ItemData> itemDataDictionary) 
    {
        string magicDustsData = Resources.Load<TextAsset>("ItemDataBase\\MagicDustData").text;
        string[] listMagicDustData = magicDustsData.Split(new char[] { '\n' });
        ItemData item;
        string[] propertiesName = { "", Constant.DAMAGE, Constant.HEALTH };
        for (int i = 1; i < listMagicDustData.Length; i++)
        {
            string[] data = listMagicDustData[i].Split(new char[] { ',', '\r' });
            if (int.TryParse(data[0], out int _id))
            {
                item = itemDataDictionary[_id];
                for (int j = 1; j < data.Length; j++)
                {
                    if (data[j] != "0" && data[j].Length != 0)
                        item.properties[propertiesName[j]] = data[j];
                }
            }

        }
    }

}
