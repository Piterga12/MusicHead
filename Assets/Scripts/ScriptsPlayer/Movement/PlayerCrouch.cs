using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : PlayerMoveAbility
{

    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().OnCrouch += Crouch;
        GetComponent<InputSystemKeyboard>().NotOnCrouch += EndCrouch;
    }
    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().OnCrouch -= Crouch;
        GetComponent<InputSystemKeyboard>().NotOnCrouch -= EndCrouch;
    }


    // Update is called once per frame
    void EndCrouch()
    {
        _anim.SetBool("Crouch", false);
    }

    void Crouch()
    {
        _anim.SetBool("Crouch", true);
        
    }
}
