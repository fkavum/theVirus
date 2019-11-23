using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void openOptions()
    {
        optionsMenu.SetActive(true);
    }
    public void closeOptions()
    {
        optionsMenu.SetActive(false);
    }
    public void closeProgram()
    {
        Application.Quit();
    }

    public void Start()
    {
        SoundManager sm = gameObject.GetComponent<SoundManager>();
        sm.PlayMenuTheme();
    }
}
