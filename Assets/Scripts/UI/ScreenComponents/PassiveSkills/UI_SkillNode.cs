using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SkillNode : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image frame;
    [SerializeField] private Image icon;
    public Action<SkillNode> OnClick {  get; set; }
    public SkillNode skillNode;
    public Dictionary<UI_SkillNode,UI_SkillTreeEdge> lineToNeighbors = new();
    public void SetupSkillNode(SkillNode _skillNode, Transform parent, SkillTreeBaseData data)
    {
        skillNode = _skillNode;
        transform.SetParent(parent);
        transform.position = skillNode.position;


        frame.sprite = data.frameBorder[skillNode.powerLevel];
        icon.sprite = data.data[skillNode.name].icon;
        if(skillNode.powerLevel == 0)
        {
            transform.localScale = Vector3.one;
        }   
        else if(skillNode.powerLevel == 1)
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        else if (skillNode.powerLevel == 2)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }    
        
        SetActivationUI(skillNode.unlocked);
    }

    private void SetActivationUI(bool isActive)
    {
        float value = isActive? 1.0f : (75f/256f);
        frame.color = new Color(value, value, value);
        icon.color = new Color(value, value, value);

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke(skillNode);
    }
}
