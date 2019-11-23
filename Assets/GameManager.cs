using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int maxRedVirus = 1;
    public static int maxYellowVirus = 1;
    public static int maxBlueVirus = 1;
    public static bool gameFinished = false;

    public static void isGameFinished()
    {
        if(gatheringArea.redGathered >= maxRedVirus && 
            gatheringArea.yellowGathered >= maxYellowVirus && 
            gatheringArea.blueGathered >= maxBlueVirus)
        {
            
            gameFinished = true;
        }

    }

    public void Awake()
    {
        SoundManager sm = gameObject.GetComponent<SoundManager>();
        sm.PlayBackGround();

    }



}
