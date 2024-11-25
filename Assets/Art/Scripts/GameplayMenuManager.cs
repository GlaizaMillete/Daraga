using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class GameplayMenuManager : MonoBehaviour
{
    // Menu UI Elements
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

    public AchievementManager1 achievementManager; // Reference to the AchievementManager

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

    private void ShowOnlyAudioTab()
    {
        audioTab.SetActive(true);
        achievementTab.SetActive(false);
        languageTab.SetActive(false);
    }

    private void ShowOnlyAchievementTab()
{
    audioTab.SetActive(false);
    achievementTab.SetActive(true);
    languageTab.SetActive(false);

    if (achievementManager != null)
    {
        achievementManager.LoadAchievements();
    }
    else
    {
        Debug.LogError("AchievementManager not assigned in GameplayMenuManager!");
    }
}

    private void ShowOnlyLanguageTab()
    {
        audioTab.SetActive(false);
        achievementTab.SetActive(false);
        languageTab.SetActive(true);
    }

    private void OpenModal()
    {
        modalnotif.SetActive(true);
    }

    private void CloseModal()
    {
        modalnotif.SetActive(false);
    }

    private void CloseMenu()
    {
        menuPanel.SetActive(false);
    }

    private void SaveAndQuit()
    {
        // Get the current scene and calculate the progress
        currentScene = SceneManager.GetActiveScene().name;

        SaveProgress();

        // Update achievements based on progress
        UpdateAchievements();

        modalnotif.SetActive(false);

        // Save achievements before quitting
        if (achievementManager != null)
        {
            achievementManager.SaveAchievements();
        }

        // Go back to the home screen after saving
        SceneManager.LoadScene("Homescreen");
    }

    private void SaveProgress()
    {
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

    private void UpdateAchievements()
{
    // Find the GameObject in the scene and call CompleteQuest with its name or ID
    GameObject questGameObject = GameObject.Find("CassavaQuest"); // Example: Find the GameObject by name

    if (questGameObject != null)
    {
        // Pass the name of the GameObject (or another identifying string) to CompleteQuest
        achievementManager.CompleteQuest(questGameObject.name); 
    }
    else
    {
        Debug.LogWarning("Quest GameObject not found in the scene.");
    }
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
        HideAllAchievementStamps();
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

    private void HideAllAchievementStamps()
    {
        alonAchievementStamp.SetActive(false);
        tilapiaAchievementStamp.SetActive(false);
        cphouseAchievementStamp.SetActive(false);
        riddleTALIMAchievementStamp.SetActive(false);
        riddleMARINAAchievementStamp.SetActive(false);
        riddleMARISAachievementStamp.SetActive(false);
        riddleBAGWISAchievementStamp.SetActive(false);
        riddleDALISAYAchievementStamp.SetActive(false);
        helpliwaywayAchievementStamp.SetActive(false);
        magayonAchievementStamp.SetActive(false);
        makusogAchievementStamp.SetActive(false);
    }

    // Unlock achievement method
    public void UnlockAchievement(string achievementTag, GameObject parentObject)
{
    if (string.IsNullOrEmpty(achievementTag))
    {
        Debug.LogError("Received empty or null Achievement Tag in UnlockAchievement.");
        return;
    }
    Debug.Log($"Unlocking Achievement: {achievementTag}");

    if (parentObject != null)
    {
        if (!parentObject.activeInHierarchy)
        {
            Debug.LogWarning($"{parentObject.name} is inactive in the hierarchy. The stamp won't be visible.");
        }

        // Adjusted stamp name generation
        string stampName = achievementTag.ToLower().Replace("quest", "") + "Stamp";
        GameObject stamp = parentObject.transform.Find(stampName)?.gameObject;

        if (stamp != null)
        {
            Debug.Log($"Stamp found: {stamp.name}, activating...");
            stamp.SetActive(true);
        }
        else
        {
            Debug.LogError($"Stamp '{stampName}' not found under parent: {parentObject.name}");
        }
    }
    else
    {
        Debug.LogError("Parent object is null!");
    }

    // Save the achievement status
    PlayerPrefs.SetInt(achievementTag, 1);
    PlayerPrefs.Save();
}
   
    private string GetParentObjectName(string achievementTag)
    {
       
        if (achievementTag == "AlonQuest")
        {
            return "alon";  
        }
        else if (achievementTag == "TilapiaQuest")
        {
            return "tilapia";  
        }

        
        return null;
    }

    // Call this method when the player completes a quest (for example, after interacting with an NPC)
    public void CheckQuestCompletion(string questName)
    {
        // You will need to get the parentObject based on the questName
        GameObject parentObject = GetParentObjectFromQuestName(questName);

        if (string.IsNullOrEmpty(questName))
        {
            Debug.LogWarning("Quest name is empty or null!");
            return;
        }

        if (parentObject == null)
        {
            Debug.LogWarning($"No parent object found for {questName}");
            return;
        }

        // Unlock the achievement by passing both the achievementTag and parentObject
        if (questName == "AlonQuest")
        {
            UnlockAchievement("AlonQuest", parentObject);
        }
        else if (questName == "TilapiaQuest")
        {
            UnlockAchievement("TilapiaQuest", parentObject);
        }
    }

    // Helper method to determine the parent object based on the quest name
    private GameObject GetParentObjectFromQuestName(string questName)
    {
        // Example: Map the quest name to a specific GameObject (you can modify this to suit your project)
        if (questName == "AlonQuest")
        {
            return GameObject.Find("AlonQuestParentObject");  // Replace with your actual GameObject name
        }
        else if (questName == "TilapiaQuest")
        {
            return GameObject.Find("TilapiaQuestParentObject");  // Replace with your actual GameObject name
        }

        return null;  // Return null if no valid quest name is found
    }
}
