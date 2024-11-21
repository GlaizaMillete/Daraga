using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If we're in the LiwaywayHouse scene, handle the Cinemachine camera transition
        if (scene.name == "LiwaywayHouse")
        {
            HandleCinemachineTransition();
        }
    }

    private void HandleCinemachineTransition()
    {
        // Find all CinemachineVirtualCamera instances
        var virtualCameras = FindObjectsOfType<CinemachineVirtualCamera>();

        foreach (var cam in virtualCameras)
        {
            // Disable or destroy any Cinemachine camera clones from other scenes
            if (cam.gameObject.scene.name != "LiwaywayHouse")
            {
                Destroy(cam.gameObject); // Removes the unwanted camera clones
            }
            else
            {
                // Ensure the correct Cinemachine camera in LiwaywayHouse is active
                cam.Priority = 10; // Set higher priority if necessary
                cam.Follow = GameObject.FindWithTag("Player").transform; // Ensure it follows the player
            }
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
