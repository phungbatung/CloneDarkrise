using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInfo : MonoBehaviour
{
    [field: SerializeField] public string Id { get; private set; }
    public string DisplayName;
    [Header("Requirement")]
    public QuestInfo[] QuestPrequisites;

    
    [Header("QuestStep")]
    public QuestStep[] QuestSteps;

    [Header("Reward")]
    public int GoldReward;
    public int DiamondReward;
    public int ExpReward;
    public int[] ItemReward;
}
