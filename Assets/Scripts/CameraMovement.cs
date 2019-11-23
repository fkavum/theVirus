using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform playerPosition;
    public float moveSpeed = 1f;
    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if(playerPosition != null) { 
        Vector3 playerCoord = new Vector3(playerPosition.position.x, 31f, playerPosition.position.z-7f);
        transform.position = Vector3.Lerp(transform.position, playerCoord
            , Time.deltaTime * moveSpeed);
        }
    }
}
