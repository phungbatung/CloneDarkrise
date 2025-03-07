using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_SkillTree : MonoBehaviour
{
    [SerializeField] private SkillTreeBaseData baseData;
    [SerializeField] private UI_SkillNodeUnlockWindow unlockWindow;
    [SerializeField] private UI_SkillNode skillNodePrefab;
    [SerializeField] private Transform nodeParents;
    [SerializeField] private UI_SkillTreeEdge lineRendererPrefab;
    [SerializeField] private Transform lineParents;
    [SerializeField] private TextMeshProUGUI skillPoint;
    private SkillTree skillTree;
    private Dictionary<SkillNode, UI_SkillNode> skillNodesUI;


    public void SetupData(SkillTree _skillTree)
    {
        skillTree = _skillTree;
        GenerateUISkillTree();
        skillPoint.text = skillTree.skillPoint.ToString();
    }

    public void GenerateUISkillTree()
    {
        GenerateNode();
        GenerateLines();
    }

    private void GenerateNode()
    {
        skillNodesUI = new();
        foreach (var node in skillTree.skillNodes)
        {
            CreateNode(node);
        }
    }

    private void CreateNode(SkillNode node)
    {
        
        UI_SkillNode nodeUI = Instantiate(skillNodePrefab);
        nodeUI.SetupSkillNode(node, nodeParents, baseData);
        skillNodesUI[node] = nodeUI;
        nodeUI.OnClick += OpenSkillNodeUnlockWindow;
    }

    public void GenerateLines()
    {
        UI_SkillTreeEdge line;
        UI_SkillNode curNodeUI;
        List<SkillNode> neighbors;
        UI_SkillNode neighborNodeUI;
        foreach(var node in skillTree.skillNodes)
        {
            curNodeUI = skillNodesUI[node];
            neighbors = skillTree.GetNeighborsOf(node);
            foreach (var  neighbor in neighbors)
            {
                neighborNodeUI = skillNodesUI[neighbor];
                if (neighborNodeUI.lineToNeighbors.ContainsKey(curNodeUI))
                {
                    continue;
                }
                line = CreateLine(curNodeUI, neighborNodeUI, node.unlocked && neighbor.unlocked);
                curNodeUI.lineToNeighbors[neighborNodeUI] = line;
                neighborNodeUI.lineToNeighbors[curNodeUI] = line;
            }
        }
    }

    public UI_SkillTreeEdge CreateLine(UI_SkillNode node1, UI_SkillNode node2, bool activeStatus)
    {
        UI_SkillTreeEdge line = Instantiate(lineRendererPrefab);
        line.SetupLine(node1.transform.position, node2.transform.position, activeStatus);
        line.transform.SetParent(lineParents);
        return line;
    }

    public void OpenSkillNodeUnlockWindow(SkillNode skillNode)
    {
        unlockWindow.SetupWindow(skillNode, baseData);
    }

    public void UnlockNode(SkillNode node)
    {
        Debug.Log("unlock");
        skillTree.Unlock(node);
        UI_SkillNode nodeUI = skillNodesUI[node];
        nodeUI.SetActivationUI();
        foreach(var kvp in nodeUI.lineToNeighbors)
        {
            Debug.Log(kvp.Key.skillNode.unlocked);
            kvp.Value.SetColor(kvp.Key.skillNode.unlocked);
        }
        skillPoint.text = skillTree.skillPoint.ToString();
    }
}