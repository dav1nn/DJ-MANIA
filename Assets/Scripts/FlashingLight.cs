using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    public Light lightToFlash; 
    public Color[] colors; 
    public AudioSource audioSource; 
    public float beatThreshold = 0.05f;

    private float[] spectrumData;
    private int currentColorIndex = 0;

    void Start()
    {
        if (lightToFlash == null) return;

        spectrumData = new float[512];
    }

    void Update()
    {
        if (audioSource == null || lightToFlash == null) return;

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
        lightToFlash.color = colors[currentColorIndex];
    }
}
