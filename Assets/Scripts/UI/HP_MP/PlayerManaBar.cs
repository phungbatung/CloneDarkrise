using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaBar : Bar
{
    private void Start()
    {
        character = PlayerManager.Instance.player;
        character.stats.OnManaChanged += OnValueChange;
        character.stats.maxMana.modifierEvent += SetMaxValue;
        SetMaxValue();
    }
}
