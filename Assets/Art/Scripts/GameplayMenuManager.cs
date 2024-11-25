using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class GameplayMenuManager : MonoBehaviour
{
    public Button menuicon;
    public GameObject menuPanel; 
    public GameObject audioTab; 
    public Button audiobtn;
    public Button achievementbtn;
    public Button languagebtn;
    public GameObject achievementTab;
    public GameObject languageTab;
    public GameObject modalnotif; 
    public Button saveandquitbtn;
    public Button yellowbtn;
    public Button redbtn;
    public Button exitbtn;

    private string currentScene;
    private float progress;

    private List<string> chapter1Scenes = new List<string> 
    { 
        "ForestScene", "RiverScene", "VillageScene", "LiwaywayScene", "CassavaFieldsScene", "DMhouse", "InsideDMHouse"
    };
    
    private List<string> chapter2Scenes = new List<string>
    {
        "DMsuitors", "IlogScene"
    };

    private CinemachineVirtualCamera cinemachineCamera;

    private static GameplayMenuManager instance;

     private void Awake()
    {
        // Ensure only one instance exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);  // Destroy duplicate instances
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);  // Persist this object across scenes
    }
    private void Start()
    {
        // Hide menu and modal panels at start
        menuPanel.SetActive(false);
        modalnotif.SetActive(false);

        // Show audioTab content by default
        ShowOnlyAudioTab();

        // Button listeners
        menuicon.onClick.AddListener(ToggleMenu);
        saveandquitbtn.onClick.AddListener(OpenModal);
        yellowbtn.onClick.AddListener(SaveAndQuit);
        redbtn.onClick.AddListener(CloseModal);
        exitbtn.onClick.AddListener(CloseMenu);

        // Tab toggle listeners
        audiobtn.onClick.AddListener(ShowOnlyAudioTab);
        achievementbtn.onClick.AddListener(ShowOnlyAchievementTab);
        languagebtn.onClick.AddListener(ShowOnlyLanguageTab);

        InitializeCamera();
    }

    private void InitializeCamera()
    {
        // Locate or create a Cinemachine virtual camera
        cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
        if (cinemachineCamera == null)
        {
            GameObject cameraObject = new GameObject("CinemachineCamera");
            cinemachineCamera = cameraObject.AddComponent<CinemachineVirtualCamera>();
        }

        // Find player and set camera to follow
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            cinemachineCamera.Follow = player.transform;
            cinemachineCamera.LookAt = player.transform;
        }
    }

    private void ToggleMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        if (menuPanel.activeSelf)
        {
            ShowOnlyAudioTab(); // Show audio tab content by default when menu opens
        }

        audiobtn.gameObject.SetActive(true);
        achievementbtn.gameObject.SetActive(true);
        languagebtn.gameObject.SetActive(true);
    }

    // Show only the audio tab content
    private void ShowOnlyAudioTab()
    {
        audioTab.SetActive(true);
        achievementTab.SetActive(false);
        languageTab.SetActive(false);
    }

    // Show only the achievement tab content
    private void ShowOnlyAchievementTab()
    {
        audioTab.SetActive(false);
        achievementTab.SetActive(true);
        languageTab.SetActive(false);
    }

    // Show only the language tab content
    private void ShowOnlyLanguageTab()
    {
        audioTab.SetActive(false);
        achievementTab.SetActive(false);
        languageTab.SetActive(true);
    }

    // Open the modal confirmation
    private void OpenModal()
    {
        modalnotif.SetActive(true);
    }

    // Close the modal confirmation
    private void CloseModal()
    {
        modalnotif.SetActive(false);
    }

    // Close the menu
    private void CloseMenu()
    {
        menuPanel.SetActive(false);
    }

    private void SaveAndQuit()
    {
        // Get the current scene and calculate the progress
        currentScene = SceneManager.GetActiveScene().name;
        SaveProgress();
        modalnotif.SetActive(false);

        // Go back to the home screen after saving
        SceneManager.LoadScene("Homescreen");
    }

    private void SaveProgress()
    {
        // Get the current scene
        currentScene = SceneManager.GetActiveScene().name;

        // Determine progress for Chapter 1 or Chapter 2
        if (chapter1Scenes.Contains(currentScene))
        {
            int sceneIndex = chapter1Scenes.IndexOf(currentScene);
            progress = ((float)(sceneIndex + 1) / chapter1Scenes.Count) * 100f;
            PlayerPrefs.SetFloat("Chapter1Progress", progress);
            PlayerPrefs.SetString("LastSavedSceneCh1", currentScene);
        }
        else if (chapter2Scenes.Contains(currentScene))
        {
            int sceneIndex = chapter2Scenes.IndexOf(currentScene);
            progress = ((float)(sceneIndex + 1) / chapter2Scenes.Count) * 100f;
            PlayerPrefs.SetFloat("Chapter2Progress", progress);
            PlayerPrefs.SetString("LastSavedSceneCh2", currentScene);
        }

        PlayerPrefs.Save();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ensure camera follows player after loading a saved scene
        InitializeCamera();
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
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class GameplayMenuManager : MonoBehaviour
{
    public Button menuicon;
    public GameObject menuPanel;
    public GameObject audioTab;
    public Button audiobtn;
    public Button achievementbtn;
    public Button languagebtn;
    public GameObject achievementTab;
    public GameObject languageTab;
    public GameObject modalnotif;
    public Button saveandquitbtn;
    public Button yellowbtn;
    public Button redbtn;
    public Button exitbtn;

    public GameObject alonAchievementStamp; // Add reference to Alon achievement stamp

    private string currentScene;
    private float progress;

    private List<string> chapter1Scenes = new List<string>
    {
        "ForestScene", "RiverScene", "VillageScene", "LiwaywayScene", "CassavaFieldsScene", "DMhouse", "InsideDMHouse"
    };

    private CinemachineVirtualCamera cinemachineCamera;

    private void Start()
    {
        // Hide menu and modal panels at start
        menuPanel.SetActive(false);
        modalnotif.SetActive(false);

        // Show audioTab content by default
        ShowOnlyAudioTab();

        // Button listeners
        menuicon.onClick.AddListener(ToggleMenu);
        saveandquitbtn.onClick.AddListener(OpenModal);
        yellowbtn.onClick.AddListener(SaveAndQuit);
        redbtn.onClick.AddListener(CloseModal);
        exitbtn.onClick.AddListener(CloseMenu);

        // Tab toggle listeners
        audiobtn.onClick.AddListener(ShowOnlyAudioTab);
        achievementbtn.onClick.AddListener(ShowOnlyAchievementTab);
        languagebtn.onClick.AddListener(ShowOnlyLanguageTab);

        // Initialize Camera
        InitializeCamera();

        // Ensure achievement stamps are hidden initially
        alonAchievementStamp.SetActive(false);
    }

    private void InitializeCamera()
    {
        // Locate or create a Cinemachine virtual camera
        cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
        if (cinemachineCamera == null)
        {
            GameObject cameraObject = new GameObject("CinemachineCamera");
            cinemachineCamera = cameraObject.AddComponent<CinemachineVirtualCamera>();
        }

        // Find player and set camera to follow
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            cinemachineCamera.Follow = player.transform;
            cinemachineCamera.LookAt = player.transform;
        }
    }

    private void ToggleMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        if (menuPanel.activeSelf)
        {
            ShowOnlyAudioTab(); // Show audio tab content by default when menu opens
        }

        audiobtn.gameObject.SetActive(true);
        achievementbtn.gameObject.SetActive(true);
        languagebtn.gameObject.SetActive(true);
    }

    // Show only the audio tab content
    private void ShowOnlyAudioTab()
    {
        audioTab.SetActive(true);
        achievementTab.SetActive(false);
        languageTab.SetActive(false);
    }

    // Show only the achievement tab content
    private void ShowOnlyAchievementTab()
    {
        audioTab.SetActive(false);
        achievementTab.SetActive(true);
        languageTab.SetActive(false);
    }

    // Show only the language tab content
    private void ShowOnlyLanguageTab()
    {
        audioTab.SetActive(false);
        achievementTab.SetActive(false);
        languageTab.SetActive(true);
    }

    // Open the modal confirmation
    private void OpenModal()
    {
        modalnotif.SetActive(true);
    }

    // Close the modal confirmation
    private void CloseModal()
    {
        modalnotif.SetActive(false);
    }

    // Close the menu
    private void CloseMenu()
    {
        menuPanel.SetActive(false);
    }

    private void SaveAndQuit()
    {
        // Get the current scene and calculate the progress
        currentScene = SceneManager.GetActiveScene().name;
        SaveProgress();
        modalnotif.SetActive(false);

        // Go back to the home screen after saving
        SceneManager.LoadScene("Homescreen");
    }

    private void SaveProgress()
    {
        // Calculate progress based on the scene index
        int sceneIndex = chapter1Scenes.IndexOf(currentScene);
        if (sceneIndex != -1)
        {
            progress = ((float)(sceneIndex + 1) / chapter1Scenes.Count) * 100f;
        }

        // Save progress and current scene to PlayerPrefs
        PlayerPrefs.SetFloat("Chapter1Progress", progress);
        PlayerPrefs.SetString("LastSavedScene", currentScene);
        PlayerPrefs.Save();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ensure camera follows player after loading a saved scene
        InitializeCamera();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Method to unlock and show the achievement when talking to Alon
    public void UnlockAlonAchievement()
    {
        alonAchievementStamp.SetActive(true); // Show stamp when Alon is talked to
        PlayerPrefs.SetInt("AlonAchievement", 1); // Save achievement status
        PlayerPrefs.Save();
    }
}2nd script*/

