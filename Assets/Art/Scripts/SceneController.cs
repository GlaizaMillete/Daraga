using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSpecificScene(string sceneName, Vector3 playerPosition, Vector3 cameraPosition)
    {
        StartCoroutine(LoadSceneAndSetPosition(sceneName, playerPosition, cameraPosition));
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
