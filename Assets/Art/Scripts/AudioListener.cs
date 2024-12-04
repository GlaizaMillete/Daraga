using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioListenerManager : MonoBehaviour
{
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find all active Audio Listeners in the scene
        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();

        // Check if there are multiple Audio Listeners
        if (audioListeners.Length > 1)
        {
            Debug.LogWarning("Multiple Audio Listeners detected. Disabling extras.");

            // Keep only the first one and disable the rest
            for (int i = 1; i < audioListeners.Length; i++)
            {
                Debug.LogWarning($"Disabling Audio Listener on GameObject: {audioListeners[i].gameObject.name}");
                audioListeners[i].enabled = false;
            }
        }
    }

    private void OnEnable()
    {
        // Subscribe to the SceneManager.sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from the SceneManager.sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
