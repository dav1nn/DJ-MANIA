using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public DancingCapsule[] dancers; 

    void Start()
    {
        SquareFlasher.SetSharedAudioSource(backgroundMusic);
        dancers = FindObjectsOfType<DancingCapsule>();
    }

    public void SetVolume(float volume)
    {
        backgroundMusic.volume = volume;

        
        bool shouldDance = volume > 0;
        foreach (var dancer in dancers)
        {
            dancer.SetDancing(shouldDance);
        }
    }
}
