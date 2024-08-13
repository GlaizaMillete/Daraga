using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        if (volumeSlider != null && audioSource != null)
        {
            // Set the initial slider value to the current volume
            volumeSlider.value = audioSource.volume;

            // Add a listener to call the method when the slider value changes
            volumeSlider.onValueChanged.AddListener(delegate { AdjustVolume(); });
        }
    }

    void AdjustVolume()
    {
        if (audioSource != null && volumeSlider != null)
        {
            audioSource.volume = volumeSlider.value;
        }
    }
}
