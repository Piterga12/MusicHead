using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTubeCollision : MonoBehaviour
{
    [SerializeField]
    private int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "RedTube" && other.gameObject.tag != "BlueTube")
        {
            other.gameObject.GetComponent<HealthSystem>().HealthLose(damage);
        }
        
    }
}
