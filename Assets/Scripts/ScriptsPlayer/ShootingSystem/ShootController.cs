using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public ShootingSystemData[] shootingData;
    public Transform[] shotPoints;
    public Transform player;
    public ShootingSystem launcher;
    public Animator _anim;

    int timer = 0;

    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().OnFire += Shot;
    }
    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().OnFire -= Shot;
    }

    void Awake()
    {
        /*InputSystemKeyboard sk;
        if(TryGetComponent<InputSystemKeyboard>(out sk))
        {
            sk.OnFire += Shot;
        }*/

    }
    private void Start()
    {
        launcher = GetComponent<ShootingSystem>();
        _anim = player.GetComponent<Animator>();
    }
    void Shot()
    {
        timer = 80;
        launcher.Shot();
    }

    public Transform GetShotPoint()
    {
        return shotPoints[0];
    }
    public Transform GetShotPoint1()
    {
        return shotPoints[1];
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer--;
        }
        else
        {
            _anim.SetBool("Shoot", false);
        }
    }
}
