using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected Player player;
    [SerializeField] protected float cooldown;
    protected float cooldownTimer;
    protected virtual void Start()
    {
        player = PlayerManager.Instance.player;
    }
    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public virtual bool CanBeUse()
    {
        return cooldownTimer <= 0;
    }

    public virtual void Called()
    {
        cooldownTimer = cooldown;
    }    
}
