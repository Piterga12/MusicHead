using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    private bool loadScene;

    
    void Update()
    {
        if (loadScene)
        {
            Application.Quit();
        }
    }

    void OnMouseDown()
    {
        
        loadScene = true;
        Update();
    }
}
