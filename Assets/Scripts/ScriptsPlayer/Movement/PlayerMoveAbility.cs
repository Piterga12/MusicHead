using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMoveAbility : MonoBehaviour
{
    public PlayerMoveAbilityData pmaData;
    public Rigidbody2D _rb;
    public Animator _anim;
    public InputSystemKeyboard _input;
}
