using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected Player player;

    public SkillData skillData;
    public int currentLevel = 0;
    protected float cooldownTimer;
    protected bool isCoolDownCompleted;

    protected bool isAssigned;
    protected SkillSlot slot;
    protected virtual void Awake()
    {
        FillData();
    }
    protected virtual void Start()
    {
        player = PlayerManager.Instance.player;
    }

    protected virtual void Update()
    {
        if (!isCoolDownCompleted)
        {
            cooldownTimer -= Time.deltaTime;
            if (isAssigned)
                slot.DoCooldown(cooldownTimer, skillData.levelsData[currentLevel].coolDown);
            if (cooldownTimer <= 0)
                isCoolDownCompleted = true;
        }
    }

    public virtual void Called()
    {
        cooldownTimer = skillData.levelsData[currentLevel].coolDown;
        isCoolDownCompleted = false;
        player.stats.ManaIncreament(-skillData.levelsData[currentLevel].manaCost);
    }

    public virtual bool CanBeUse()
    {
        return  isAssigned && slot.isPressed && cooldownTimer <= 0;
    }

    public virtual void AssignToSlot(SkillSlot _skillSlot)
    {
        isAssigned = true;
        slot = _skillSlot;
        slot.image.sprite = skillData.icon;
    }

    public virtual void UnassignSlot()
    {
        isAssigned = false;
        slot = null;
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
