using UnityEngine;
using UnityEngine.EventSystems;

public class UI_DragAndZoom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform target;
    private bool isDragging;
    private bool isZooming;

    private float currentScale;
    public float minScale;
    public float maxScale;

    private float maxSize = 4500;
    private float screenWidth;
    private float screenHeight;

    private float originTouchDistance;
    private void Start()
    {
        currentScale = target.transform.localScale.x;
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        Debug.Log($"width: {screenWidth}, height: {screenHeight}");
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (Input.touchCount == 1)
        {
            isDragging = true;
            isZooming = false;
            Debug.Log("pointer");
            UI_Logger.instance.SetLog($"Touch count: {Input.touchCount}, Drag: {isDragging}, Zoom: {isZooming}");
        }
        else if (Input.touchCount == 2)
        {
            isDragging = false;
            isZooming = true;

            originTouchDistance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
            UI_Logger.instance.SetLog($"Touch count: {Input.touchCount}, Drag: {isDragging}, Zoom: {isZooming}");
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        UI_Logger.instance.SetLog($"Touch count: {Input.touchCount}, Drag: {isDragging}, Zoom: {isZooming}");
        isDragging = false;
        isZooming = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
        if (isDragging)
        {
            target.anchoredPosition += eventData.delta;
            ClampPosition();
        }
    }

    private void Update()
    {
        if (isZooming && Input.touchCount==2)
        {
            float currentTouchDistance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
            Vector2 midPoint = (Input.GetTouch(0).position + Input.GetTouch(1).position) / 2;

            float scaleFactor = currentTouchDistance / originTouchDistance;
            if ((scaleFactor >= 1 && currentScale >= maxScale) || (scaleFactor <= 1 && currentScale <= minScale))
                return;
            currentScale = currentScale * scaleFactor;
            currentScale = Mathf.Clamp(currentScale, minScale, maxScale);
            target.localScale = new Vector2(currentScale, currentScale);

            target.position = (Vector3)midPoint - scaleFactor * ((Vector3)midPoint-target.position);
            ClampPosition();

            originTouchDistance = currentTouchDistance;

        }

    }

    private void ClampPosition()
    {
        float curHalfWidth = maxSize * currentScale;
        float curHalfHeight = maxSize * currentScale;

        float xPos = Mathf.Clamp(target.anchoredPosition.x, screenWidth / 2f - curHalfWidth, -screenWidth / 2f + curHalfWidth);
        float yPos = Mathf.Clamp(target.anchoredPosition.y, screenHeight / 2f - curHalfHeight, -screenHeight / 2f + curHalfHeight);

        target.anchoredPosition = new Vector2(xPos, yPos);
    }


}
