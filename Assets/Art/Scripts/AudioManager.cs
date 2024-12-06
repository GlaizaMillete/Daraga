using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [Range(0f, 1f)]
    public float sfxVolume = 1f; // Default volume

    // Array to store all AudioSource components for SFX in the game
    private AudioSource[] sfxSources;

    // List of scenes where the AudioManager should be destroyed
    public List<string> scenesToDestroyOn = new List<string>();

    private void Awake()
    {
        // Prevent duplicate instances of the AudioManager
        if (FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject); // Destroy any duplicate AudioManager
            return;
        }

        DontDestroyOnLoad(gameObject); // Keep this instance persistent between scenes

        // Load the saved SFX volume from PlayerPrefs (if it exists)
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }

    private void Start()
    {
        // Ensure there's exactly one AudioListener in the scene
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();
        if (listeners.Length > 1)
        {
            for (int i = 0; i < listeners.Length; i++)
            {
                if (listeners[i].gameObject != gameObject) // Keep the AudioListener on the main GameObject
                {
                    Destroy(listeners[i]);
                }
            }
        }
    }

    // Initialize or refresh the list of AudioSources in the scene
    private void InitializeAudioSources()
    {
        // Find all AudioSources and get their components
        sfxSources = FindObjectsOfType<AudioSource>();

        // Apply the initial volume to all SFX sources
        UpdateSFXVolume();
    }

    // Update the volume for all SFX sources
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

    private void OnEnable()
    {
        // Refresh AudioSources when the scene changes
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        // Check if the current scene is in the list of scenes to destroy this object
        if (scenesToDestroyOn.Contains(scene.name))
        {
            Debug.Log($"Destroying AudioManager in scene: {scene.name}");
            Destroy(gameObject); // Destroy the AudioManager
        }
        else
        {
            InitializeAudioSources(); // Reinitialize SFX sources in the new scene
        }
    }
}
