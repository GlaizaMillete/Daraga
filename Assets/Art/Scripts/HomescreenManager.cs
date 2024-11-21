using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.UI;

public class HomeScreenManager : MonoBehaviour
{
    public Button continueButton;
    public Button chapter1Button;
    public Text chapter1ProgressText;
    public GameObject continuePanel;  // Panel to show when continue button is clicked

    private void Start()
    {
        LoadProgress();

        // Add listener to the continue button (only to show content)
        continueButton.onClick.AddListener(ShowContinueContent);

        // Add listener to the chapter 1 button to load the scene
        chapter1Button.onClick.AddListener(LoadChapter1Scene);
    }

    private void LoadProgress()
    {
        // Load the saved progress from PlayerPrefs
        float progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);

        // Update the Chapter 1 progress text
        chapter1ProgressText.text = "Progress: " + progress.ToString("F1") + "%";

        // Enable the continue button if progress exists
        if (progress > 0)
        {
            continueButton.interactable = true;
        }
    }

    // This method will only show the content, not load the scene or save progress
    private void ShowContinueContent()
    {
        if (continuePanel != null)
        {
            continuePanel.SetActive(true);  // Show the panel with the saved progress or options
        }
    }

    // This method will load the saved scene and progress
    private void LoadChapter1Scene()
    {
        // Load the last saved scene from PlayerPrefs
        string lastSavedScene = PlayerPrefs.GetString("LastSavedScene", "ForestScene");

        // Load the saved scene to continue the game
        SceneManager.LoadScene(lastSavedScene);
    }

    // Called when the scene has finished loading
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find and destroy any clones of the Cinemachine camera
        DestroyCinemachineClones();

        // Find the main Cinemachine camera and ensure it follows the player
        FollowPlayerWithCinemachine();
    }

    private void DestroyCinemachineClones()
    {
        // Find all GameObjects with a Cinemachine Virtual Camera
        CinemachineVirtualCamera[] virtualCameras = FindObjectsOfType<CinemachineVirtualCamera>();

        // Destroy any duplicate cameras that are not the main one
        foreach (CinemachineVirtualCamera vCam in virtualCameras)
        {
            if (vCam.gameObject != Camera.main.gameObject)  // Ensure it's not the main camera
            {
                Destroy(vCam.gameObject);  // Destroy the clone
            }
        }
    }

    private void FollowPlayerWithCinemachine()
    {
        // Find the main Cinemachine Virtual Camera
        CinemachineVirtualCamera cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();

        if (cinemachineCamera != null)
        {
            // Find the player GameObject
            GameObject player = GameObject.FindWithTag("Player");

            if (player != null)
            {
                // Set the Follow and LookAt targets of the Cinemachine camera to the player
                cinemachineCamera.Follow = player.transform;
                cinemachineCamera.LookAt = player.transform;
            }
        }
    }

    private void OnEnable()
    {
        // Add the scene loaded listener
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Remove the scene loaded listener
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
