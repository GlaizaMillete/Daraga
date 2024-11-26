/*using System.Collections;
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

    // Achievement tracking
    private bool itemCollected = false;
    private HashSet<string> unlockedAchievements = new HashSet<string>();
    private Dictionary<string, bool> npcInteractions = new Dictionary<string, bool>();

   private void Start()
    {
        // Hide menu and modal panels at start
        menuPanel.SetActive(false);
        modalnotif.SetActive(false);

        // Hide all tab contents initially
        audioTab.SetActive(false);
          // Hide the achievement tab content by default
        achievementTab.SetActive(false);
        languageTab.SetActive(false);

        // Show the audioTab content by default when menu opens
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
        cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
        if (cinemachineCamera == null)
        {
            GameObject cameraObject = new GameObject("CinemachineCamera");
            cinemachineCamera = cameraObject.AddComponent<CinemachineVirtualCamera>();
        }

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
            ShowOnlyAudioTab();
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
        currentScene = SceneManager.GetActiveScene().name;
        SaveProgress();
        modalnotif.SetActive(false);
        SceneManager.LoadScene("Homescreen");
    }

  public void UnlockAchievement(string achievementTag, GameObject parentObject)
    {
        if (string.IsNullOrEmpty(achievementTag) || parentObject == null)
        {
            Debug.LogWarning("Invalid achievement tag or parent object.");
            return;
        }

        Debug.Log($"Achievement Unlocked: {achievementTag} for {parentObject.name}");

        // Show the achievement tab content
        achievementTab.SetActive(true);

        // Additional logic to update the content of the achievement tab can go here
    }



    private void SaveProgress()
    {
        currentScene = SceneManager.GetActiveScene().name;

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

    // Achievement methods
    public void CollectItem()
    {
        itemCollected = true;
        Debug.Log("Item has been collected!");
    }

    public void TalkToNPC(string npcName)
    {
        if (!npcInteractions.ContainsKey(npcName))
        {
            npcInteractions[npcName] = true;
            Debug.Log("Talked to NPC: " + npcName);
        }
        else
        {
            Debug.Log("Already talked to NPC: " + npcName);
        }
    }

    public bool HasTalkedToNPC(string npcName)
    {
        return npcInteractions.ContainsKey(npcName) && npcInteractions[npcName];
    }

    public string GetItemStatus()
    {
        return itemCollected ? "Item Collected" : "This object has not been found";
    }

    public string GetNPCStatus(string npcName)
    {
        return HasTalkedToNPC(npcName) ? "Talked to " + npcName : "Haven't talked to " + npcName;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
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
}*/
/*using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayMenuManager : MonoBehaviour
{
    public static GameplayMenuManager Instance;

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

    // Achievement Stamps
    public GameObject alonStamp, tilapiaStamp, cphouseStamp, riddleTALIMStamp, riddleMARINAStamp;
    public GameObject riddleMARISAStamp, riddleBAGWISStamp, riddleDALISAYStamp, helpliwaywayStamp;
    public GameObject magayonStamp, makusogStamp;

    private List<string> chapter1Scenes = new List<string>
    {
        "ForestScene", "RiverScene", "VillageScene", "LiwaywayScene", "CassavaFieldsScene", "DMhouse", "InsideDMHouse"
    };

    private CinemachineVirtualCamera cinemachineCamera;
    private float progress;

    private void Awake()
    {
        // Singleton pattern to ensure one instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist this object
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate
            return; // Exit initialization for duplicate instance
        }
    }
    private void Start()
    {
        // Add listeners
        menuicon.onClick.AddListener(OpenMenu);
        saveandquitbtn.onClick.AddListener(OpenModal);
        yellowbtn.onClick.AddListener(SaveAllScenesAndQuit);
        redbtn.onClick.AddListener(CloseModal);
        exitbtn.onClick.AddListener(CloseMenu);

        audiobtn.onClick.AddListener(ShowOnlyAudioTab);
        achievementbtn.onClick.AddListener(ShowOnlyAchievementTab);
        languagebtn.onClick.AddListener(ShowOnlyLanguageTab);

        // Initialize systems
        InitializeCamera();
        HideAllAchievementStamps();

         DontDestroyOnLoad(gameObject); // Ensure this instance persists across scenes
    }
   private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void InitializeCamera()
    {
        // Find or create a Cinemachine camera
        cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
        if (cinemachineCamera == null)
        {
            GameObject cameraObject = new GameObject("CinemachineCamera");
            cinemachineCamera = cameraObject.AddComponent<CinemachineVirtualCamera>();
        }

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            cinemachineCamera.Follow = player.transform;
            cinemachineCamera.LookAt = player.transform;
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Homescreen")
        {
            Debug.Log("Homescreen loaded. Skipping menu initialization.");
            return;
        }

        // Reinitialize menu and camera
        menuPanel = GameObject.Find("MenuPanel");
        InitializeCamera();

        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
        else
        {
            Debug.LogError($"MenuPanel not found in scene: {scene.name}");
        }
    }

    private void HideAllAchievementStamps()
    {
        alonStamp.SetActive(false);
        tilapiaStamp.SetActive(false);
        cphouseStamp.SetActive(false);
        riddleTALIMStamp.SetActive(false);
        riddleMARINAStamp.SetActive(false);
        riddleMARISAStamp.SetActive(false);
        riddleBAGWISStamp.SetActive(false);
        riddleDALISAYStamp.SetActive(false);
        helpliwaywayStamp.SetActive(false);
        magayonStamp.SetActive(false);
        makusogStamp.SetActive(false);
    }

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

    private void SaveAllScenesAndQuit()
    {
        foreach (var scene in chapter1Scenes)
        {
            SaveProgress(scene);
        }

        modalnotif.SetActive(false);
        SceneManager.LoadScene("Homescreen");
    }

    private void SaveProgress(string sceneName)
    {
        int sceneIndex = chapter1Scenes.IndexOf(sceneName);
        if (sceneIndex != -1)
        {
            progress = ((float)(sceneIndex + 1) / chapter1Scenes.Count) * 100f;
        }

        PlayerPrefs.SetFloat("Chapter1Progress", progress);
        PlayerPrefs.SetString("LastSavedScene", sceneName);
        PlayerPrefs.Save();
    }

    private void OpenMenu()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(true);
            ShowOnlyAudioTab(); // Default to audio tab
        }
    }

    private void CloseMenu()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }

    private void OpenModal()
    {
        if (modalnotif != null)
        {
            modalnotif.SetActive(true);
        }
    }

    private void CloseModal()
    {
        if (modalnotif != null)
        {
            modalnotif.SetActive(false);
        }
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
        UpdateAchievementStamps();
    }

    private void ShowOnlyLanguageTab()
    {
        audioTab.SetActive(false);
        achievementTab.SetActive(false);
        languageTab.SetActive(true);
    }

    public void UpdateAchievementStamps()
    {
        alonStamp.SetActive(PlayerPrefs.GetInt("AlonQuest", 0) == 1);
        tilapiaStamp.SetActive(PlayerPrefs.GetInt("TilapiaQuest", 0) == 1);
        cphouseStamp.SetActive(PlayerPrefs.GetInt("CPHouseQuest", 0) == 1);
        riddleTALIMStamp.SetActive(PlayerPrefs.GetInt("RiddleTALIM", 0) == 1);
        riddleMARINAStamp.SetActive(PlayerPrefs.GetInt("RiddleMARINA", 0) == 1);
        riddleMARISAStamp.SetActive(PlayerPrefs.GetInt("RiddleMARISA", 0) == 1);
        riddleBAGWISStamp.SetActive(PlayerPrefs.GetInt("RiddleBAGWIS", 0) == 1);
        riddleDALISAYStamp.SetActive(PlayerPrefs.GetInt("RiddleDALISAY", 0) == 1);
        helpliwaywayStamp.SetActive(PlayerPrefs.GetInt("HelpLiwayway", 0) == 1);
        magayonStamp.SetActive(PlayerPrefs.GetInt("MagayonQuest", 0) == 1);
        makusogStamp.SetActive(PlayerPrefs.GetInt("MakusogQuest", 0) == 1);
    }


    private void SaveMenuState()
    {
        PlayerPrefs.SetInt("MenuVisible", menuPanel.activeSelf ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void LoadMenuState()
    {
        if (PlayerPrefs.HasKey("MenuVisible"))
        {
            bool isVisible = PlayerPrefs.GetInt("MenuVisible") == 1;
            menuPanel.SetActive(isVisible);
        }
    }

}*/
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
        currentScene = SceneManager.GetActiveScene().name;
        SaveProgress(currentScene);
        SceneManager.LoadScene("HomeScreen");
    }

    private void SaveProgress(string currentScene)
    {
        float progress;
        string chapterKey, sceneKey;

        if (chapter1Scenes.Contains(currentScene))
        {
            int index = chapter1Scenes.IndexOf(currentScene);
            progress = ((float)(index + 1) / chapter1Scenes.Count) * 100f;
            chapterKey = "Chapter1Progress";
            sceneKey = "LastSavedScene_Ch1";
        }
        else if (chapter2Scenes.Contains(currentScene))
        {
            int index = chapter2Scenes.IndexOf(currentScene);
            progress = ((float)(index + 1) / chapter2Scenes.Count) * 100f;
            chapterKey = "Chapter2Progress";
            sceneKey = "LastSavedScene_Ch2";
        }
        else
        {
            return;
        }

        // Check if progress exists and isn't duplicating
        if (PlayerPrefs.HasKey(chapterKey))
        {
            float savedProgress = PlayerPrefs.GetFloat(chapterKey);
            if (progress > savedProgress) // Only update progress if it's higher
            {
                PlayerPrefs.SetFloat(chapterKey, progress);
                PlayerPrefs.SetString(sceneKey, currentScene);
                PlayerPrefs.SetString("LastSavedScene", currentScene); // General save
                PlayerPrefs.Save();
            }
        }
        else
        {
            // Save if no progress exists yet
            PlayerPrefs.SetFloat(chapterKey, progress);
            PlayerPrefs.SetString(sceneKey, currentScene);
            PlayerPrefs.SetString("LastSavedScene", currentScene); // General save
            PlayerPrefs.Save();
        }
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
}*/
 // Save achievements before quitting
       /* if (achievementManager != null)
        {
            achievementManager.SaveAchievements();
        }*/
/*if (achievementManager != null)
    {
        achievementManager.LoadAchievements();
    }
    else
    {
        Debug.LogError("AchievementManager not assigned in GameplayMenuManager!");
    }*/