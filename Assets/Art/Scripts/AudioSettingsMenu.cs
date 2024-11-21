using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsMenu : MonoBehaviour
{
    public Slider sfxVolumeSlider; // Reference to the SFX volume slider

    private void Start()
    {
        // Set the slider's current value to the saved SFX volume
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Add listener to respond when the slider value changes
        sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);

          // Find all AudioListeners in the scene
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();

        // If more than one listener is found, disable the extra ones
        if (listeners.Length > 1)
        {
            for (int i = 1; i < listeners.Length; i++)
            {
                listeners[i].enabled = false;
            }
        }
    }

    // This method is called whenever the slider's value is changed
    public void OnSFXVolumeChanged(float volume)
    {
        // Set the SFX volume in the AudioManager
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetSFXVolume(volume);
        }
    }

    private void OnDestroy()
    {
        // Remove listener when the object is destroyed
        sfxVolumeSlider.onValueChanged.RemoveListener(OnSFXVolumeChanged);
    }
}
