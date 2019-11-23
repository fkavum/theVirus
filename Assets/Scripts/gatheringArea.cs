using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatheringArea : MonoBehaviour
{
    public TextMesh textMesh;
    public TrailType gatheringColor;

    public GameObject redBar;
    public GameObject yellowBar;
    public GameObject blueBar;

    public static int redGathered = 0;
    public static int yellowGathered = 0;
    public static int blueGathered = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player =  other.gameObject.GetComponent<Player>();

            tookHimDown(player);

            SoundManager sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>();
            sm.PlayDeepT();

            GameManager.isGameFinished();

        }
    }

    private void gainSpeed(int speed, Player player)
    {
        PlayerMovement pm = player.gameObject.GetComponent<PlayerMovement>();
        float speedToGain = (float)speed * 0.2f;
        pm.speed += speedToGain;
    }

    private void pushRedBar()
    {
        RectTransform rt = redBar.GetComponent<RectTransform>();
        float gmRatio = (float)redGathered / (float)GameManager.maxRedVirus;

        if (gmRatio == 0f)
        {
            rt.localPosition = new Vector3(-4f, 0f,0.1f);
        }
        else if (gmRatio >= 1f)
        {
          
            rt.localPosition = new Vector3(0f, 0f, 0.1f);
        }
        else
        {
            
            float move = -4f + 4f * (gmRatio);
           
            rt.localPosition = new Vector3(move, 0f, 0.1f);
        }

    }

    private void pushBlueBar()
    {
        RectTransform rt = blueBar.GetComponent<RectTransform>();

        float gmRatio = (float)blueGathered / (float)GameManager.maxBlueVirus;
        if (gmRatio == 0f)
        {
            rt.localPosition = new Vector3(-4f, 0f, 0.1f);
        }
        else if (gmRatio >= 1f)
        {
            
            rt.localPosition = new Vector3(0f, 0f, 0.1f);
        }
        else
        {
            float move = -4f + 4f * (gmRatio);
            
            rt.localPosition = new Vector3(move, 0f, 0.1f);
        }

    }

    private void pushYellowBar()
    {
        RectTransform rt = yellowBar.GetComponent<RectTransform>();

        float gmRatio = (float)yellowGathered / (float)GameManager.maxYellowVirus;

        if (gmRatio == 0f)
        {
            rt.localPosition = new Vector3(-4f, 0f, 0.1f);
        }
        else if (gmRatio >= 1f)
        {
          
            rt.localPosition = new Vector3(0f, 0f, 0.1f);
        }
        else
        {
            float move = -4f + 4f * (gmRatio);
            rt.localPosition = new Vector3(move, 0f, 0.1f);
        }

    }

    private void tookHimDown(Player player)
    {

        switch (gatheringColor)
        {
            case TrailType.Red:
                redGathered += player.redCounter;
                gainSpeed(player.redCounter, player);
                player.redCounter = 0;
                player.updateTxtCounters();
                textMesh.text = redGathered.ToString();
                pushRedBar();
                break;
            case TrailType.Yellow:
                yellowGathered += player.yellowCounter;
                gainSpeed(player.yellowCounter, player);
                player.yellowCounter = 0;
                player.updateTxtCounters();
                textMesh.text = yellowGathered.ToString();
                pushYellowBar();
                break;
            case TrailType.Blue:
                blueGathered += player.blueCounter;
                gainSpeed(player.blueCounter, player);
                player.blueCounter = 0;
                player.updateTxtCounters();
                textMesh.text = blueGathered.ToString();
                pushBlueBar();
                break;
        }


    }
}
