using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StrangerTrigger : MonoBehaviour
{
    [SerializeField] private string cutsceneSceneName = "StrangerScene";  // Name of the cutscene scene to play
    [SerializeField] private GameObject strangerObject;  // The Stranger GameObject to trigger the cutscene
    [SerializeField] private string currentSceneName = "insideDMhouse";  // Name of the current scene
    
    private bool cutscenePlayed = false;  // Check if the cutscene was already played
    private Vector3 strangerInitialPosition;  // Position where the Stranger object is located
    private SpriteRenderer spriteRenderer;  // To control the visibility of the Stranger GameObject

    private void Awake()
    {
        // Check if the cutscene has already been played by checking PlayerPrefs
        cutscenePlayed = PlayerPrefs.GetInt("StrangerCutscenePlayed", 0) == 1;

        // Get the SpriteRenderer to control visibility
        spriteRenderer = strangerObject.GetComponent<SpriteRenderer>();
        
        // Store the initial position of the Stranger object
        strangerInitialPosition = strangerObject.transform.position;
        
        // Ensure Stranger object is visible at the start
        if (spriteRenderer != null)
        {
            Color currentColor = spriteRenderer.color;
            currentColor.a = 1f;  // Make sure it's visible
            spriteRenderer.color = currentColor;
        }

        // If the cutscene has already been played, hide the Stranger object
        if (cutscenePlayed)
        {
            strangerObject.SetActive(false);
        }
        else
        {
            strangerObject.SetActive(true); // Show the Stranger initially
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Trigger the cutscene once when the player enters the trigger zone and if it hasn't been played yet
        if (collision.CompareTag("Player") && !cutscenePlayed)
        {
            cutscenePlayed = true;  // Set flag to prevent multiple triggers
            PlayerPrefs.SetInt("StrangerCutscenePlayed", 1);  // Mark the cutscene as played
            StartCoroutine(PlayCutsceneThenHideStranger());
        }
    }

    private void OnEnable()
    {
        // Ensure that when the player re-enters the scene, Stranger is hidden if the cutscene was played
        if (cutscenePlayed)
        {
            strangerObject.SetActive(false);  // Hide the Stranger object after the cutscene
        }
    }

    private IEnumerator PlayCutsceneThenHideStranger()
    {
        // Optionally, you can fade in or show the Stranger object if desired (already visible by default)
        yield return null;

        // Assuming playerPosition and cameraPosition are the player's current positions
        Vector3 playerPosition = GameObject.FindWithTag("Player").transform.position;
        Vector3 cameraPosition = Camera.main.transform.position;

        // Play the Stranger cutscene (SceneController handles the loading of the cutscene)
        SceneController.instance.LoadSpecificScene(cutsceneSceneName, playerPosition, cameraPosition);

        // Wait for the duration of the cutscene
        yield return new WaitForSeconds(5f);  // Adjust this duration to match your cutscene length

        // After the cutscene finishes, hide the Stranger object
        strangerObject.SetActive(false);  // Hide the Stranger object when the player returns
    }
}
