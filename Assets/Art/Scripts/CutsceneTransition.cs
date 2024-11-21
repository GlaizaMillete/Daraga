using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTransition : MonoBehaviour
{
    public string cutsceneScene = "PasokCompound";  // Name of the cutscene scene
    public string destinationScene = "DMhouse";  // Name of the destination scene
    public GameObject triggerObject;  // The object that triggers the transition (e.g., arrow button)
    public Vector3 spawnPositionInDestination;  // Position to spawn player in the destination scene

    private bool isTransitioning = false;

    private void Start()
    {
        // Ensure the trigger object is active
        if (triggerObject != null)
        {
            triggerObject.SetActive(true);
        }
    }

    private void Update()
    {
        // Check for user input to activate the transition
        if (triggerObject != null && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D clickedCollider = Physics2D.OverlapPoint(mousePosition);

            // Check if the trigger object is clicked
            if (clickedCollider != null && clickedCollider.gameObject == triggerObject && !isTransitioning)
            {
                StartCoroutine(PlayCutsceneAndTransition());
            }
        }
    }

    private IEnumerator PlayCutsceneAndTransition()
    {
        isTransitioning = true;  // Prevent re-triggering

        // Save player position for the next scene
        PlayerPrefs.SetFloat("PlayerSpawnX", spawnPositionInDestination.x);
        PlayerPrefs.SetFloat("PlayerSpawnY", spawnPositionInDestination.y);
        PlayerPrefs.SetFloat("PlayerSpawnZ", spawnPositionInDestination.z);

        // Load the cutscene scene
        SceneManager.LoadScene(cutsceneScene);

        // Wait for the cutscene to finish (adjust delay as needed for cutscene length)
        yield return new WaitForSeconds(5.0f);  // Assuming the cutscene is 5 seconds long

        // Transition to the destination scene
        SceneManager.LoadScene(destinationScene);

        // Reset transition flag after entering the new scene
        isTransitioning = false;
    }
}
