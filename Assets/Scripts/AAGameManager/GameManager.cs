using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    static GameManager instance;

    void OnEnable()
    {
        PlayButton.changeScene += newScene;
    }
    void OnDisable()
    {
        PlayButton.changeScene -= newScene;
    }

    void Start()
    {
        if(instance == null)
        {
            GameObject.DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            GameObject.Destroy(gameObject);

        }
        
    }

    void newScene(int sceneIndex) {
        Cursor.visible = false;
        SceneManager.LoadScene(sceneIndex);
    }

    void Update()
    {
        
    }
}
