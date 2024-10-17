using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    private CharacterStats characterStats;


    [SerializeField] private GameObject buffPrefab;
    [SerializeField] private Transform buffHolder;

    private Dictionary<BuffType, BuffPresenter> buffDict = new();
    private List<BuffPresenter> buffs = new();
    private void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        foreach (BuffPresenter buff in buffs)
        {
            buff.ExecuteCountDown(Time.deltaTime);
        }
    }
    public void StartBuff(int id)
    {
        EndBuff(id);   
        ItemData item = ItemManager.Instance.itemDict[id];
        float buffDuration = float.Parse(item.properties[ItemUtilities.DURATION]);
        characterStats.AddModifier(item.properties);
        GameObject buffView = Instantiate(buffPrefab);
        buffView.transform.SetParent(buffHolder);
        BuffPresenter buffPresenter = new BuffPresenter(this, buffView.GetComponent<BuffView>(), id, buffDuration);
        buffDict[ItemUtilities.GetBuffTypeById(id)] = buffPresenter;
        buffs.Add(buffPresenter);
    }
    public void StartBuff(int id, float duration)
    {
        EndBuff(id);
        ItemData item = ItemManager.Instance.itemDict[id];
        float buffDuration = duration;
        characterStats.AddModifier(item.properties);
        GameObject buffView = Instantiate(buffPrefab);
        buffView.transform.SetParent(buffHolder);
        BuffPresenter buffPresenter = new BuffPresenter(this, buffView.GetComponent<BuffView>(), id, buffDuration);
        buffDict[ItemUtilities.GetBuffTypeById(id)] = buffPresenter;
        buffs.Add(buffPresenter);
    }
    public void EndBuff(int id)
    {
        if (buffDict.TryGetValue(ItemUtilities.GetBuffTypeById(id), out BuffPresenter buffPresenter))
        {
            ItemData item = ItemManager.Instance.itemDict[buffPresenter.buffModel.itemId];
            characterStats.RemoveModifier(item.properties);
            buffPresenter.EndBuff();
            buffs.Remove(buffPresenter);
            buffDict.Remove(ItemUtilities.GetBuffTypeById(id));
        }    

    }
}
