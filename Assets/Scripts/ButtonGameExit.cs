﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGameExit : MonoBehaviour
{
    public void doquit()
    {
        //Debug.Log("has quit game");
        Application.Quit();
    }
}
