using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToInsideDMHouse : MonoBehaviour
{
    [SerializeField] private string cutsceneSceneName = "PasokCompound"; // Cutscene scene name
    [SerializeField] private string targetSceneName = "insideDMhouse"; // Final target scene after cutscene
    [SerializeField] private Vector3 playerSpawnPosition; // Player spawn position in InsideDMHouse
    [SerializeField] private Vector3 cameraPosition; // Camera position in InsideDMHouse
    [SerializeField] private GameObject arrowButton; // The button to trigger the scene change
    [SerializeField] private string playerSortingLayerName = "PlayerLayer"; // Desired sorting layer for player in insideDMhouse scene

    private bool isCutscenePlayed = false;

    private void Start()
    {
        // Ensure the button is visible when the game starts
        if (arrowButton != null)
        {
            arrowButton.SetActive(true);
        }
    }

    private void Update()
    {
        // Handle the button click (mouse or touch input)
        if (arrowButton != null && Input.GetMouseButtonDown(0)) // Mouse or touch input
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D clickedCollider = Physics2D.OverlapPoint(mousePosition);

            if (clickedCollider != null && clickedCollider.gameObject == arrowButton && !isCutscenePlayed)
            {
                Debug.Log("Arrow Button Clicked: Playing cutscene and loading InsideDMHouse");

                // Start the cutscene and scene transition
                StartCoroutine(PlayCutsceneThenLoadScene());
            }
        }
    }

    private IEnumerator PlayCutsceneThenLoadScene()
    {
        // Play the cutscene scene
        SceneController.instance.LoadSpecificScene(cutsceneSceneName, playerSpawnPosition, cameraPosition);

        // Wait for the cutscene to finish
        yield return new WaitForSeconds(5f); // Adjust this duration as needed

        // Load the target scene (InsideDMHouse)
        SceneController.instance.LoadSpecificScene(targetSceneName, playerSpawnPosition, cameraPosition);

        // Register a callback to apply sorting layer once the scene is fully loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Callback method to handle sorting layer after the scene has loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetSceneName)
        {
            // Find the player object and set its sorting layer
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
                if (playerRenderer != null)
                {
                    playerRenderer.sortingLayerName = playerSortingLayerName;
                }
            }

            // Unsubscribe from the event to avoid repeated calls
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
