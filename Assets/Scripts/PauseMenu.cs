using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject winMenuUI;

    void Update()
    {

        if (GameManager.gameFinished)
        {
            Time.timeScale = 0f;
            winMenuUI.SetActive(true);
            GameManager.gameFinished = false;
            gatheringArea.redGathered = 0;
            gatheringArea.blueGathered = 0;
            gatheringArea.yellowGathered = 0;


            SoundManager sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>();
            sm.PlayYouWin();

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GoMainMenu()
    {
        gatheringArea.redGathered = 0;
        gatheringArea.blueGathered = 0;
        gatheringArea.yellowGathered = 0;
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }

}
