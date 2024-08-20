using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public bool isRightButtonPress { get; set; }
    public bool isLeftButtonPress { get; set; }
    public float horizontalInput { get; set; }

    public bool isUpButtonPress { get; set; }
    public float verticalInput { get; set; }

    public bool isBaseAttackPress { get; set; }
    public bool isDashKeyPress { get; set; }

    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        isRightButtonPress = false;
        isLeftButtonPress = false;
        horizontalInput = 0f;

        isUpButtonPress = false;
        verticalInput = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        InputCheck();
        HorizontalInputCheck();
        VerticalInputCheck();
        SkillInputCheck();
    }

    private void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.A))
            isLeftButtonPress = true;
        if (Input.GetKeyUp(KeyCode.A))
            isLeftButtonPress = false;
        if (Input.GetKeyDown(KeyCode.D))
            isRightButtonPress = true;
        if (Input.GetKeyUp(KeyCode.D))
            isRightButtonPress = false;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            isUpButtonPress = true;
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space))
            isUpButtonPress = false;

    }
    private void HorizontalInputCheck()
    {
        if (!isLeftButtonPress && !isRightButtonPress)
            horizontalInput = 0f;
        else if (isLeftButtonPress && !isRightButtonPress)
            horizontalInput = -1f;
        else if (!isLeftButtonPress && isRightButtonPress)
            horizontalInput = 1f;
    }

    private void VerticalInputCheck()
    {
        verticalInput = isUpButtonPress ? 1 : 0;
    }

    private void SkillInputCheck()
    {
        
    }
}
