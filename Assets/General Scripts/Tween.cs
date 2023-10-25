using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public Transform Target { private set; get; }
    public Vector3 StartPos { private set; get; }
    public Vector3 EndPos { private set; get; }
    public float StartTime { private set; get; }
    public float Duration { private set; get; }
    // Start is called before the first frame update

    public Tween(Transform target, Vector3 origin, Vector3 destination, float startTime, float duration)
    {
        Target = target;
        StartPos = origin;
        EndPos = destination;
        StartTime = startTime;
        Duration = duration;
    }
}
