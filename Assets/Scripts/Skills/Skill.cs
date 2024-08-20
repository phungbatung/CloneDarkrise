using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected Player player;

    [SerializeField] protected Sprite skillIcon;
    [SerializeField] protected float cooldown;
    protected float cooldownTimer;
    protected bool isCoolDownCompleted;

    protected bool isAssigned;
    protected SkillSlot slot;


    protected virtual void Start()
    {
        player = PlayerManager.Instance.player;
        Debug.Log($"{slot.name}: {slot.image.color.a}");
    }
    protected virtual void Update()
    {
        if (!isCoolDownCompleted)
        {
            cooldownTimer -= Time.deltaTime;
            if (isAssigned)
                slot.DoCooldown(cooldownTimer, cooldown);
            if (cooldownTimer <= 0)
                isCoolDownCompleted = true;
        }
    }
    public virtual void Called()
    {
        cooldownTimer = cooldown;
        isCoolDownCompleted = false;
    }
    public virtual bool CanBeUse()
    {
        return  isAssigned && slot.isPressed && cooldownTimer <= 0;
    }
    public virtual void AssignToSlot(SkillSlot _skillSlot)
    {
        isAssigned = true;
        slot = _skillSlot;
        slot.image.sprite = skillIcon;
    }

    public virtual void UnassignSlot()
    {
        isAssigned = false;
        slot = null;
    }
}
