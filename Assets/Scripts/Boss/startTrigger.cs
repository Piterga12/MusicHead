using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class startTrigger : MonoBehaviour
{
    public static event Action<int> startPhase1 = delegate { };

    void OnTriggerEnter2D(Collider2D other)
    {
        startPhase1(0);
    }
}
