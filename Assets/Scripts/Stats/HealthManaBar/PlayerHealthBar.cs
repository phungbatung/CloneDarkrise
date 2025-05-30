using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : Bar
{
    public override void OnValueChange()
    {
        currentValue = character.stats.currentHealth;
        barImage.fillAmount = currentValue / maxValue;
    }

    public override void SetMaxValue()
    {
        maxValue = PlayerManager.Instance.player.stats.maxHealth.GetValue();
        base.SetMaxValue();
    }
    private void Start()
    {
        character = PlayerManager.Instance.player;
        character.stats.OnHealthChanged += OnValueChange;
        character.stats.maxHealth.modifierEvent += SetMaxValue;
        SetMaxValue();
    }
}
