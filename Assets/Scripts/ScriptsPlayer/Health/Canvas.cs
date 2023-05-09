using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    public Text textElement;

    private int vida;
    
    void OnEnable()
    {
        LifeCanvas.loseHealth += newHP;
    }
    void OnDisable()
    {
        LifeCanvas.loseHealth -= newHP;
    }  

    void newHP(int k)
    {
        vida = k;
        if (vida <= 0)
        {
            vida = 0;
        }
        textElement.text = "HP " + vida;
        
    }
}
