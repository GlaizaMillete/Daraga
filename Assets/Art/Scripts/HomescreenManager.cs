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
        float chapter1Progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);
        chapter1Button.interactable = chapter1Progress > 0;

        float chapter2Progress = PlayerPrefs.GetFloat("Chapter2Progress", 0f);
        chapter2Button.interactable = chapter1Progress >= 100f && chapter2Progress > 0;
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
        string lastSavedScene = PlayerPrefs.GetString("LastSavedScene_Ch1", "ForestScene"); // Default to ForestScene
        SceneManager.LoadScene(lastSavedScene);
    }

    private void LoadChapter2Scene()
    {
        string lastSavedScene = PlayerPrefs.GetString("LastSavedSceneCh2", "DMsuitors"); // Default to DMsuitors
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

    // Saving specific progress for each scene
    public void SaveChapter1SceneProgress(string currentScene)
    {
        // Scenes for Chapter 1
        string[] chapter1Scenes = {
            "ForestScene", "RiverScene", "VillageScene", "LiwaywayHouse", "CassavaFields", "DMhouse", "insideDMhouse"
        };

        if (System.Array.Exists(chapter1Scenes, scene => scene == currentScene))
        {
            float chapter1Progress = GetChapter1Progress(currentScene);
            SaveChapterProgress("Ch1", currentScene, chapter1Progress);

            // Check if the last scene in Chapter 1 ('insideDMhouse') is completed
            if (currentScene == "insideDMhouse")
            {
                // Unlock Chapter 2 after completing Chapter 1
                chapter2Button.interactable = true;
            }
        }
    }

    public void SaveChapter2SceneProgress(string currentScene)
    {
        // Scenes for Chapter 2
        string[] chapter2Scenes = { "DMsuitors", "IlogScene" };

        if (System.Array.Exists(chapter2Scenes, scene => scene == currentScene))
        {
            float chapter2Progress = GetChapter2Progress(currentScene);
            SaveChapterProgress("Ch2", currentScene, chapter2Progress);
        }
    }

   private float GetChapter1Progress(string sceneName)
    {
        string[] chapter1Scenes = { "ForestScene", "RiverScene", "VillageScene", "LiwaywayHouse", "CassavaFields", "DMhouse", "insideDMhouse" };
        int completedScenes = 0;

        foreach (string scene in chapter1Scenes)
        {
            if (PlayerPrefs.HasKey(scene))
                completedScenes++;
        }

        return (completedScenes / (float)chapter1Scenes.Length) * 100f;
    }

    public void MarkSceneAsCompleted(string sceneName)
    {
        PlayerPrefs.SetInt(sceneName, 1);
        PlayerPrefs.Save();
    }

    private float GetChapter2Progress(string sceneName)
    {
        // Custom logic for Chapter 2 progress based on scenes
        // For simplicity, we're returning a fixed value, you can implement your own calculation
        return 100f;
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
