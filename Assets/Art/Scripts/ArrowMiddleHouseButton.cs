using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArrowMiddleHouseButton : MonoBehaviour
{
    [SerializeField] private string cutsceneSceneName = "ManliligawniDM"; // Name of the cutscene scene to play
    [SerializeField] private GameObject player; // Reference to the player GameObject
    [SerializeField] private GameObject middlehouse; // Reference to the middlehouse GameObject
    [SerializeField] private GameObject arrowMakusog; // Reference to the arrowmakusog button
    [SerializeField] private GameObject arrowDM; // Reference to the arrowdm button
    [SerializeField] private float offsetY = 50f; // Vertical offset for placing the button at the top of middlehouse
    
    private Vector3 playerInitialPosition; // Store player's position
    private RectTransform buttonRectTransform; // Reference to the button's RectTransform

    private void Start()
    {
        // Ensure references are set and objects exist
        if (arrowMakusog != null) arrowMakusog.SetActive(false);
        if (arrowDM != null) arrowDM.SetActive(false);

        // Get the RectTransform of this button
        buttonRectTransform = GetComponent<RectTransform>();

        // Add click listener for the ArrowMiddleHouse button
        GetComponent<Button>().onClick.AddListener(OnArrowMiddleHouseClick);
        
        // Ensure player and buttons persist across scenes
        if (player != null) DontDestroyOnLoad(player);
        if (arrowMakusog != null) DontDestroyOnLoad(arrowMakusog);
        if (arrowDM != null) DontDestroyOnLoad(arrowDM);
        
        // Subscribe to scene load event to handle button activation
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        if (middlehouse == null || buttonRectTransform == null) return;

        // Update the button position to align with the middlehouse object in world space
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(middlehouse.transform.position);
        
        // Offset the position upwards by offsetY (in screen space) to place it at the top
        screenPosition.y += offsetY;
        buttonRectTransform.position = screenPosition;
    }

    private void OnArrowMiddleHouseClick()
    {
        // Store the player's current position
        if (player != null)
        {
            playerInitialPosition = player.transform.position;
        }

        // Load the cutscene
        StartCoroutine(PlayCutsceneAndReturn());
    }

    private IEnumerator PlayCutsceneAndReturn()
    {
        // Load the cutscene scene
        SceneController.instance.LoadSpecificScene(cutsceneSceneName, Vector3.zero, Vector3.zero);

        // Wait for the duration of the cutscene
        yield return new WaitForSeconds(5f); // Adjust time based on cutscene duration

        // Return to the insideDMhouse scene
        SceneManager.LoadScene("insideDMhouse");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is insideDMhouse
        if (scene.name == "insideDMhouse")
        {
            // Restore the player's position and show the arrow buttons
            if (player != null)
            {
                player.transform.position = playerInitialPosition;
            }
            if (arrowMakusog != null) arrowMakusog.SetActive(true);
            if (arrowDM != null) arrowDM.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
