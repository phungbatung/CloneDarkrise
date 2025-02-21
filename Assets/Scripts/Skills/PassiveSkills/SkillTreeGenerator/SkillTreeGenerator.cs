using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR;


public class SkillTreeGenerator : MonoBehaviour
{
    [Header("Generate node between 2 node")]
    public Transform rootPos;
    public Transform desPos;
    public int amountOfNodesBetweenTwoNodes;
    public SkillNodeTemplate nodeToSpawn;
    public SkillNodeTemplate.SymmetricalType type;
    [Header("Base data")]
    public SkillTreeBaseData data;
    [Header("Export info")]
    public List<SkillNodeTemplate> resultListNode;
    public string fileName;
    [Header("List nodes")]
    public List<SkillNodeTemplate> listNodes;


    [ContextMenu("GetRootListNode")]
    public void GetRootListNode()
    {
        listNodes = GetComponentsInChildren<SkillNodeTemplate>().ToList();
    }
    [ContextMenu("GetListNode")]
    public void GetListNode()
    {
        listNodes = GetComponentsInChildren<SkillNodeTemplate>().ToList();
        ClearCloneNode();
        for(int i = 0; i < listNodes.Count; i++)
        {
            SkillNodeTemplate curNode = listNodes[i];
            if (!curNode.isCloned && curNode.symmetricalType == SkillNodeTemplate.SymmetricalType.X)
            {
                SkillNodeTemplate newNode = Instantiate(curNode);
                listNodes.Add(newNode);
                newNode.isCloned = true;
                newNode.transform.SetParent(transform);
                newNode.neighbors.Clear();
                newNode.transform.position = curNode.transform.position + 2 * new Vector3(transform.position.x - curNode.transform.position.x, 0, 0);
            }

            else if (!curNode.isCloned && curNode.symmetricalType == SkillNodeTemplate.SymmetricalType.Y)
            {
                SkillNodeTemplate newNode = Instantiate(curNode);
                listNodes.Add(newNode);
                newNode.isCloned = true;
                newNode.transform.SetParent(transform);
                newNode.neighbors.Clear();
                newNode.transform.position = curNode.transform.position + 2 * new Vector3(0, transform.position.y - curNode.transform.position.y, 0);
            }
            else if (!curNode.isCloned && curNode.symmetricalType == SkillNodeTemplate.SymmetricalType.Both)
            {
                SkillNodeTemplate newNode = Instantiate(curNode);
                listNodes.Add(newNode);
                newNode.isCloned = true;
                newNode.transform.SetParent(transform);
                newNode.neighbors.Clear();
                newNode.transform.position = curNode.transform.position + 2 * new Vector3(transform.position.x - curNode.transform.position.x, transform.position.y - curNode.transform.position.y, 0);
            }
            else if (!curNode.isCloned && curNode.symmetricalType == SkillNodeTemplate.SymmetricalType.Quad)
            {
                SkillNodeTemplate newNode = Instantiate(curNode);
                listNodes.Add(newNode);
                newNode.isCloned = true;
                newNode.transform.SetParent(transform);
                newNode.neighbors.Clear();
                newNode.transform.position = curNode.transform.position + 2 * new Vector3(transform.position.x - curNode.transform.position.x, transform.position.y - curNode.transform.position.y, 0);
                newNode = Instantiate(curNode);
                listNodes.Add(newNode);
                newNode.isCloned = true;
                newNode.transform.SetParent(transform);
                newNode.neighbors.Clear();
                newNode.transform.position = curNode.transform.position + 2 * new Vector3(0, transform.position.y - curNode.transform.position.y, 0);
                newNode = Instantiate(curNode);
                listNodes.Add(newNode);
                newNode.isCloned = true;
                newNode.transform.SetParent(transform);
                newNode.neighbors.Clear();
                newNode.transform.position = curNode.transform.position + 2 * new Vector3(transform.position.x - curNode.transform.position.x, 0, 0);
            }

        }
    }
    [ContextMenu("GetListNode2")]
    public void GetListNode2() 
    {
        Debug.Log("start");
        listNodes = GetComponentsInChildren<SkillNodeTemplate>().ToList();
        int[] count=new int[5];
        foreach(SkillNodeTemplate node in listNodes)
        {
            if(node.symmetricalType==SkillNodeTemplate.SymmetricalType.None)
            {
                count[1]++;
            }
            else if (node.symmetricalType == SkillNodeTemplate.SymmetricalType.Quad)
            {
                count[4]++;
            }
            else
            {
                count[2]++;
            }
        }
        Debug.Log($"1:{count[1]}, 2:{count[2]}, 4:{count[4]} ");
        Debug.Log($"total: {count[1] + count[2]*2 + count[4]*4 }");
        List<SkillNodeTemplate> list = new()
        {
            listNodes[0]
        };
        DeepGenerate(listNodes[0], GetListPeerNode(listNodes[0]), list);
        listNodes = GetComponentsInChildren<SkillNodeTemplate>().ToList();
    }
    public SkillNodeTemplate GenerateSymmetricalX(SkillNodeTemplate rootNode)
    {
        SkillNodeTemplate newNode = Instantiate(rootNode);
        //listNodes.Add(newNode);
        newNode.isCloned = true;
        newNode.transform.SetParent(transform);
        newNode.neighbors.Clear();
        newNode.transform.position = rootNode.transform.position + 2 * new Vector3(transform.position.x - rootNode.transform.position.x, 0, 0);
        return newNode;
    }
    public SkillNodeTemplate GenerateSymmetricalY(SkillNodeTemplate rootNode)
    {
        SkillNodeTemplate newNode = Instantiate(rootNode);
        //listNodes.Add(newNode);
        newNode.isCloned = true;
        newNode.transform.SetParent(transform);
        newNode.neighbors.Clear();
        newNode.transform.position = rootNode.transform.position + 2 * new Vector3(0, transform.position.y - rootNode.transform.position.y, 0);
        return newNode;
    }
    public SkillNodeTemplate GenerateSymmetricalBothXY(SkillNodeTemplate rootNode)
    {
        SkillNodeTemplate newNode = Instantiate(rootNode);
        //listNodes.Add(newNode);
        newNode.isCloned = true;
        newNode.transform.SetParent(transform);
        newNode.neighbors.Clear();
        newNode.transform.position = rootNode.transform.position + 2 * new Vector3(transform.position.x - rootNode.transform.position.x, transform.position.y - rootNode.transform.position.y, 0);
        return newNode;
    }
    public List<SkillNodeTemplate> GenerateSymmetricalQuad(SkillNodeTemplate rootNode)
    {
        List<SkillNodeTemplate> res = new()
        {
            GenerateSymmetricalX(rootNode),
            GenerateSymmetricalY(rootNode),
            GenerateSymmetricalBothXY(rootNode)
        };
        return res;
    }
    public List<SkillNodeTemplate> GetListPeerNode(SkillNodeTemplate node)
    {
        if(node.symmetricalType == SkillNodeTemplate.SymmetricalType.X)
        {
            return new List<SkillNodeTemplate> { GenerateSymmetricalX(node) };
        }
        else if (node.symmetricalType == SkillNodeTemplate.SymmetricalType.Y)
        {
            return new List<SkillNodeTemplate> { GenerateSymmetricalY(node) };
        }
        else if (node.symmetricalType == SkillNodeTemplate.SymmetricalType.Both)
        {
            return new List<SkillNodeTemplate> { GenerateSymmetricalBothXY(node) };
        }
        else if (node.symmetricalType == SkillNodeTemplate.SymmetricalType.Quad)
        {
            return GenerateSymmetricalQuad(node);
        }
        return new List<SkillNodeTemplate>();
    }    

