using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBoss : HealthSystem
{
    public string particles;
    public Transform[] positions;
    public GameObject fadeBlack;

    public static event Action<int> startPhase = delegate { };
    public static event Action<int> endWin = delegate { };
    int phaseCounter = 1;
    int endGame=0;

    override public void HealthLose(int k)
    {
        //base.etc  Para llamar algo de la funcion orginal
        health = health - k;

        if (health <= 300 && phaseCounter==1)
        {
            startPhase(1);
            phaseCounter = 2;
        }
        if (health <= 0 && health >=-5)
        {
            StartCoroutine(GenerateExp());
            
        }
    }
    IEnumerator GenerateExp()
    {
        var pos = UnityEngine.Random.Range(0, 5);

        GameObject o = PoolingManager.Instance.GetPooledObject(particles);

        o.SetActive(true);
        o.transform.position = positions[pos].position;

        yield return new WaitForSeconds(0.5f);
        endGame++;

        if (endGame == 10)
        {
            fadeBlack.SetActive(true);
        }
        else if (endGame >= 20)
        {
            endWin(0);
        }
        
        StartCoroutine(GenerateExp());

    }

}
