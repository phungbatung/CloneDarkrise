using System;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected Player player { get; set; }
    public SkillData skillData { get; set; }
    public int currentLevel { get; protected set;}
    public  float cooldownTimer {  get; protected set; }
    protected bool isCooldownCompleted { get; set; }
    public Action cooldownEvent { get; set; }
    public bool isPressed { get; set; }

    protected virtual void Awake()
    {
        skillData = new SkillData();
        FillData();
        currentLevel = 0;
    }
    protected virtual void Start()
    {
        player = PlayerManager.Instance.player;
    }

    protected virtual void Update()
    {
        if (!isCooldownCompleted)
        {
            cooldownTimer -= Time.deltaTime;
            cooldownEvent?.Invoke();
            if (cooldownTimer <= 0)
                isCooldownCompleted = true;
        }
    }

    public virtual void Called()
    {
        cooldownTimer = skillData.levelsData[currentLevel].coolDown;
        isCooldownCompleted = false;
        player.stats.ManaIncreament(-skillData.levelsData[currentLevel].manaCost);
    }

    public virtual bool CanBeUse()
    {
        return  isPressed && cooldownTimer <= 0 && player.stats.currentMana >= skillData.levelsData[currentLevel].manaCost;
    }

    public int GetPointToUpgradeNextLevel()
    {
        return (int)Mathf.Pow(5, currentLevel + 1);
    }
    public virtual void Upgrade()
    {
        int pointToUpgrade = GetPointToUpgradeNextLevel();
        if (currentLevel < skillData.levelsData.Count - 1 && pointToUpgrade <= SkillManager.Instance.skillPoint)
        {
            SkillManager.Instance.RemoveSkillPoint(pointToUpgrade);
            currentLevel++;
        }
    }


    public virtual string GetUnlockedLevelDescription()
    {
        string desc = "";
        for(int level=0; level<=currentLevel; level++)
        {
            desc += skillData.levelsData[level].GetLevelDescription();
        }
        return desc;
    }
    public virtual string GetLockedLevelDescription()
    {
        string desc = "";
        for (int level = currentLevel+1; level < skillData.levelsData.Count; level++)
        {
            desc += skillData.levelsData[level].GetLevelDescription();
        }
        return desc;
    }
    public abstract string GetDescription();
    public abstract void FillData();

}
