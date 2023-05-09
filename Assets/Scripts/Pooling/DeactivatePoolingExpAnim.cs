using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePoolingExpAnim : MonoBehaviour
{
    private float expTime, expTimeEnd;
    void Start()
    {
        expTime = Time.deltaTime;
        expTimeEnd = Time.deltaTime + 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (expTimeEnd > expTime)
        {
            expTime = expTime + Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
            expTime = Time.deltaTime;
            expTimeEnd = Time.deltaTime + 0.2f;
        }
    }
}
