using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource musicSource;

    void Start()
    {
        // Initialize the slider value to match the current music volume
        volumeSlider.value = musicSource.volume;
        
        // Add a listener to the slider's value change event
        volumeSlider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        // Set the music volume based on the slider's value
        musicSource.volume = value;
    }
}
