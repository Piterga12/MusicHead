using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGenerator : MonoBehaviour
{
    public string[] musicNote;
    public Transform[] positions;
    public float timeNote;

    void OnEnable()
    {
        startTrigger.startPhase1 += startPhase;
        HealthBoss.startPhase += startPhase;
    }
    void OnDisable()
    {
        startTrigger.startPhase1 -= startPhase;
        HealthBoss.startPhase -= startPhase;
    }

    void startPhase(int k)
    {
        StartCoroutine(GenerateMusic(k));
    }

    IEnumerator GenerateMusic(int k)
    {
        var pos = Random.Range(0, 6);

        var i = Random.Range(0, 5);//musicNote.Length);

        GameObject o = PoolingManager.Instance.GetPooledObject(musicNote[i]);

        o.SetActive(true);
        o.transform.position = positions[pos].position;
        //var type = Random.Range(0, 2);
        //meteor = meteors[type];
        yield return new WaitForSeconds(timeNote);
        if(k == 1)
        {
            StartCoroutine(GenerateMusic2(k));
            k++;
        }
        
        StartCoroutine(GenerateMusic(k));
        
        
    }

    IEnumerator GenerateMusic2(int k)
    {
        Debug.Log("pto");
        var pos = Random.Range(3, 6);

        var i = Random.Range(6, musicNote.Length);

        GameObject o = PoolingManager.Instance.GetPooledObject(musicNote[i]);

        o.SetActive(true);
        o.transform.position = positions[pos].position;

        //var type = Random.Range(0, 2);
        //meteor = meteors[type];
        yield return new WaitForSeconds(timeNote+5);

        StartCoroutine(GenerateMusic2(k));


    }
}
