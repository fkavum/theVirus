using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text redCounterTxt;
    public Text yellowCounterTxt;
    public Text blueCounterTxt;

    public int redCounter = 0;
    public int yellowCounter = 0;
    public int blueCounter = 0;

    public GameObject FailUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            FailUI.SetActive(true);
            SoundManager sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>();
            sm.PlayYouLoose();


        }

        if (other.CompareTag("Virus"))
        {
            SoundManager sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>();
            sm.PlayVirusObtained();
            getVirus(other);
            slowPlayer();
            Destroy(other.gameObject);
        }
    }

    private void slowPlayer()
    {
        PlayerMovement pm = transform.gameObject.GetComponent<PlayerMovement>();
        pm.speed -= 0.2f;
    }
    private void getVirus(Collider other)
    {
        VirusColor virusColor = other.GetComponent<Virus>().virusColor;

        switch (virusColor)
        {
            case VirusColor.Red:
                redCounter++;
                break;
            case VirusColor.Blue:
                blueCounter++;
                break;
            case VirusColor.Yellow:
                yellowCounter++;
                break;

        }
        updateTxtCounters();
    }


    public void updateTxtCounters()
    {
        redCounterTxt.text = redCounter.ToString();
        yellowCounterTxt.text = yellowCounter.ToString();
        blueCounterTxt.text = blueCounter.ToString();
    }


}
