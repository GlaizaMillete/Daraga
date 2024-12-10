using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FinishDMsuitors : MonoBehaviour
{
    [SerializeField] private string cutsceneSceneName = "DMatUlap"; // Cutscene scene name
    [SerializeField] private string targetSceneName = "IlogScene"; // Next scene name
    [SerializeField] private Vector3 playerSpawnPosition = new Vector3(0, 0, 0); // Player position
    [SerializeField] private Vector3 cameraPosition = new Vector3(0, 0, -10); // Camera position

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Save progress for Chapter 1 completion
            SaveProgress();

            // Start the cutscene and transition to the next scene after it's done
            StartCoroutine(PlayCutsceneAndLoadNextScene());
        }
    }

    private void SaveProgress()
    {
        PlayerPrefs.SetFloat("Chapter2Progress", 100f); // Save chapter progress
        PlayerPrefs.SetString("LastSavedScene", cutsceneSceneName); // Save current scene
        PlayerPrefs.Save();
    }

    private IEnumerator PlayCutsceneAndLoadNextScene()
    {
       
        DisableExtraEventSystems();

        // Load the cutscene scene additively
        AsyncOperation asyncCutsceneLoad = SceneManager.LoadSceneAsync(cutsceneSceneName, LoadSceneMode.Additive);
        while (!asyncCutsceneLoad.isDone)
        {
            yield return null;
        }

        // Wait for the cutscene to finish
        yield return new WaitForSeconds(35f); // Replace with actual cutscene duration

        // Unload the cutscene scene
        SceneManager.UnloadSceneAsync(cutsceneSceneName);

        // Load the target scene (DMsuitors)
        AsyncOperation asyncTargetSceneLoad = SceneManager.LoadSceneAsync(targetSceneName, LoadSceneMode.Single);
        while (!asyncTargetSceneLoad.isDone)
        {
            yield return null;
        }

        // Set player's position and camera in the target scene
        PositionPlayerAndCamera();
    }

   
    private void DisableExtraEventSystems()
    {
        // Find all EventSystem components in the scene
        EventSystem[] eventSystems = FindObjectsOfType<EventSystem>();
        for (int i = 1; i < eventSystems.Length; i++)
        {
            Destroy(eventSystems[i].gameObject); // Remove extra event systems
        }
    }


    private void PositionPlayerAndCamera()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = playerSpawnPosition;
        }

        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            mainCamera.transform.position = cameraPosition;
        }
    }
}
