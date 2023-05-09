using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicManager2 : MonoBehaviour
{
    public int sceneIndex = 0;
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
            audioData.Pause();
            SceneManager.LoadScene(sceneIndex);
        }  
        else if (Input.GetKeyDown(KeyCode.Return) || camera.position.y < 1.3)
        {
            loadScene = true;
            Update();
        }

        loadScene = false;
    }
}