    [ContextMenu("ClearCloneNode")]
    public void ClearCloneNode()
    {
        for ( int i=0; i< listNodes.Count; i++)
        {
            SkillNodeTemplate node = listNodes[i];
            if (node.isCloned)
            {
                listNodes.Remove(node);
                DestroyImmediate(node.gameObject);
                i--;
            }
        }
    }    

    [ContextMenu("GenerateNode")]
    public void GenerateNode()
    {
        Vector3 dir=(desPos.position-rootPos.position).normalized;
        float distanceBetweenTwoNodes = Vector3.Distance(desPos.position, rootPos.position)/(amountOfNodesBetweenTwoNodes+1);
        for(int i=1; i <=amountOfNodesBetweenTwoNodes; i++)
        {
            SkillNodeTemplate newNode = Instantiate(nodeToSpawn);
            newNode.isCloned = false;
            newNode.transform.SetParent(transform);
            newNode.symmetricalType = type;
            newNode.transform.position = rootPos.position + i*distanceBetweenTwoNodes * dir;
        }    
    }

    public void DeepGenerate(SkillNodeTemplate node, List<SkillNodeTemplate> peerNodes, List<SkillNodeTemplate> list)
    {
        Debug.Log("log count");
        int amountOfNeighbor = node.neighbors.Count;
        for (int i=0; i<amountOfNeighbor; i++)
        {
            SkillNodeTemplate neighbor = node.neighbors[i];
            if (list.Contains(neighbor) || !listNodes.Contains(neighbor))
            {
                continue;
            }
            List<SkillNodeTemplate> peerNeighborNodes = GetListPeerNode(neighbor);
            if(node.symmetricalType==SkillNodeTemplate.SymmetricalType.None)
            {
                foreach(var _node in peerNeighborNodes)
                {
                    node.neighbors.Add(_node);
                }
            }
            else if (node.symmetricalType == SkillNodeTemplate.SymmetricalType.Quad)
            {
                if (neighbor.symmetricalType == SkillNodeTemplate.SymmetricalType.Quad)
                {
                    for (int j = 0; j < peerNeighborNodes.Count; j++)
                    {
                        peerNodes[j].neighbors.Add(peerNeighborNodes[j]);
                    }
                }
                else if (neighbor.symmetricalType == SkillNodeTemplate.SymmetricalType.Y)
                {
                    peerNodes[0].neighbors.Add(neighbor);
                    peerNodes[1].neighbors.Add(peerNeighborNodes[0]);
                    peerNodes[2].neighbors.Add(peerNeighborNodes[0]);
                }
                else if (neighbor.symmetricalType == SkillNodeTemplate.SymmetricalType.X)
                {
                    peerNodes[1].neighbors.Add(neighbor);
                    peerNodes[0].neighbors.Add(peerNeighborNodes[0]);
                    peerNodes[2].neighbors.Add(peerNeighborNodes[0]);
                }
            }
            else
            {
                if(peerNeighborNodes.Count==1)
                {
                    peerNodes[0].neighbors.Add(peerNeighborNodes[0]);
                }
                else if(peerNeighborNodes.Count==3)
                {
                    if (node.symmetricalType == SkillNodeTemplate.SymmetricalType.X)
                    {
                        node.neighbors.Add(peerNeighborNodes[1]);
                        peerNodes[0].neighbors.Add(peerNeighborNodes[0]);
                        peerNodes[0].neighbors.Add(peerNeighborNodes[2]);
                    }
                    else if (node.symmetricalType == SkillNodeTemplate.SymmetricalType.Y)
                    {
                        node.neighbors.Add(peerNeighborNodes[0]);
                        peerNodes[0].neighbors.Add(peerNeighborNodes[1]);
                        peerNodes[0].neighbors.Add(peerNeighborNodes[2]);
                    }
                }
            }
            DeepGenerate(neighbor, peerNeighborNodes, list);
            list.Add(neighbor);
        }
    }

