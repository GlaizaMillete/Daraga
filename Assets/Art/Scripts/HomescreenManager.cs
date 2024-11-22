using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.UI;

public class HomeScreenManager : MonoBehaviour
{
    public Button continueButton;
    public Button chapter1Button;
    public Button chapter2Button; // Button for Chapter 2
    public Text chapter1ProgressText;
    public Text chapter2ProgressText; // Progress text for Chapter 2
    public GameObject continuePanel;  // Panel to show when continue button is clicked

    private void Start()
    {
        LoadProgress();

        // Add listeners to the buttons
        continueButton.onClick.AddListener(ShowContinueContent);
        chapter1Button.onClick.AddListener(LoadChapter1Scene);
        chapter2Button.onClick.AddListener(LoadChapter2Scene); // Listener for Chapter 2 button
    }

   private void LoadProgress()
    {
        // Load Chapter 1 progress
        float chapter1Progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);
        chapter1ProgressText.text = "Progress: " + chapter1Progress.ToString("F1") + "%";

        if (chapter1Progress > 0)
            continueButton.interactable = true;

        // Load Chapter 2 progress
        float chapter2Progress = PlayerPrefs.GetFloat("Chapter2Progress", 0f);
        chapter2ProgressText.text = "Progress: " + chapter2Progress.ToString("F1") + "%";

        if (chapter2Progress > 0)
            chapter2Button.interactable = true;
    }

    private void ShowContinueContent()
    {
        if (continuePanel != null)
        {
            continuePanel.SetActive(true);  // Show the continue panel
        }
    }

    private void LoadChapter1Scene()
    {
        string lastSavedScene = PlayerPrefs.GetString("LastSavedScene_Ch1", "ForestScene");
        SceneManager.LoadScene(lastSavedScene);
    }

    private void LoadChapter2Scene()
    {
        // Load the last saved scene for Chapter 2
        string lastSavedScene = PlayerPrefs.GetString("LastSavedSceneCh2", "DMsuitors");
        SceneManager.LoadScene(lastSavedScene);
    }

    // Called when returning to the home screen or saving progress
    public void SaveChapterProgress(string chapter, string currentScene, float progress)
    {
        if (chapter == "Ch1")
        {
            PlayerPrefs.SetFloat("Chapter1Progress", progress);
            PlayerPrefs.SetString("LastSavedScene_Ch1", currentScene);
        }
        else if (chapter == "Ch2")
        {
            PlayerPrefs.SetFloat("Chapter2Progress", progress);
            PlayerPrefs.SetString("LastSavedScene_Ch2", currentScene);
        }
        PlayerPrefs.Save();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        DestroyCinemachineClones();
        FollowPlayerWithCinemachine();
    }

    private void DestroyCinemachineClones()
    {
        CinemachineVirtualCamera[] virtualCameras = FindObjectsOfType<CinemachineVirtualCamera>();
        foreach (CinemachineVirtualCamera vCam in virtualCameras)
        {
            if (vCam.gameObject != Camera.main.gameObject)
            {
                Destroy(vCam.gameObject);
            }
        }
    }

    private void FollowPlayerWithCinemachine()
    {
        CinemachineVirtualCamera cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
        if (cinemachineCamera != null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                cinemachineCamera.Follow = player.transform;
                cinemachineCamera.LookAt = player.transform;
            }
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
