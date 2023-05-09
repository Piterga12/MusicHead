using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batShock : MonoBehaviour
{
    float timer = 2;

    private void Update()
    {
        if (timer <= 0)
        {
            this.gameObject.SetActive(false);
            timer = 2;
        }
        else
        {
            timer = timer - Time.deltaTime;
        }
    }
}
