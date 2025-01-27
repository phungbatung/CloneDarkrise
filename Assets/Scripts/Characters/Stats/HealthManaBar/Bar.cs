using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    protected Character character;
    protected Image barImage;
    protected float maxValue;
    protected float currentValue;
    protected virtual void Awake()
    {
        barImage = GetComponent<Image>();
    }

    public abstract void OnValueChange();
    public virtual void SetMaxValue()
    {
        maxValue = PlayerManager.Instance.player.stats.maxHealth.GetValue();
        OnValueChange();
    }    
}
