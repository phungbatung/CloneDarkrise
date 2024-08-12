using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Data/ItemDataBase")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> itemsData;
    public SerializableDictionary<int, ItemData> itemDataDictionary = new SerializableDictionary<int, ItemData>(); 

    public void FillUpDatabase()
    {
        itemsData.Clear();
        itemDataDictionary.Clear();
        FillUpGeneralData();
        FillUpEquipmentProperties();
        FillUpPotionProperties();
        FillUpSkillBookProperties();
        FillUpBuffProperties();
        FillUpMagicDustProperties();
    }

    private void FillUpGeneralData()
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
                itemsData.Add(item);
                itemDataDictionary[item.id] = item;
                Debug.Log($"{itemDataDictionary[item.id].id}");
            }
        }
    }
    private void FillUpEquipmentProperties()
    {
        string equipmentsData = Resources.Load<TextAsset>("ItemDataBase\\EquipmentData").text;
        string[] listEquipmentData = equipmentsData.Split(new char[] { '\n' });
        ItemData item;
        for (int i = 1; i < listEquipmentData.Length; i++)
        {
            string[] data = listEquipmentData[i].Split(new char[] { ',', '\r' });
            if (data[0] != "")
            {
                item = itemDataDictionary[int.Parse(data[0])];
                if (data[1] != "0")
                    item.properties[Constant.DAMAGE] = data[1];
                if (data[2] != "0")
                    item.properties[Constant.ATTACK_SPEED] = data[2];
                if (data[3] != "0")
                    item.properties[Constant.ARMOR_PENETRATION] = data[3];
                if (data[4] != "0")
                    item.properties[Constant.CRITICAL_RATE] = data[4];
                if (data[5] != "0")
                    item.properties[Constant.CRITICAL_DAMAGE] = data[5];
                if (data[6] != "0")
                    item.properties[Constant.HEALTH] = data[6];
                if (data[7] != "0")
                    item.properties[Constant.HEALTH_REGEN] = data[7];
                if (data[8] != "0")
                    item.properties[Constant.ARMOR] = data[8];
                if (data[9] != "0")
                    item.properties[Constant.MANA] = data[9];
                if (data[10] != "0")
                    item.properties[Constant.MANA_REGEN] = data[10];
                if (data[11] != "0")
                    item.properties[Constant.MOVE_SPEED] = data[11];
            }
        }
    }
    private void FillUpPotionProperties()
    {
        string potionsData = Resources.Load<TextAsset>("ItemDataBase\\PotionData").text;
        string[] listPotionData = potionsData.Split(new char[] { '\n' });
        ItemData item;
        for (int i=1; i<listPotionData.Length; i++)
        {
            string[] data = listPotionData[i].Split(new char[] { ',', '\r' });
            if (data[0] != "")
            {
                item = itemDataDictionary[int.Parse(data[0])];
                if (data[1] != "0")
                    item.properties[Constant.HEALTH] = data[1];
                if (data[2] != "0")
                    item.properties[Constant.MANA] = data[2];
                if (data[3] != "0")
                    item.properties[Constant.COOLDOWN] = data[3];
            }
        }
    }
    private void FillUpSkillBookProperties()
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
    private void FillUpBuffProperties()
    {
        string buffsData = Resources.Load<TextAsset>("ItemDataBase\\BuffData").text;
        string[] listBuffData = buffsData.Split(new char[] { '\n' });
        ItemData item;
        for (int i = 1; i < listBuffData.Length; i++)
        {
            string[] data = listBuffData[i].Split(new char[] { ',', '\r' });
            if (data[0] != "")
            {
                item = itemDataDictionary[int.Parse(data[0])];
                if (data[1] != "0")
                    item.properties[Constant.HEALTH] = data[1];
                if (data[2] != "0")
                    item.properties[Constant.MANA] = data[2];
                if (data[3] != "0")
                    item.properties[Constant.COOLDOWN] = data[3];
            }
        }
    }
    private void FillUpMagicDustProperties() 
    {
        string magicDustsData = Resources.Load<TextAsset>("ItemDataBase\\MagicDustData").text;
        string[] listMagicDustData = magicDustsData.Split(new char[] { '\n' });
        ItemData item;
        for (int i = 1; i < listMagicDustData.Length; i++)
        {
            string[] data = listMagicDustData[i].Split(new char[] { ',', '\r' });
            if (data[0] != "")
            {
                item = itemDataDictionary[int.Parse(data[0])];
                if (data[1] != "0")
                    item.properties[Constant.DAMAGE] = data[1];
                if (data[2] != "0")
                    item.properties[Constant.HEALTH] = data[2];
            }
        }
    }

}
