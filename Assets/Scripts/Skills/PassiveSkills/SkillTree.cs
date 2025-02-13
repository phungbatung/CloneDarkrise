using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillTree
{
    public List<SkillNode> skillNodes;

    public SkillTree()
    {
        skillNodes = new List<SkillNode>();
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
}
