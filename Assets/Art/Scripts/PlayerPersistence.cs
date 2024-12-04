using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine; // Import Cinemachine namespace

public class PlayerPersistence : MonoBehaviour
{
    private static PlayerPersistence instance;

    // This dictionary stores the player's starting position for each scene
    private readonly Dictionary<string, Vector3> sceneStartPositions = new Dictionary<string, Vector3>()
    {
        { "ForestScene", new Vector3(-7.57f, -2f, 0) },
        { "RiverScene", new Vector3(19, -2, 0) },
        { "VillageScene", new Vector3(26, -2, 0) },
        { "LiwaywayHouse", new Vector3(17, -3, 0) },
        { "CassavaFields", new Vector3(25.6f, -1.12f, 0) },
        { "DMhouse", new Vector3(-1.43f, -1.08f, 0) },
        { "insideDMhouse", new Vector3(3, -1, 0) },
        { "DMsuitors", new Vector3(34.67f, -0.91f, 0) },
        { "IlogScene", new Vector3(-1.45f, -0.91f, 0) },
    };

    private void Awake()
    {
        // Ensure only one instance of the player exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    private void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene has a defined starting position
        if (sceneStartPositions.TryGetValue(scene.name, out Vector3 startPosition))
        {
            transform.position = startPosition; // Set player position for the new scene
        }

        // Rebind Cinemachine Virtual Camera
        RebindCinemachine();
    }

    private void RebindCinemachine()
    {
        // Find the Cinemachine Virtual Camera in the current scene
        CinemachineVirtualCamera virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        if (virtualCamera != null)
        {
            virtualCamera.Follow = transform; // Set the player as the Follow target
            virtualCamera.LookAt = transform; // Set the player as the LookAt target (if applicable)
        }
    }
}
