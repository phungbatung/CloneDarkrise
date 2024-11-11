using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    public Dash dash { get; private set; }
    public BaseAttack baseAttack { get; private set; }
    public Slash slash { get; private set; }
    public HealWave healWave { get; private set; }
    public LightCut lightCut { get; private set; }
    public WolfCall wolfCall { get; private set; }

    public int skillPoint { get; set; }

    public Skill[] assignedSkills;
    public Action assignEvent;

    public SkillPointUI skillPointUI;

    public Transform listSkillParent;
    public GameObject skillUIPrefab;
    public SkillInfo skillInfo;
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

    public void GenerateSkillUI()
    {
        Skill[] skills = GetComponents<Skill>();
        GameObject skillUI;
        foreach (Skill skill in skills)
        {
            skillUI = Instantiate(skillUIPrefab);
            skillUI.transform.SetParent(listSkillParent);
            skillUI.GetComponent<Skill_UI>().SetSkill(skill);
        }
        //skillInfo.UpdateUI(skills[0]);
    }

    public void AddSkillPoint(int _point)
    {
        skillPoint += _point;
        skillPointUI.UpdateUI(skillPoint);
    }
    public bool RemoveSkillPoint(int _point)
    {
        if (skillPoint < _point)
            return false;
        skillPoint -= _point;
        skillPointUI.UpdateUI(skillPoint);
        return true;
    }


    public void AssignSkillToSlot(Skill _skill, int _slotIndex)
    {
        assignedSkills[_slotIndex] = _skill;
        assignEvent?.Invoke();
    }
}
