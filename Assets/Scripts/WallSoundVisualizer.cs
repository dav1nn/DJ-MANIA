using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSoundVisualizer : MonoBehaviour
{
    public GameObject[] visualizerElements; 
    public AudioSource audioSource; 
    public Color[] colors; 
    public float beatThreshold = 0.05f; 

    private float[] spectrumData;
    private int currentColorIndex = 0;

    void Start()
    {
        if (audioSource == null) 
        {
            Debug.LogError("AudioSource not assigned");
            return;
        }
        spectrumData = new float[512];
    }

    void Update()
    {
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        if (IsBeatDetected())
        {
            ChangeColor();
        }
    }

    bool IsBeatDetected()
    {
        float sumLowFreq = 0.0f;
        for (int i = 0; i < 20; i++)
        {
            sumLowFreq += spectrumData[i];
        }
        return sumLowFreq > beatThreshold;
    }

    void ChangeColor()
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        Color newColor = colors[currentColorIndex];
        foreach (var element in visualizerElements)
        {
            Renderer renderer = element.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = newColor;
            }
        }
    }
}

