using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    [SerializeField]
    private int damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == Constants.layerNotes)
        {
            other.gameObject.GetComponent<HealthSystem>().HealthLose(damage);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.layer == Constants.layerNotes)
        {
            other.gameObject.GetComponent<HealthSystem>().HealthLose(damage);
        }
        if(other.gameObject.tag == "WhiteAir")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+0.2f, transform.position.z);
        }
    }
}
