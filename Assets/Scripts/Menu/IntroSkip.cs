using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSkip : MonoBehaviour
{
    public GameObject Menu, Intro;


    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Menu.SetActive(true);
            Intro.SetActive(false);
        }
    }
}
