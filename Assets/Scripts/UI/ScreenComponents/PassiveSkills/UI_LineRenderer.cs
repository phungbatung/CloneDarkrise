using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class UI_LineRenderer : MaskableGraphic
{
    [SerializeField] protected Vector2 point1;
    [SerializeField] protected Vector2 point2;
    [SerializeField] protected float lineWidth;
    [SerializeField] protected Color lineColor;
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
        Vector2 temp = point2 - point1;
        Vector2 pendicular = new Vector2(-temp.y, temp.x).normalized*(0.5f*lineWidth);

        Vector2 p1 = point1 + pendicular;
        Vector2 p2 = point1 - pendicular;
        Vector2 p3 = point2 + pendicular;
        Vector2 p4 = point2 - pendicular;

        vh.AddVert(p1, lineColor, new Vector2(0, 0));
        vh.AddVert(p2, lineColor, new Vector2(0, 1));
        vh.AddVert(p4, lineColor, new Vector2(1, 0));
        vh.AddVert(p3, lineColor, new Vector2(1, 1));

        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(0, 2, 3);
    }

    public void SetupLine(Vector2 startPoint, Vector2 endPoint, float _lineWidth, Color _lineColor)
    {
        point1 = startPoint;
        point2 = endPoint;
        lineWidth = _lineWidth;
        lineColor = _lineColor;
        SetVerticesDirty();
    }
}
