using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        // Ensure only one instance exists and it persists across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSpecificScene(string sceneName, Vector3 spawnPosition, Vector3 cameraPosition)
    {
        // Load the scene and update the positions
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        // Set player spawn position and camera position logic...
    }

    private IEnumerator LoadSceneAndSetPosition(string sceneName, Vector3 playerPosition, Vector3 cameraPosition)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the scene is fully loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Set the player's and camera's position
        PositionPlayerAndCamera(playerPosition, cameraPosition);
    }

    private void PositionPlayerAndCamera(Vector3 playerPosition, Vector3 cameraPosition)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = playerPosition;
        }

        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            mainCamera.transform.position = cameraPosition;
        }
    }
}
