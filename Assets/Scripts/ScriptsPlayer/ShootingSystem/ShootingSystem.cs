using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingSystem : MonoBehaviour
{
    public ShootingSystemData shootingdata;

    public Transform shotPoint;

    public Transform shotPoint1;

    public Transform shotPoint2;

    public Transform player;

    public Animator _anim;


    public abstract void Shot();

}
