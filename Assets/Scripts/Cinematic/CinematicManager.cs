using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicManager : MonoBehaviour
{
    public int sceneIndex = 2;
    private bool loadScene;
    public new Transform camera;

    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (loadScene)
        {
            Time.timeScale = 1;
            audioData.Pause();
            Cursor.visible = false;
            LevelLoader.LoadLevel("03_InGame");
            //SceneManager.LoadScene(sceneIndex);
        }  
        else if (Input.GetKeyDown(KeyCode.Return) || camera.position.x > 57.7)
        {
            loadScene = true;
            Update();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 5;
        } else if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Time.timeScale = 0;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Time.timeScale = 1;
        }
        loadScene = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hola");

        loadScene = true;
        Update();
    }
}
