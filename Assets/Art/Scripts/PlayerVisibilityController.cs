using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVisibilityController : MonoBehaviour
{
    public string sceneToHidePlayer; // The name of the scene where the player should be hidden
    private GameObject player;

    private void Awake()
    {
        // Find the player GameObject in the scene (assumes it's tagged as "Player")
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player GameObject not found! Ensure it is tagged as 'Player'.");
        }

        // Subscribe to scene loading event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene matches the specified scene
        if (scene.name == sceneToHidePlayer)
        {
            HidePlayer();
        }
        else
        {
            ShowPlayer();
        }
    }

    private void HidePlayer()
    {
        if (player != null)
        {
            player.SetActive(false); // Disable the player GameObject
        }
    }

    private void ShowPlayer()
    {
        if (player != null)
        {
            player.SetActive(true); // Re-enable the player GameObject
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
