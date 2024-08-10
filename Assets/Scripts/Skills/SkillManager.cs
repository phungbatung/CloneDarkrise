using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    public BaseAttack baseAttack;
    public HealWaveSkill healWave;
    public Slash slash;
    public LightCut lightCut;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        healWave = GetComponent<HealWaveSkill>();
        slash = GetComponent<Slash>();
        baseAttack = GetComponent<BaseAttack>();
        lightCut = GetComponent<LightCut>();
    }
}
