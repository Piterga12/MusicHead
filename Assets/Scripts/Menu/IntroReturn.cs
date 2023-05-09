using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroReturn : MonoBehaviour
{
    public GameObject Menu, Intro;
    float timer;

    void Start()
    {
        timer = 30;
    }
    void Update()
    {
        if (timer<=0)
        {
            Menu.SetActive(false);
            Intro.SetActive(true);
            timer = 30;
        }
        timer = timer - Time.deltaTime;
    }
}
