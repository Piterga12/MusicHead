using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dash_Trail : MonoBehaviour
{
    private float timeEcho;
    public float startTimeEcho, cooldown;

    private bool trailActive = false;
    private GameObject o;

    public GameObject echo;

    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().OnDash += DashTrailTrue;
        GetComponent<PlayerDash>().EndDash += DashTrailFalse;
    }
    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().OnDash -= DashTrailTrue;
        GetComponent<PlayerDash>().EndDash -= DashTrailFalse;
    }


    void DashTrailTrue()
    {
        cooldown = GetComponent<PlayerDash>().dashCooldown;
        if (cooldown >= 3.8)
        {
            trailActive = true;
            cooldown++;
        }
    }

    void DashTrailFalse()
    {
        trailActive = false;
    }

    void Update()
    {
        if (trailActive)
        {
            if (timeEcho <= 0)
            {
                o = PoolingManager.Instance.GetPooledObject("Dash_Jump");

                o.SetActive(true);
                o.transform.position = transform.position;

                timeEcho = startTimeEcho;
            }
            else
            {
                timeEcho -= Time.deltaTime;
            }
            
        }
    }
}
