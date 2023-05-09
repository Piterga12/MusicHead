using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if __DEBUG_AVAILABLE__
using UnityEditor;
#endif

public class PlayerJump : PlayerMoveAbility
{

    public Transform GroundChecker;
    public float radius;
    public LayerMask groundMask;

    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().OnJump += Jump;
    }
    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().OnJump -= Jump;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(GroundChecker.position, radius, groundMask) && _rb.velocity.y < 0)
        {
            _anim.SetBool("Jump", false);
        }
    }

    void Jump()
    {
        if (Physics2D.OverlapCircle(GroundChecker.position, radius, groundMask) && _anim.GetBool("Crouch")==false)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, pmaData.velForce);
            _anim.SetBool("Jump", true);
        }
        #if __DEBUG_AVAILABLE__
        if (Switches.debugMode && Switches.debugCheatsMode)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, pmaData.velForce);
            _anim.SetBool("Jump", true);
        }
        #endif
    }

#if __DEBUG_AVAILABLE__
    private void OnDrawGizmos()
    {
    if (Switches.debugMode && Switches.debugShowInfo)
        {
            Handles.color = Color.yellow;
            Handles.DrawWireDisc(GroundChecker.position, Vector3.forward, radius);
        }
    }
#endif
}

