/*using System.Collections;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "insideDMhouse"; // Scene to load after cutscene
    [SerializeField] private Vector3 playerSpawnPosition; // Position in DMhouse scene
    [SerializeField] private Vector3 cameraPosition; // Camera position in DMhouse scene
    [SerializeField] private float cutsceneDuration = 5f; // Duration of cutscene in seconds

    
    private void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    private IEnumerator PlayCutscene()
    {
        // Wait for cutscene duration
        yield return new WaitForSeconds(cutsceneDuration);

        // Transition to the next scene
        SceneController.instance.LoadSpecificScene(nextSceneName, playerSpawnPosition, cameraPosition);
    }
}*/
using System.Collections;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "insideDMhouse"; // Scene to load after cutscene
    [SerializeField] private Vector3 playerSpawnPosition; // Position in DMhouse scene
    [SerializeField] private Vector3 cameraPosition; // Camera position in DMhouse scene
    [SerializeField] private float cutsceneDuration = 5f; // Duration of cutscene in seconds

    private void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    private IEnumerator PlayCutscene()
    {
        // Wait for cutscene duration
        yield return new WaitForSeconds(cutsceneDuration);

        // Check if SceneController.instance is valid
        if (SceneController.instance != null)
        {
            // Transition to the next scene
            SceneController.instance.LoadSpecificScene(nextSceneName, playerSpawnPosition, cameraPosition);
        }
        else
        {
            Debug.LogError("SceneController.instance is null. Ensure SceneController exists in the scene.");
        }
    }
}
