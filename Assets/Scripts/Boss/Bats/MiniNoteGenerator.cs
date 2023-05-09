using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniNoteGenerator : MonoBehaviour
{
    public string[] attackType;
    public Transform[] positions;
    public float timeAttack;
    int pos;
    bool enable = false;

    void OnEnable()
    {
        if (enable)
        {
            StartCoroutine(GenerateAttack());
        }
    }

    void Start()
    {
        StartCoroutine(GenerateAttack());
        enable = true;
    }

    IEnumerator GenerateAttack()
    {
        var i = Random.Range(0, attackType.Length);
        pos = 1;

        GameObject o = PoolingManager.Instance.GetPooledObject(attackType[i]);

        
        o.SetActive(true);
        if (i == 0)
        {
            pos = 0;
            o.transform.SetParent(this.transform);
        }
        o.transform.position = positions[pos].position;

        yield return new WaitForSeconds(timeAttack);
        if (i == 0)
        {
            o.transform.SetParent(null);
        }
        StartCoroutine(GenerateAttack());
    }
}
