using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel : CharacterLevel
{
    [SerializeField] private int level;

    protected override void Awake()
    {
        base.Awake();
        Level = level;
    }
}
