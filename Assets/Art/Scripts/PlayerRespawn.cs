using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public string targetSceneName = "LiwaywayHouse"; // Name of the scene for respawning
    private Transform doorSpawnPoint;  // Reference to the spawn point

    void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event when the object is disabled
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the newly loaded scene is LiwaywayHouse
        if (scene.name == targetSceneName)
        {
            // Find the DoorSpawnPoint object in the scene
            doorSpawnPoint = GameObject.Find("doorSpawnPoint")?.transform;

            // If found, set the player's position to the DoorSpawnPoint position
            if (doorSpawnPoint != null)
            {
                // Set player's position to the spawn point
                transform.position = doorSpawnPoint.position;

                // Optional: Align player orientation with the door spawn point
                transform.rotation = doorSpawnPoint.rotation;

                Debug.Log("Player respawned at doorSpawnPoint in LiwaywayHouse.");
            }
            else
            {
                Debug.LogWarning("DoorSpawnPoint not found in the scene. Please ensure it is correctly placed.");
            }
        }
    }
}
