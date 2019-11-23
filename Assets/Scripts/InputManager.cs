using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    public static bool touchMove = false;
    public static bool redTrail = false;
    public static bool yellowTrail = false;
    public static bool blueTrail = false;
    public static InputManager instance;

    public static float verticalMove;
    public static float horizontalMove;

    public Button redButton;
    public Button yellowButton;
    public Button blueButton;

    public VariableJoystick variableJoystick;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    void Update()
    {

        touchMove = Input.GetMouseButton(0);
        /*
        redTrail = Input.GetKey(KeyCode.Alpha1);
        yellowTrail = Input.GetKey(KeyCode.Alpha2);
        blueTrail = Input.GetKey(KeyCode.Alpha3);*/

        verticalMove = variableJoystick.Vertical;
        horizontalMove = variableJoystick.Horizontal;

    }

    


}
