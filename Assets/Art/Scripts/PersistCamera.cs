using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PersistentCamera : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCamera;  // Reference to the Cinemachine Virtual Camera
    private GameObject player;  // Reference to the player object

    private void Awake()
    {
        // Remove DontDestroyOnLoad to avoid camera persistence issues across scenes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        // Set up the initial camera and player references
        SetupCameraForCurrentScene();
    }

    // This method is called each time a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetupCameraForCurrentScene();
    }

    private void SetupCameraForCurrentScene()
    {
        // Try to find the player in the current scene
        player = GameObject.FindWithTag("Player");

        // Try to find the Cinemachine camera in the scene
        cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();

        if (cinemachineCamera == null)
        {
            Debug.LogWarning("No Cinemachine camera found in the scene.");
        }
        else if (player != null)
        {
            FollowPlayer();  // Set the camera to follow the player
        }
    }

    // Set the Cinemachine camera to follow and look at the player
    private void FollowPlayer()
    {
        if (cinemachineCamera != null && player != null)
        {
            cinemachineCamera.Follow = player.transform;
            cinemachineCamera.LookAt = player.transform;
        }
        else
        {
            Debug.LogWarning("Cinemachine camera or player is not set.");
        }
    }

    private void OnDisable()
    {
        // Remove the scene loaded listener when the script is disabled
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
