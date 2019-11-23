using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusRotation : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

    }
}
