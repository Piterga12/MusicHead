using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePoolingShots : Destroyer
{
    private Transform _gb;
    public string exp;

    private void Start()
    {
        _gb = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        Vector3 normpos = Camera.main.WorldToViewportPoint(position);
        if (normpos.x < 0 || normpos.y > 1 || normpos.x > 1 || normpos.y < 0)
        {
            gameObject.SetActive(false);
        }
    }

    override public void Destroy()
    {
        GameObject shot_exp = PoolingManager.Instance.GetPooledObject(exp);
        shot_exp.transform.position = _gb.position;
        shot_exp.transform.rotation = _gb.rotation;
        shot_exp.SetActive(true);
        gameObject.SetActive(false);
    }
}
