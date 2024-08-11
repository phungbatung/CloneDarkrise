using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public bool isRightButtonPress {  get; private set; }
    public bool isLeftButtonPress { get; private set; }
    public float horizontalInput { get; private set; }

    public bool isUpButtonPress { get; private set; }
    public bool isDownButtonPress { get; private set; }
    public float verticalInput { get; private set; }

    public bool isBaseAttackPress { get; private set; }
    public bool isDashKeyPress { get; private set; }

    public bool isSkill1Press { get; private set; }
    public bool isSkill2Press { get; private set; }
    public bool isSkill3Press { get; private set; }
    public bool isSkill4Press { get; private set; }
    public bool isSkill5Press { get; private set; }
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
        isDownButtonPress = false;
        verticalInput = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInputCheck();
        VerticalInputCheck();
        SkillInputCheck();
    }

    private void HorizontalInputCheck()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isLeftButtonPress)
        {
            isLeftButtonPress = true;
            horizontalInput = -1f;
        }
        if (Input.GetKeyDown(KeyCode.D) && !isRightButtonPress)
        {
            isRightButtonPress = true;
            horizontalInput = 1f;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isLeftButtonPress = false;
            if(!isRightButtonPress)
                horizontalInput = 0f;
            else if(isRightButtonPress)
                horizontalInput = 1f;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isRightButtonPress = false;
            if (!isLeftButtonPress)
                horizontalInput = 0f;
            else if (isLeftButtonPress)
                horizontalInput = -1f;
        }
    }

    private void VerticalInputCheck()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            isUpButtonPress = true;
            verticalInput = 1f;
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space))
        {
            isUpButtonPress= false;
            verticalInput = 0f;
        }
    }

    private void SkillInputCheck()
    {
        isBaseAttackPress = Input.GetKey(KeyCode.Mouse0);
        isDashKeyPress = Input.GetKey(KeyCode.LeftShift);
        isSkill1Press = Input.GetKey(KeyCode.J);
        isSkill2Press = Input.GetKey(KeyCode.K);
        isSkill3Press = Input.GetKey(KeyCode.L);
        isSkill4Press = Input.GetKey(KeyCode.U);
    }
}
