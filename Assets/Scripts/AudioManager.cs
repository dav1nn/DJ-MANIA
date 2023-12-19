using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic; 

    void Start()
    {
        SquareFlasher.SetSharedAudioSource(backgroundMusic);
    }

    public void SetVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }
}
