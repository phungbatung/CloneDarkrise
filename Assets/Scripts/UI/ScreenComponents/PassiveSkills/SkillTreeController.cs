using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillTreeController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler
{
    [SerializeField] private RectTransform target;
    private bool _isDragging;
    private bool _isZooming;
    private float _currentScale;
    public float minScale;
    public float maxScale;
    private float _temp;
    private float _scalingRate = 2;

    private float maxSize = 4500;
    private float screenWidth;
    private float screenHeight;
    private void Awake()
    {
        
    }
    private void Start()
    {
        _currentScale = target.transform.localScale.x;
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        UI_Logger.instance.SetLog($"width: {screenWidth}, height: {screenHeight}");
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (Input.touchCount == 1)
        {
            _isDragging = true;
            _isZooming = false;
        }
        else if (Input.touchCount == 2)
        {
            _isDragging = false;
            _isZooming = true;
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        _isDragging = false;
        _isZooming = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
       if(_isDragging)
        {
            target.position += (Vector3)eventData.delta;
            FixPosition();
        }
    }

    private void Update()
    {
        if (_isZooming)
        {
            if (Input.touchCount == 2)
            {
                target.localScale = new Vector2(_currentScale, _currentScale);
                FixPosition();
                float distance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                if (_temp > distance)
                {
                    if (_currentScale < minScale)
                        return;
                    _currentScale -= (Time.deltaTime) * _scalingRate;
                }

                else if (_temp < distance)
                {
                    if (_currentScale >= maxScale)
                        return;
                    _currentScale += (Time.deltaTime) * _scalingRate;
                }

                _temp = distance;
            }


        }

    }

    private void FixPosition()
    {
        float curHalfWidth = maxSize*_currentScale;
        float curHalfHeight = maxSize*_currentScale;
        float xPos = Mathf.Clamp(target.position.x, screenWidth/2f - curHalfWidth, -screenWidth / 2f + curHalfWidth);
        float yPos = Mathf.Clamp(target.position.y, screenHeight/2f - curHalfHeight, -screenHeight / 2f + curHalfHeight);
        target.transform.position = new Vector2(xPos, yPos);
    }

    
}
