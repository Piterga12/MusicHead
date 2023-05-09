using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDash : PlayerMoveAbility
{
    public static bool dashActive = false;
    private float dashTime, dashTimeEnd;
    public float dashCooldown = 0;
    public Transform player;

    public GameObject DashIcon;

    public event Action EndDash = delegate { };

    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().OnDash += Dash;
    }
    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().OnDash -= Dash;
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (dashTimeEnd > dashTime)
        {
            /*Debug.Log("dashTime"+dashTime);
            Debug.Log("dashTimeEnd" + dashTimeEnd);*/
            dashTime = dashTime + Time.deltaTime;
        }
        else if(dashTime != 0 && dashTimeEnd < dashTime)
        {
            dashActive = false;
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            _rb.gravityScale = 1;
            dashTime=0;
            dashTimeEnd = 0;
            EndDash();
            
        } else if(dashTime ==0 && dashTimeEnd == 0)
        {
            
        }

        if(dashCooldown > 0)
        {
            dashCooldown = dashCooldown - Time.deltaTime;
        }
        else
        {
            DashIcon.SetActive(true);
        }
    }

    // Update is called once per frame
    void Dash()
    {
        if (dashCooldown <= 0) {
            dashTime = Time.deltaTime;
            dashTimeEnd = Time.deltaTime + 0.2f;
            dashActive = true;
            if (player.localScale.x > 0)
            {
                _rb.velocity = new Vector2(pmaData.velForce, 0);
            }
            else
            {
                _rb.velocity = new Vector2(-pmaData.velForce, 0);
            }
            _rb.gravityScale = 0;
            dashCooldown = 4;
            DashIcon.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dashTime = 0;
    }
}
