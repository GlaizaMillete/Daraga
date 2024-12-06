using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerVisibilityController : MonoBehaviour
{
    public List<string> scenesToHidePlayer; // List of scenes where the player should be hidden
    private GameObject player;

    private void Awake()
    {
        // Find the player GameObject in the scene (assumes it's tagged as "Player")
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player GameObject not found! Ensure it is tagged as 'Player'.");
        }

        // Subscribe to scene loading and unloading events
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is in the list of scenes to hide the player
        if (scenesToHidePlayer.Contains(scene.name))
        {
            HidePlayer();
        }
        else
        {
            ShowPlayer();
        }
    }

    private void OnSceneUnloaded(Scene scene)
    {
        // Re-enable the player when leaving a scene that hides it
        if (scenesToHidePlayer.Contains(scene.name))
        {
            ShowPlayer(); // Ensure the player is re-enabled when transitioning away
        }
    }

    private void HidePlayer()
    {
        if (player != null)
        {
            player.SetActive(false); // Disable the player GameObject
            Debug.Log("Player hidden in scene: " + SceneManager.GetActiveScene().name);
        }
    }

    private void ShowPlayer()
    {
        if (player != null)
        {
            player.SetActive(true); // Re-enable the player GameObject
            Debug.Log("Player shown in scene: " + SceneManager.GetActiveScene().name);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the events to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
}
