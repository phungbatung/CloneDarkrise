using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DashLineRenderer : MaskableGraphic
{
    [SerializeField] protected Transform point1;
    [SerializeField] protected Transform point2;
    [SerializeField] protected float lineWidth;
    [SerializeField] protected float dashLength = 10f;
    [SerializeField] protected float gapLength = 5f;
    [SerializeField] protected Color lineColor;

    [SerializeField] protected Color[] Colors;

    [SerializeField] protected UI_LineRenderer linePrefab;


    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
        DrawDashedLine(vh, point1.position, point2.position);
    }

    private void DrawDashedLine(VertexHelper vh, Vector2 start, Vector2 end)
    {
        Vector2 direction = (end - start).normalized;
        float totalLength = Vector2.Distance(start, end);
        float currentLength = 0f;
        int i = 0;
        while (currentLength < totalLength)
        {
            float segmentLength = Mathf.Min(dashLength, totalLength - currentLength);
            Vector2 segmentStart = start + direction * currentLength;
            Vector2 segmentEnd = segmentStart + direction * segmentLength;

            DrawSegment(vh, segmentStart, segmentEnd);

            int index = i * 4;

            vh.AddTriangle(index, index + 1, index + 2);
            vh.AddTriangle(index, index + 2, index +3);

            currentLength += dashLength + gapLength;
            i++;
        }
    }

    private void DrawSegment(VertexHelper vh, Vector2 _point1, Vector2 _point2)
    {
        Vector2 temp = _point2 - _point1;
        Vector2 pendicular = new Vector2(-temp.y, temp.x).normalized * (0.5f * lineWidth);

        Vector2 p1 = _point1 + pendicular;
        Vector2 p2 = _point1 - pendicular;
        Vector2 p3 = _point2 + pendicular;
        Vector2 p4 = _point2 - pendicular;

        vh.AddVert(p1, lineColor, new Vector2(0, 0));
        vh.AddVert(p2, lineColor, new Vector2(0, 1));
        vh.AddVert(p4, lineColor, new Vector2(1, 0));
        vh.AddVert(p3, lineColor, new Vector2(1, 1));

    }

    
}