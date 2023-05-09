using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<HealthSystem>().Death += Destroy;
    }
    void OnDisable()
    {
        GetComponent<HealthSystem>().Death -= Destroy;
    }

    virtual public void Destroy()
    {
        /*var e = Instantiate(explosion, transform.position, Quaternion.identity);
        //Destroy(gameObject);
        Destroy(e, 0.5f);*/
        gameObject.SetActive(false);
    }
}
