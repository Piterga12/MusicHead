using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    
    
    public class Controller : MonoBehaviour
    {
        private HealthSystem healthSystem;
        
        public State currentState;
        public State remainState;

        public bool ActiveAI { get; set; }

        public void Start()
        {
            ActiveAI = true;
        }

        private Animator _animatorController;

        public void Awake()
        {
            _animatorController = GetComponent<Animator>();
            healthSystem = GetComponent<HealthSystem>();
        }

        public void Update()
        {
            if (!ActiveAI) return;

            currentState.UpdateState(this);
        }

        public void Transition(State nextState)
        {
            if(nextState != remainState)
            {
                currentState = nextState;
            }
        }

        public void SetAnimation(string state, bool active)
        {
            _animatorController.SetBool(state, active);
        }
        
        public int GetCurrentHealth()
        {
            int currentHealth = healthSystem.PublicHealth();
            //Debug.Log(currentHealth);
            return currentHealth;
        }

    }
}
