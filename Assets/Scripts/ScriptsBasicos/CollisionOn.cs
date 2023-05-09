using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionOn : MonoBehaviour
{
    [SerializeField]
    private int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == Constants.layerShot || other.gameObject.layer  == Constants.layerShot2 || other.gameObject.layer == Constants.layerPlayer)
        {
            other.gameObject.GetComponent<HealthSystem>().HealthLose(damage);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == Constants.layerPlayer)
        {
            other.gameObject.GetComponent<HealthSystem>().HealthLose(damage);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        
        if(other.gameObject.layer == Constants.layerPlayer)
        {
            other.gameObject.GetComponent<HealthSystem>().HealthLose(damage);
        }
    }
}
