using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDMG : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;

    private int velX;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        GetComponent<HealthSystem>().DMGReceiver += KnockBack;
    }
    void OnDisable()
    {
        GetComponent<HealthSystem>().DMGReceiver += KnockBack;
    }

    void KnockBack()
    {
        _anim.SetTrigger("DMGReceiver");
        _rb.velocity = new Vector2(_rb.velocity.x, 3);

        /*if(_rb.velocity.x > 0)
        {
            _rb.position = new Vector2(_rb.position.x - 0.5f, _rb.position.y);
        }
        else if(_rb.velocity.x < 0)
        {
            _rb.position = new Vector2(_rb.position.x + 0.5f, _rb.position.y);
        }*/


        //_anim.SetBool("DMGReceiver", false);
    }
}
