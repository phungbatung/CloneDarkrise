using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkills : MonoBehaviour
{
    public static PassiveSkills Instance {  get; private set; }

    public SkillTree skillTree { get; private set; }


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        InitSkillTree();
    }

    public void InitSkillTree()
    {
        TextAsset txt = Resources.Load<TextAsset>("SkillTreeData/TestSkillTreeData");
        skillTree = JsonUtility.FromJson<SkillTree>(txt.text);
    }
}
