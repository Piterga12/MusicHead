using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    public Transform player;
    private float speed = 6;
    private float timer = 5;

    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 3)
        {
            speed = 0;
            timer = timer - Time.deltaTime;
            _anim.SetBool("crouch", true);
        } else if (transform.position.x <= -50)
        {
            player.localScale = new Vector3(0.1001071f, 0.1001071f, 0.1001071f);
            speed = 6;
            _anim.SetBool("crouch", false);
        }
        if(timer <= 0)
        {
            player.localScale = new Vector3(-0.1001071f, 0.1001071f, 0.1001071f);
            speed = -6;
            timer = 5;
        }
        
        transform.position += Vector3.right * speed * Time.deltaTime;
        
    }
}
