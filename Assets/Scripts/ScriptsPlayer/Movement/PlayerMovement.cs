using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerMoveAbility
{
    public Transform player;

    void Start()
    {
        _input = GetComponent<InputSystemKeyboard>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!PlayerDash.dashActive)
        {
            _rb.velocity = new Vector2(_input.hor * pmaData.velForce, _rb.velocity.y);
        }
        if (_input.hor > 0)
        {
            player.localScale = new Vector3(0.0640711f, 0.0640711f, 0.0640711f);
            _anim.SetBool("Run", true);
        }
        else if(_input.hor < 0)
        {
            player.localScale = new Vector3(-0.0640711f, 0.0640711f, 0.0640711f);
            _anim.SetBool("Run", true);
        }
        if (_input.hor == 0)
        {
            _anim.SetBool("Run", false);
        }

    }

}
