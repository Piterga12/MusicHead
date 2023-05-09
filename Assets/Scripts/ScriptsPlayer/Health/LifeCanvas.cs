using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LifeCanvas : MonoBehaviour
{

    public static event Action<int> loseHealth = delegate { };
    public static event Action<int> lifeInitial = delegate { };

    void Awake()
    {
        lifeUpdate(0);
    }

    void OnEnable()
    {
        GetComponent<HealthSystem>().changeLife += lifeUpdate;
    }
    void OnDisable()
    {
        GetComponent<HealthSystem>().changeLife -= lifeUpdate;
    }

    public void lifeUpdate(int k)
    {
        loseHealth(k);
    }
   
}
