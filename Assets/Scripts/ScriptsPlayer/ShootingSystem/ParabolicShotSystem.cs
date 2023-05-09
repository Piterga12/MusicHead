using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicShotSystem : ShootingSystem
{
    int i;

    void Start()
    {
        _anim = player.GetComponent<Animator>();
    }

    public override void Shot()
    {
        if (player.transform.localScale.x > 0)
        {
            i = 1;
        }
        else
        {
            i = -1;
        }

        GameObject shot = PoolingManager.Instance.GetPooledObject("Shots2");
        _anim.SetBool("Shoot", true);
        shot.transform.position = shotPoint.position;
        shot.transform.rotation = shotPoint.rotation;
        shot.SetActive(true);
        shot.GetComponent<Rigidbody2D>().AddForce(new Vector2(i * shootingdata.fireForce, 1), ForceMode2D.Impulse);
    }

    void Update()
    {
        if (_anim.GetBool("Crouch"))
        {
            shotPoint = shotPoint2;
        }
        else
        {
            shotPoint = shotPoint1;
        }
    }
}
