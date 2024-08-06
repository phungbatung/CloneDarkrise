using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Data/ItemDataBase")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> itemsData;
    public SerializableDictionary<int, ItemData> itemDataDictionary = new SerializableDictionary<int, ItemData>(); 

    public void FillUpDatabase()
    {
        itemsData.Clear();
        itemDataDictionary.Clear();

        string[] paths = { "Rare", "Epic", "Legend" };
        List<Sprite> sprites = new List<Sprite>();
        //Fill up base info
        foreach (var path in paths)
        {
            sprites.AddRange(Resources.LoadAll<Sprite>($"ItemDataBase\\ItemIcons\\{path}"));
        }    
        string itemsInfo = Resources.Load<TextAsset>("ItemDataBase\\ItemInfo").text;
        string[] listItemInfo = itemsInfo.Split(new char[] { '\n' });
        ItemData item = new ItemData();
        for (int i=1; i<listItemInfo.Length-1; i++)
        {
            string[] data = listItemInfo[i].Split(new char[] { ',' });
            if (data[0]!="")
            {
                item = new ItemData();
                item.id = int.Parse(data[0]);
                item.type = (ItemType)(int.Parse(data[0])/100000);
                item.quality = (ItemQuality)((int.Parse(data[0]) / 10000)%10);
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


        //Fill up equipment properties
        string equipmentsData = Resources.Load<TextAsset>("ItemDataBase\\EquipmentData").text;
        string[] listEquipmentData = equipmentsData.Split(new char[] {'\n'});
        for (int i=1; i<listEquipmentData.Length; i++)
        {
            string[] data = listEquipmentData[i].Split(new char[] { ',', '\r'});
            if (data[0] != "")
            {
                item = itemDataDictionary[int.Parse(data[0])];
                if (data[1]!="0")
                    item.properties[Constant.ATTACK] = data[1];
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

            }
        }
    }
}
