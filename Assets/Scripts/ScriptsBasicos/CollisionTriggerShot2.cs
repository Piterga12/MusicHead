using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionTriggerShot2 : MonoBehaviour
{

    [SerializeField]
    private int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "BlueTube")
        {
            gameObject.GetComponent<HealthSystem>().HealthLose(damage);
        }
        else
        {
            other.gameObject.GetComponent<HealthSystem>().HealthLose(damage);
        }
    }
    
}
