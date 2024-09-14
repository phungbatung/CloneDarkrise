using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
    }
    private void Start()
    {
        DefaulAssignSlot();
        GenerateSkillUI();
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
        skillInfo.UpdateUI(skills[0]);
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
}
