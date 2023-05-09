using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu, controlsMenu, Dialog, pause;

    public void pauseButton()
    {
        pauseMenu.SetActive(true);
        pause.SetActive(false);
        Dialog.SetActive(false);
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void playButton()
    {
        pauseMenu.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 1;
        Cursor.visible = false;
        Dialog.SetActive(true);
    }

    public void exitButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void optionsButton()
    {
        controlsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        
    }
    public void ExitOptionsButton()
    {
        
        controlsMenu.SetActive(false);
        pauseMenu.SetActive(true);

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && pause.activeSelf)
        {
            pauseButton();
        }
    }
}
