using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource BPM;
    public AudioClip[] phase;

    void OnEnable()
    {
        startTrigger.startPhase1 += startPhase;
        HealthBoss.startPhase += startPhase;
    }
    void OnDisable()
    {
        startTrigger.startPhase1 -= startPhase;
        HealthBoss.startPhase -= startPhase;
    }

    void startPhase(int k)
    {
        ChangeBPM(phase[k]);
    }

    public void ChangeBPM(AudioClip music)
    {
        BPM.Stop();
        BPM.clip = music;
        BPM.Play();
    }
}
