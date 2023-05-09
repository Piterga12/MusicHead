using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputSystemKeyboard : MonoBehaviour
{
    public float hor { get; private set; }
    public float ver { get; private set; }

    public event Action OnFire = delegate { };
    public event Action OnJump = delegate { };
    public event Action OnDash = delegate { };
    public event Action OnCrouch = delegate { };
    public event Action NotOnCrouch = delegate { };
    public event Action OnChangeShot = delegate { };

    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            OnFire();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnDash();
        }
        if (Input.GetMouseButtonDown(1))
        {
            OnChangeShot();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnCrouch();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            NotOnCrouch();
        }
    }
}
