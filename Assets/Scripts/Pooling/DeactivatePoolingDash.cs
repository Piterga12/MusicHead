using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePoolingDash : MonoBehaviour
{
    private float dashTime, dashTimeEnd;
    void Start()
    {
        dashTime = Time.deltaTime;
        dashTimeEnd = Time.deltaTime + 0.2f;
    }

    // Update is called once per frame
    void Update()
    {

        if (dashTimeEnd > dashTime)
        {
            dashTime = dashTime + Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
            dashTime = Time.deltaTime;
            dashTimeEnd = Time.deltaTime + 0.2f;
        }
    }
}
