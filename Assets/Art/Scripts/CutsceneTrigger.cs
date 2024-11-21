using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private string cutsceneSceneName = "PasokCompoundScene"; // Cutscene scene name
    [SerializeField] private Vector3 cutscenePlayerSpawnPosition; // Player spawn position in cutscene
    [SerializeField] private Vector3 cutsceneCameraPosition; // Camera position in cutscene

    [SerializeField] private string targetSceneName = "insideDMhouse"; // Final target scene after cutscene
    [SerializeField] private Vector3 playerSpawnPosition; // Player spawn position in DMhouse
    [SerializeField] private Vector3 cameraPosition; // Camera position in DMhouse
    [SerializeField] private float cutsceneDuration = 5f; // Duration of cutscene in seconds

    private bool cutscenePlayed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !cutscenePlayed)
        {
            cutscenePlayed = true;
            StartCoroutine(PlayCutsceneThenLoadScene());
        }
    }

    private IEnumerator PlayCutsceneThenLoadScene()
    {
        // Load the cutscene scene
        SceneController.instance.LoadSpecificScene(cutsceneSceneName, cutscenePlayerSpawnPosition, cutsceneCameraPosition);
        
        // Wait for the duration of the cutscene
        yield return new WaitForSeconds(cutsceneDuration);

        // Load the final target scene
        SceneController.instance.LoadSpecificScene(targetSceneName, playerSpawnPosition, cameraPosition);
    }
}
