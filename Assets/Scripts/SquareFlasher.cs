using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareFlasher : MonoBehaviour
{
    public static AudioSource sharedAudioSource;
    public float baseFlashDuration = 0.5f;
    public Color[] initialColors;       
    public Color[] changedColors;         
    public float beatThreshold = 0.05f;
    public float maxFlashDurationChange = 0.4f;
    public float colorChangeTime = 40.0f;  
    private Renderer squareRenderer;
    private float timer;
    private float[] spectrumData;
    private float currentFlashDuration;
    private float colorChangeTimer;
    private bool colorSetChanged = false;

    void Start()
    {
        squareRenderer = GetComponent<Renderer>();
        spectrumData = new float[512];
        currentFlashDuration = baseFlashDuration;
        colorChangeTimer = colorChangeTime;
    }

    void Update()
    {
      if (sharedAudioSource != null && sharedAudioSource.isPlaying)
        {
          AnalyzeMusic();
            colorChangeTimer -= Time.deltaTime;

            
 if (!colorSetChanged && colorChangeTimer <= 0)
         {
                colorSetChanged = true;
         }

        timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = currentFlashDuration;

                if (IsBeatDetected())
              {
                 ChangeColor();
                 AdjustFlashDuration();
              }
         }
         }
        }

    void AnalyzeMusic()
    {
        sharedAudioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);
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
     Color[] currentColors = colorSetChanged ? changedColors : initialColors;
     Color randomColor = currentColors[Random.Range(0, currentColors.Length)];
     squareRenderer.material.color = randomColor;
    }

    void AdjustFlashDuration()
    {
        float beatIntensity = CalculateBeatIntensity();
        currentFlashDuration = baseFlashDuration - (maxFlashDurationChange * beatIntensity);
        currentFlashDuration = Mathf.Clamp(currentFlashDuration, 0.1f, baseFlashDuration + maxFlashDurationChange);
    }

    float CalculateBeatIntensity()
    {
        float sumLowFreq = 0.0f;
        for (int i = 0; i < 20; i++)
        {
            sumLowFreq += spectrumData[i];
        }
        return sumLowFreq / 20;
    }

    public static void SetSharedAudioSource(AudioSource source)
    {
        sharedAudioSource = source;
    }
}



