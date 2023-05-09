using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPlayer : HealthSystem
{
    private float hitTime;
    void OnEnable()
    {
        GetComponent<HealthSystem>().DMGCooldown += Cooldown;
    }
    void OnDisable()
    {
        GetComponent<HealthSystem>().DMGCooldown -= Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitTime > hit)
        {
            hit = hit + Time.deltaTime;
        }
        
    }

    public void Cooldown()
    {
#if __DEBUG_AVAILABLE__
        if (Switches.debugMode && Switches.debugCheatsMode)
        {
            cooldownReturn = true;
        }
#endif

        if (hitTime > hit)
        {
            cooldownReturn = true;
        }
        else
        {
            cooldownReturn = false;
            hit = Time.deltaTime;
            hitTime = Time.deltaTime + 1.5f;
        }
    }
}
