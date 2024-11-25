using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PersistentCamera : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineCamera;  // Reference to the Cinemachine Virtual Camera
    private GameObject player;  // Reference to the player object

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;  // Subscribe to scene load event
    }

    private void Start()
    {
        SetupCameraForCurrentScene();  // Set up the camera when the scene starts
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetupCameraForCurrentScene();
    }

    private void SetupCameraForCurrentScene()
    {
        // Locate the player in the current scene
        player = GameObject.FindWithTag("Player");

        // Find the Cinemachine camera
        cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();

        if (player != null && cinemachineCamera != null)
        {
            FollowPlayer();  // Attach the camera to the player
        }
        else
        {
            Debug.LogWarning("Player or Cinemachine camera not found in the scene.");
        }
    }

    private void FollowPlayer()
    {
        if (cinemachineCamera != null && player != null)
        {
            cinemachineCamera.Follow = player.transform;
            cinemachineCamera.LookAt = player.transform;
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // Unsubscribe from the event
    }
}