    [ContextMenu("AllocateId")]
    public void AllocateId()
    {
        listNodes = GetComponentsInChildren<SkillNodeTemplate>().ToList();
        SkillNodeTemplate firstNode = listNodes[0];
        Queue<SkillNodeTemplate> queue= new Queue<SkillNodeTemplate>();
        resultListNode = new();
        queue.Enqueue(firstNode);
        int id = 0;
        while(queue.Count>0)
        {
            SkillNodeTemplate node = queue.Dequeue();
            if(resultListNode.Contains(node))
            {
                continue;
            }
            else
            {
                resultListNode.Add(node);
            }
            Debug.Log(id);
            node.id = id;
            id++;
            foreach(var _node in node.neighbors)
            {
                queue.Enqueue(_node);
            }
        }
    }    
    [ContextMenu("ExportData")]    
    
    public void ExportData()
    {
        AllocateId();
        Debug.Log("Start export");
        SkillTree skillTree = new SkillTree();
        string dirPath = Path.Combine(Application.dataPath, "Resources/SkillTreeData");
        FileDataHandler dataHandler = new FileDataHandler(dirPath, fileName);
        for(int i=0; i<resultListNode.Count; i++)
        {
            SkillNodeTemplate node = resultListNode[i];
            if (node.id != i)
            {
                Debug.Log("khasc id me roi, fix bug di");
            }

            skillTree.skillNodes.Add(node.GetNode(data));
        }

        foreach(var node in skillTree.skillNodes)
        {
            List<SkillNode> neighbors = skillTree.GetNeighborsOf(node);
            foreach(var neighbor in neighbors)
            {
                
                if(!neighbor.neighbors.Contains(node.id))
                {
                    neighbor.neighbors.Add(node.id);
                    neighbor.neighbors.Sort();
                }
            }
        }
        Debug.Log(skillTree);
        dataHandler.Save(skillTree);
        Debug.Log("Done!");
    }
    [ContextMenu("ImportData")]    
    public void ImportData()
    {
        string dirPath = Path.Combine(Application.dataPath, "Resources/SkillTreeData");
        FileDataHandler dataHandler = new FileDataHandler(dirPath, fileName);
        SkillTree skilltree = dataHandler.Load<SkillTree>();
        listNodes = new();
        for (int i = 0; i < skilltree.skillNodes.Count; i++)
        {
            SkillNode node = skilltree.skillNodes[i];
            CreateNode(node);
        }
        for (int i = 0; i < skilltree.skillNodes.Count; i++)
        {
            foreach (var temp in skilltree.skillNodes[i].neighbors)
            {
                listNodes[i].neighbors.Add(listNodes[temp]);
            }
            
        }
    }
    public void CreateNode(SkillNode skillNode)
    {
        SkillNodeTemplate node = Instantiate(nodeToSpawn);
        listNodes.Add(node);
        node.transform.SetParent(transform);
        node.id = skillNode.id;
        node.transform.position = skillNode.position;
    }
    private void OnDrawGizmos()
    {
        foreach (var node in listNodes)
        {
            foreach (var neighbor in node.neighbors)
            {
                Gizmos.DrawLine(node.transform.position, neighbor.transform.position);
            }
        }
    }


}
