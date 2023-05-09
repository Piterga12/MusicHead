using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

#if __DEBUG_AVAILABLE__

using UnityEditor;

#endif

public class LevelManager : MonoBehaviour
{
    public Transform gameCamera;
    public Transform Player;
    public Transform[] cameraPositions;

    private float TimeDialog;
    private bool varTime;

    void OnEnable()
    {
        HealthBoss.endWin += endGame;
    }
    void OnDisable()
    {
        HealthBoss.endWin -= endGame;
    }

    //Cinematic######################################
    public enum CinematicCommandId
    {
        enterCinematicMode,
        exitCinematicMode,
        wait,
        log,
        showDialog,
        setCameraPosition,
        setCameraSize
    };

    [System.Serializable]
    public struct CinematicCommand
    {
        public CinematicCommandId id;
        public string param1;
        public string param2;
        public string param3;
        public string param4;
    }

    [System.Serializable]
    public struct CinematicSequence
    {
        public string name;
        public CinematicCommand[] commands;
    };

    [Header("Cinematic system")]
    public CinematicSequence[] sequences;

    [Header("Dialog system")]
    //Cinematic######################################

    public Transform[] dialogCommon;
    public Transform[] dialogCharacters;
    public Transform dialogText;

    [System.Serializable]
    public struct DialogData
    {
        public int character;
        public string text;
    };
    public DialogData[] dialogsData;

    //Cinematic######################################
    int sequenceIndex;
    int commandIndex;
    bool waiting;
    float waitTimer;
    bool isCinematicMode;

    bool showingDialog;
    int dialogIndex;

    TextMeshPro dialogTextC;

    GameCamera gameCameraC;

    
    void Start()
    {
        //Cinematic######################################
        isCinematicMode = false;
        waiting = false;
        varTime = false;

        showingDialog = false;
        dialogIndex = 1;

        dialogTextC = dialogText.GetComponent<TextMeshPro>();

        gameCameraC = gameCamera.GetComponent<GameCamera>();

        for (int i = 0; i < dialogCommon.Length; i++)
        {
            dialogCommon[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < dialogCharacters.Length; i++)
        {
            dialogCharacters[i].gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isCinematicMode)
        {
            if (showingDialog)
            {
                //******************************************************
                if (!varTime)
                {
                    varTime=true;
                    TimeDialog = 3;
                }
                TimeDialog = TimeDialog - Time.deltaTime;

                //Debug.Log(TimeDialog);
                //******************************************************

                for (int i = 0; i < dialogCommon.Length; i++)
                {
                    dialogCommon[i].gameObject.SetActive(true);
                }
                for (int i = 0; i < dialogCharacters.Length; i++)
                {
                    dialogCharacters[i].gameObject.SetActive(false);
                }

                int character = dialogsData[dialogIndex].character;
                string text = dialogsData[dialogIndex].text;

                dialogCharacters[character].gameObject.SetActive(true);
                dialogTextC.text = text;

                if (Input.GetKeyDown(KeyCode.Return) || TimeDialog<0)
                {
                    showingDialog = false;
                    for (int i = 0; i < dialogCommon.Length; i++)
                    {
                        dialogCommon[i].gameObject.SetActive(false);
                    }
                    for (int i = 0; i < dialogCharacters.Length; i++)
                    {
                        dialogCharacters[i].gameObject.SetActive(false);
                    }
                    commandIndex++;
                    varTime = false;
                }

            }
            if (waiting)
            {
                if (waitTimer <= 0)
                {
                    Time.timeScale = 1;
                    waiting = false;
                    commandIndex++;
                }
                else
                {
                    Time.timeScale = 0;
                    waitTimer -= Time.deltaTime;
                }
            }


            else if (commandIndex < sequences[sequenceIndex].commands.Length)
            {
                CinematicCommand command = sequences[sequenceIndex].commands[commandIndex];

                if (command.id == CinematicCommandId.enterCinematicMode)
                {
                    gameCameraC.EnterCinematicMode();
                    isCinematicMode = true;
                }
                else if (command.id == CinematicCommandId.exitCinematicMode)
                {
                    gameCameraC.ExitCinematicMode();
                    isCinematicMode = false;
                }
                else if (command.id == CinematicCommandId.wait)
                {
                    float time = Single.Parse(command.param1);
                    waiting = true;
                    waitTimer = time;
                }
                else if (command.id == CinematicCommandId.log)
                {
                    string message = command.param1;
                    Debug.Log("Cinematic Log: " + message);
                }
                else if (command.id == CinematicCommandId.showDialog)
                {
                    int index = Int32.Parse(command.param1);

                    showingDialog = true;
                    dialogIndex = index;
                }
                else if (command.id == CinematicCommandId.setCameraPosition)
                {
                    int index = Int32.Parse(command.param1);

                    gameCamera.position = cameraPositions[index].position;
                }
                else if (command.id == CinematicCommandId.setCameraSize)
                {
                    float size = Single.Parse(command.param1);

                    gameCameraC.SetSize(size);
                }
                else
                {
                    Debug.Log("Comando de cinematica no implementado");
                }

                if (!waiting && !showingDialog)
                {
                    commandIndex++;

                }
            }
            else
            {
                isCinematicMode = false;
            }
        }

    }

    public void OnTriggerCinematic(int index)
    {
            sequenceIndex = index;
            isCinematicMode = true;
            commandIndex = 0;
    }

    public void endGame(int k)
    {
        Cursor.visible = true;
        SceneManager.LoadScene(4);
    }

    public bool IsCinematicMode()
    {
        return isCinematicMode;
    }
}
