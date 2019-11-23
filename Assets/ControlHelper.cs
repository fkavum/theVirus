using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHelper : MonoBehaviour
{
    public void RedButtonDown()
    {
        InputManager.redTrail = true;
    }

    public void RedButtonUp()
    {
        InputManager.redTrail = false;
    }

    public void YellowButtonUp()
    {
        InputManager.yellowTrail = false;
    }
    public void YellowButtonDown()
    {
        InputManager.yellowTrail = true;
    }

    public void BlueButtonUp()
    {
        InputManager.blueTrail = false;
    }
    public void BlueButtonDown()
    {
        InputManager.blueTrail = true;
    }
}
