using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    public Dash dash;
    public BaseAttack baseAttack;
    public Slash slash;
    public HealWaveSkill healWave;
    public LightCut lightCut;
    public WolfCall wolfCall;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        dash = GetComponent<Dash>();
        baseAttack = GetComponent<BaseAttack>();
        slash = GetComponent<Slash>();
        healWave = GetComponent<HealWaveSkill>();
        lightCut = GetComponent<LightCut>();
        wolfCall = GetComponent<WolfCall>();

    }
    private void Start()
    {
        DefaulAssignSlot();
        
    }
    public void DefaulAssignSlot()
    {
        dash.AssignToSlot(InputManager.Instance.skillSlots[0]);
        baseAttack.AssignToSlot(InputManager.Instance.skillSlots[1]);
        slash.AssignToSlot(InputManager.Instance.skillSlots[2]);
        healWave.AssignToSlot(InputManager.Instance.skillSlots[3]);
        lightCut.AssignToSlot(InputManager.Instance.skillSlots[4]);
        wolfCall.AssignToSlot(InputManager.Instance.skillSlots[5]);
    }
}
