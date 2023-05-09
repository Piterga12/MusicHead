using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batDestroyer : MonoBehaviour
{
    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        Vector3 normpos = Camera.main.WorldToViewportPoint(position);
        if (normpos.x < 0 || normpos.y > 1 || normpos.x > 2 || normpos.y < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
