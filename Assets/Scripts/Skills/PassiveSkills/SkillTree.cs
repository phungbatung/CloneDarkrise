using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillTree
{
    public List<SkillNode> skillNodes;
    public int skillPoint;
    public SkillTree()
    {
        skillNodes = new List<SkillNode>();
        skillPoint = 0;
    }
    public SkillTree(List<SkillNode> _skillNodes, int _skillPoint)
    {
        skillNodes = _skillNodes;
        skillPoint = _skillPoint;
    }

    public List<SkillNode> GetNeighborsOf(SkillNode node)
    {
        List<SkillNode> neighbors = new List<SkillNode>();
        foreach (var nodeId in node.neighbors)
        {
            neighbors.Add(skillNodes[nodeId]);
        }    
        return neighbors;
    }  
    
    public bool CanBeUnlock(SkillNode node)
    {
        if(skillPoint <=0 && node.unlocked)
            return false;
        List<SkillNode> neighbors = GetNeighborsOf(node);
        foreach (var neighbor in neighbors)
        {
            if (neighbor.unlocked)
            {
                return true;
            }
        }
        return false;
    }

    public void Unlock(SkillNode node)
    {
        if (!CanBeUnlock(node))
            return;
        node.unlocked = true;
        skillPoint--;
        ApplyStat(node);
    }

    public void ApplyStat(SkillNode node)
    {
        PlayerManager.Instance.player.stats.AddModifier(node.properties);
    }
    public void RemoveStat(SkillNode node)
    {
        PlayerManager.Instance.player.stats.RemoveModifier(node.properties);
    }

}