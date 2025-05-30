using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaBar : Bar
{
    public override void OnValueChange()

    {
        currentValue = character.stats.currentMana;
        barImage.fillAmount = currentValue / maxValue;
    }

    public override void SetMaxValue()
    {
        maxValue = PlayerManager.Instance.player.stats.maxMana.GetValue();
        base.SetMaxValue();
    }
    private void Start()
    {
        character = PlayerManager.Instance.player;
        character.stats.OnManaChanged += OnValueChange;
        character.stats.maxMana.modifierEvent += SetMaxValue;
        SetMaxValue();
    }
}
