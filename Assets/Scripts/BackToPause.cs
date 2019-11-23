using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToPause : MonoBehaviour
{
    public GameObject OptionsMenu;
    
    public void closeOptions()
    {
        OptionsMenu.SetActive(false);

    }
    
}
