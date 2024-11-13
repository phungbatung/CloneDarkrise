using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }

    public Dash dash { get; private set; }
    public BaseAttack baseAttack { get; private set; }
    public Slash slash { get; private set; }
    public HealWave healWave { get; private set; }
    public LightCut lightCut { get; private set; }
    public WolfCall wolfCall { get; private set; }

    public int skillPoint { get; set; }
    public Action OnSkillPointChange { get; set; }

    public Skill[] assignedSkills { get; private set; }
    public Action assignEvent { get; set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        dash = GetComponent<Dash>();
        baseAttack = GetComponent<BaseAttack>();
        slash = GetComponent<Slash>();
        healWave = GetComponent<HealWave>();
        lightCut = GetComponent<LightCut>();
        wolfCall = GetComponent<WolfCall>();

        assignedSkills = new Skill[6];
        DefaulAssignSlot();
    }
    private void Start()
    {
        //GenerateSkillUI();
    }
    public void DefaulAssignSlot()
    {
        AssignSkillToSlot(dash, 0);
        AssignSkillToSlot(baseAttack, 1);
        AssignSkillToSlot(slash, 2);
        AssignSkillToSlot(healWave, 3);
        AssignSkillToSlot(lightCut, 4);
        AssignSkillToSlot(wolfCall, 5);
        
    }

    public void AddSkillPoint(int _point)
    {
        skillPoint += _point;
        OnSkillPointChange?.Invoke();
        Debug.Log(skillPoint);
    }
    public bool RemoveSkillPoint(int _point)
    {
        if (skillPoint < _point)
            return false;
        skillPoint -= _point;
        OnSkillPointChange?.Invoke();
        Debug.Log(skillPoint);
        return true;
    }


    public void AssignSkillToSlot(Skill _skill, int _slotIndex)
    {
        assignedSkills[_slotIndex] = _skill;
        assignEvent?.Invoke();
    }
}
