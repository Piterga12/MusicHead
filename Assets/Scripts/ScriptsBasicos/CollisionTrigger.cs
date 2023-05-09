using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionTrigger : MonoBehaviour
{

    [SerializeField]
    private int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RedTube")
        {
            gameObject.GetComponent<HealthSystem>().HealthLose(damage);
        }
        else
        {
            other.gameObject.GetComponent<HealthSystem>().HealthLose(damage);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        other.gameObject.GetComponent<HealthSystem>().HealthLose(damage);
    }
}
