using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    public int health, maxHealth;

    public float hit = 0;
    public bool cooldownReturn;

    public event Action Death = delegate { };
    public event Action DMGReceiver = delegate { };
    public event Action DMGCooldown = delegate { };
    public event Action<int> changeLife = delegate { };
    public event Action<int> currentLife = delegate { };

    void OnEnable()
    {
        health = maxHealth;
    }
    private void Start()
    {
        health = maxHealth;
        changeLife(maxHealth);
        cooldownReturn = false;
    }


    virtual public void HealthLose(int k)
    {
        DMGCooldown();
        if (!cooldownReturn)
        {
            health = health - k;
            changeLife(health);

            DMGReceiver();
        }

        if (health <= 0)
        {
            Death();
        }
    }

    //Sends current health as int
    public int PublicHealth()
    {
        return health;
    }


}
