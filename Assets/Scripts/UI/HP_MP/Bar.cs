using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    protected Character character;
    protected Image healthBar;
    protected float maxValue;
    protected float currentValue;
    protected virtual void Awake()
    {
        healthBar = GetComponent<Image>();
    }
    
    public virtual void OnValueChange()
    {
        currentValue = character.stats.currentHealth;
        healthBar.fillAmount = currentValue/maxValue;
    }
    public virtual void SetMaxValue()
    {
        maxValue = PlayerManager.Instance.player.stats.maxHealth.GetValue();
        OnValueChange();
        Debug.Log("log1");
    }    
}
