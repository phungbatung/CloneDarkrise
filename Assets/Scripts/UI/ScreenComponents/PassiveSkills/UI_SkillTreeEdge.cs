using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillTreeEdge : UI_LineRenderer
{
    [SerializeField] private Color[] Colors;
    public void SetupLine(Vector2 startPoint, Vector2 endPoint, bool activeStatus)
    {
        point1 = startPoint;
        point2 = endPoint;
        SetColor(activeStatus);
    }    
    public void SetColor(bool activeStatus)
    {
        Debug.Log(activeStatus);
        lineColor = activeStatus ? Colors[1] : Colors[0];
        SetVerticesDirty();
    }
}
