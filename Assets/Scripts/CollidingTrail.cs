using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrailType
{
    Red,
    Yellow,
    Blue
}


public class CollidingTrail : MonoBehaviour
{
    public float lifetime;
    public TrailType trailType;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
