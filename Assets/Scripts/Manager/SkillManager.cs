using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    [SerializeField] private Transform skillSlotParent;
    [SerializeField] private List<SkillSlot> skillSlots;

    //Skill
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
        skillSlots = skillSlotParent.GetComponentsInChildren<SkillSlot>().ToList();
        dash = GetComponent<Dash>();
        baseAttack = GetComponent<BaseAttack>();
        slash = GetComponent<Slash>();
        healWave = GetComponent<HealWaveSkill>();
        lightCut = GetComponent<LightCut>();
        wolfCall = GetComponent<WolfCall>();

        DefaulAssignSlot();
    }
    public void DefaulAssignSlot()
    {
        dash.AssignToSlot(skillSlots[0]);
        baseAttack.AssignToSlot(skillSlots[1]);
        slash.AssignToSlot(skillSlots[2]);
        healWave.AssignToSlot(skillSlots[3]);
        lightCut.AssignToSlot(skillSlots[4]);
        wolfCall.AssignToSlot(skillSlots[5]);
    }
}
