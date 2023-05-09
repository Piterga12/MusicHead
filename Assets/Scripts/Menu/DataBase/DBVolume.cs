using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DBVolume : MonoBehaviour
{
    public DBManager dBManager;
    Slider s;

    void Start()
    {  
        s = GetComponentInChildren<Slider>();
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        
        AudioListener.volume = s.value/10;
        SaveOptions();
    }

    private void Load()
    {
        s.value = PlayerPrefs.GetFloat("volume");
    }

    public void SaveOptions()
    {
        //Slider s = GetComponentInChildren<Slider>();
        PlayerPrefs.SetFloat("volume", s.value);

        PlayerPrefs.Save();
        ShowPrefs();
    }

    public void ShowPrefs()
    {
        dBManager.NewVolume(s.value);
        //dBManager.DisplayVolume();
        //Debug.Log(PlayerPrefs.GetFloat("volume"));
    }
}
