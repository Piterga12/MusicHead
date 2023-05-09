using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatGenerator : MonoBehaviour
{
    public string batNormal;
    public Transform[] positions;
    public float timeBat;

    void OnEnable()
    {
        startTrigger.startPhase1 += startPhase;
    }
    void OnDisable()
    {
        startTrigger.startPhase1 -= startPhase;
    }

    void startPhase(int k)
    {

        StartCoroutine(GenerateBat());
    }

    IEnumerator GenerateBat()
    {
        var pos = Random.Range(0, 4);

        GameObject o = PoolingManager.Instance.GetPooledObject(batNormal);

        o.SetActive(true);
        o.transform.position = positions[pos].position;

        yield return new WaitForSeconds(timeBat);
        StartCoroutine(GenerateBat());
    }
}
