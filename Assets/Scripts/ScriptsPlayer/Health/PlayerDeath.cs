using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject gameOver, text, pause;
    bool death= false;
    float deathTime = 2;

    private Animator _anim;

    void OnEnable()
    {
        GetComponent<HealthSystem>().Death += GameOver;
    }
    void OnDisable()
    {
        GetComponent<HealthSystem>().Death -= GameOver;
    }
    void Awake()
    {
        _anim = GetComponent<Animator>();
    }


    virtual public void GameOver()
    {
        _anim.SetBool("Dead", true);
        death = true;
        ScriptDestroyer();
    }  

    private void Update()
    {
        if (deathTime<=0)
        {
            gameObject.SetActive(false);
            gameOver.SetActive(true);
            pause.SetActive(false);
            text.SetActive(true);
            Cursor.visible = true;
        }
        if (death)
        {
            deathTime = deathTime - Time.deltaTime;
        }
    }

    virtual public void ScriptDestroyer()
    {
        Destroy(gameObject.GetComponent<InputSystemKeyboard>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<PlayerDash>());
        Destroy(gameObject.GetComponent<Player_Dash_Trail>());
        Destroy(gameObject.GetComponent<PlayerMovement>());
        Destroy(gameObject.GetComponent<PlayerJump>());
        Destroy(gameObject.GetComponent<PlayerCrouch>());
        Destroy(gameObject.GetComponent<ShootController>());
        Destroy(gameObject.GetComponent<ShootingSystem>());
        Destroy(gameObject.GetComponent<ShotChanger>());
        Destroy(gameObject.GetComponent<ParabolicShotChanger>());
    }
}
