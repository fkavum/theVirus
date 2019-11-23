using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour
{
    public void StartGameAgain()
    {
        gatheringArea.redGathered = 0;
        gatheringArea.blueGathered = 0;
        gatheringArea.yellowGathered = 0;
        SceneManager.LoadScene("TutorialScene", LoadSceneMode.Single);
    }
}
