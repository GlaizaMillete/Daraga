using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToInsideDMHouse : MonoBehaviour
{
    [SerializeField] private string cutsceneSceneName = "PasokCompound"; // Cutscene scene name
    [SerializeField] private string targetSceneName = "insideDMhouse"; // Final target scene after cutscene
    [SerializeField] private Vector3 playerSpawnPosition; // Player spawn position in InsideDMHouse
    [SerializeField] private Vector3 cameraPosition; // Camera position in InsideDMHouse
    [SerializeField] private Button arrowButton; // Reference to the Button component
    [SerializeField] private string playerSortingLayerName = "PlayerLayer"; // Sorting layer for player in insideDMhouse scene
    [SerializeField] private GameObject player; // Reference to the player GameObject
    [SerializeField] private RectTransform buttonFixedPosition; // The fixed position in UI space

    private Vector3 playerInitialPosition; // Store player's position
    private bool isCutscenePlayed = false;

    private void Start()
    {
        if (arrowButton != null)
        {
            arrowButton.onClick.AddListener(OnArrowInsideHouseButtonClick);
            arrowButton.gameObject.SetActive(false); // Initially hide the button
        }
        
        if (buttonFixedPosition != null)
        {
            arrowButton.GetComponent<RectTransform>().anchoredPosition = buttonFixedPosition.anchoredPosition;
        }
    }

    private void OnDestroy()
    {
        if (arrowButton != null)
        {
            arrowButton.onClick.RemoveListener(OnArrowInsideHouseButtonClick);
        }
    }

    private void OnArrowInsideHouseButtonClick()
    {
        if (player != null)
        {
            playerInitialPosition = player.transform.position; // Store player position
        }

        if (!isCutscenePlayed)
        {
            Debug.Log("Arrow Button Clicked: Playing cutscene and loading InsideDMHouse");
            StartCoroutine(PlayCutsceneThenLoadScene());
        }
    }

    private IEnumerator PlayCutsceneThenLoadScene()
    {
        isCutscenePlayed = true;

        // Play the cutscene scene
        SceneController.instance.LoadSpecificScene(cutsceneSceneName, playerSpawnPosition, cameraPosition);

        // Wait for the cutscene to finish
        yield return new WaitForSeconds(5f); // Adjust duration as needed

        // Load the target scene (InsideDMHouse)
        SceneController.instance.LoadSpecificScene(targetSceneName, playerSpawnPosition, cameraPosition);

        // Register callback to handle sorting layer in the new scene
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetSceneName)
        {
            SetPlayerSortingLayer();
            SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from event
        }
    }

    private void SetPlayerSortingLayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
            if (playerRenderer != null)
            {
                playerRenderer.sortingLayerName = playerSortingLayerName;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && arrowButton != null)
        {
            arrowButton.gameObject.SetActive(true); // Show the button
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && arrowButton != null)
        {
            arrowButton.gameObject.SetActive(false); // Hide the button
        }
    }
}
