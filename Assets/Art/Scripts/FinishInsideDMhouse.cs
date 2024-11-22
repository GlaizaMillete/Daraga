using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishInsideDMHouse : MonoBehaviour
{
    [SerializeField] private string cutsceneSceneName = "AngMgaSuitors"; // Scene for the cutscene
    [SerializeField] private string targetSceneName = "DMsuitors"; // Scene to load after cutscene
    [SerializeField] private Vector3 playerSpawnPosition = new Vector3(0, 0, 0); // Player's position in the target scene
    [SerializeField] private Vector3 cameraPosition = new Vector3(0, 0, -10); // Camera position in the target scene

    private AudioSource[] otherSceneAudioSources;
    private GameObject[] otherSceneObjects;

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
        PlayerPrefs.SetFloat("Chapter1Progress", 100f); // Mark Chapter 1 as complete (100%)
        PlayerPrefs.SetString("LastSavedScene", cutsceneSceneName); // Save the cutscene scene as last
        PlayerPrefs.Save();
    }

    private IEnumerator PlayCutsceneAndLoadNextScene()
    {
        // Save and store the current scene's audio sources and game objects
        StoreOtherSceneElements();

        // Mute the audio and disable objects in other scenes to prevent interruptions
        MuteOtherSceneAudio();
        DisableOtherSceneObjects();

        // Load the cutscene scene first
        AsyncOperation asyncCutsceneLoad = SceneManager.LoadSceneAsync(cutsceneSceneName, LoadSceneMode.Additive);
        while (!asyncCutsceneLoad.isDone)
        {
            yield return null;
        }

        // Wait until the cutscene is over (replace with actual logic)
        yield return new WaitForSeconds(35f); // Placeholder, replace with actual cutscene logic

        // Now load the next scene (DMsuitors)
        AsyncOperation asyncTargetSceneLoad = SceneManager.LoadSceneAsync(targetSceneName);
        while (!asyncTargetSceneLoad.isDone)
        {
            yield return null;
        }

        // Optionally, unload the cutscene scene to free up resources
        SceneManager.UnloadSceneAsync(cutsceneSceneName);

        // Restore the audio and game objects
        RestoreOtherSceneAudio();
        RestoreOtherSceneObjects();

        // Set the player's position in the new scene
        PositionPlayerAndCamera();
    }

    private void StoreOtherSceneElements()
    {
        // Get all audio sources in the other scenes
        otherSceneAudioSources = FindObjectsOfType<AudioSource>();
        // Get all game objects in the other scenes (you can refine this by scene or tag)
        otherSceneObjects = GameObject.FindGameObjectsWithTag("GameObject");
    }

    private void MuteOtherSceneAudio()
    {
        // Mute all audio sources
        foreach (var audioSource in otherSceneAudioSources)
        {
            audioSource.mute = true;
        }
    }

    private void DisableOtherSceneObjects()
    {
        // Disable all other game objects to prevent interference
        foreach (var gameObject in otherSceneObjects)
        {
            gameObject.SetActive(false);
        }
    }

    private void RestoreOtherSceneAudio()
    {
        // Restore the audio settings for the previous scene(s)
        foreach (var audioSource in otherSceneAudioSources)
        {
            audioSource.mute = false;
        }
    }

    private void RestoreOtherSceneObjects()
    {
        // Restore the game objects to their original state
        foreach (var gameObject in otherSceneObjects)
        {
            gameObject.SetActive(true);
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
