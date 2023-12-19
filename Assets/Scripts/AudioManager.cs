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

    // Method to be called by the UI slider
    public void SetVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }
}
