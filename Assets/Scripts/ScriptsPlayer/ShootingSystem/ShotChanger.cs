using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotChanger : MonoBehaviour
{
    public ShootingSystemData sh;
    public Transform pl;

    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().OnChangeShot += ChangeShot;
    }
    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().OnChangeShot -= ChangeShot;
    }

    
    public void ChangeShot()
    {
        if (!gameObject.GetComponent<ShootSystem>())
        {
            Transform p = gameObject.GetComponent<ShootController>().GetShotPoint();
            Transform p2 = gameObject.GetComponent<ShootController>().GetShotPoint1();
            Destroy(gameObject.GetComponent<ShootingSystem>());
            ShootSystem s = gameObject.AddComponent<ShootSystem>();
            s.shootingdata = sh;
            s.shotPoint1 = p;
            s.shotPoint2 = p2;
            s.player = pl;
            gameObject.GetComponent<ShootController>().launcher = s;
        }
    }
    void Update()
    {
        
    }
}
