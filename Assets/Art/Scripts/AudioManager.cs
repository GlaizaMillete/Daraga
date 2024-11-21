using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Range(0f, 1f)] 
    public float sfxVolume = 1f; // Default volume

    // Array to store all AudioSource components for SFX in the game
    private AudioSource[] sfxSources;

    private void Awake()
    {
        // Singleton pattern to ensure only one AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep AudioManager persistent between scenes
        }
        else
        {
            Destroy(gameObject);
        }

        // Load the saved SFX volume from PlayerPrefs (if it exists)
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }

    private void Start()
    {
        // Find all objects tagged as SFX and get their AudioSource components
        sfxSources = FindObjectsOfType<AudioSource>();

        // Apply initial volume to all SFX sources
        UpdateSFXVolume();

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

    // Call this method to update all SFX volume when the slider changes
    public void UpdateSFXVolume()
    {
        foreach (AudioSource sfxSource in sfxSources)
        {
            if (sfxSource != null)
                sfxSource.volume = sfxVolume; // Adjust the volume of each SFX
        }

        // Save the current SFX volume setting
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    // Method to set SFX volume from an external source (like the UI slider)
    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        UpdateSFXVolume(); // Apply the new volume to all SFX sources
    }
}
