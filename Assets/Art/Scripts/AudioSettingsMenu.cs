using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsMenu : MonoBehaviour
{
    public Slider sfxVolumeSlider; // Reference to the SFX volume slider
    private AudioManager audioManager; // Reference to the AudioManager

    private void Start()
    {
        // Find the AudioManager in the scene
        audioManager = FindObjectOfType<AudioManager>();

        // Ensure the AudioManager exists
        if (audioManager != null)
        {
            // Set the slider's current value to the saved SFX volume
            sfxVolumeSlider.value = audioManager.sfxVolume;

            // Add listener to respond when the slider value changes
            sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        }
        else
        {
            Debug.LogError("AudioManager not found in the scene!");
        }

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
        if (audioManager != null)
        {
            audioManager.SetSFXVolume(volume);
        }
    }

    private void OnDestroy()
    {
        // Remove listener when the object is destroyed
        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.onValueChanged.RemoveListener(OnSFXVolumeChanged);
        }
    }
}
