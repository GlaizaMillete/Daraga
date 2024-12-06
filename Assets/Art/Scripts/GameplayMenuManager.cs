/*using UnityEngine;
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

    private CinemachineVirtualCamera cinemachineCamera;
    private string sceneToHideGameplayMenu = "Homescreen"; // Name of the scene where this GameObject should be destroyed

    private void Start()
    {
        DontDestroyOnLoad(gameObject); // Persist this GameObject across scenes
        InitializeUIReferences();
        InitializeCamera();

        // Add button listeners
        menuicon.onClick.AddListener(ToggleMenu);
        saveandquitbtn.onClick.AddListener(OpenModal);
        yellowbtn.onClick.AddListener(SaveAndQuit);
        redbtn.onClick.AddListener(CloseModal);
        exitbtn.onClick.AddListener(CloseMenu);
        audiobtn.onClick.AddListener(ShowOnlyAudioTab);
        achievementbtn.onClick.AddListener(ShowOnlyAchievementTab);
        languagebtn.onClick.AddListener(ShowOnlyLanguageTab);
    }

    private void InitializeUIReferences()
    {
        if (menuPanel == null) menuPanel = GameObject.Find("MenuPanel");
        if (audioTab == null) audioTab = GameObject.Find("AudioTab");
        if (achievementTab == null) achievementTab = GameObject.Find("AchievementTab");
        if (languageTab == null) languageTab = GameObject.Find("LanguageTab");
    }

    private void InitializeCamera()
    {
        cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
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

    private void ToggleMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        if (menuPanel.activeSelf) ShowOnlyAudioTab();
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

    public void SaveAndQuit()
    {
        SaveProgress(); // Save the current progress
        SceneManager.LoadScene("Homescreen"); // Load the home screen
    }

    private void SaveProgress()
    {
        string currentSceneName = SceneManager.GetActiveScene().name; // Get the current scene name
        float currentProgress = CalculateProgressForCurrentScene(currentSceneName); // Your logic for calculating progress

        // Save progress based on the chapter
        if (currentSceneName.Contains("Ch1"))
        {
            PlayerPrefs.SetString("LastSavedScene_Ch1", currentSceneName);
            PlayerPrefs.SetFloat("Chapter1Progress", currentProgress);
        }
        else if (currentSceneName.Contains("Ch2"))
        {
            PlayerPrefs.SetString("LastSavedScene_Ch2", currentSceneName);
            PlayerPrefs.SetFloat("Chapter2Progress", currentProgress);
        }

        PlayerPrefs.Save(); // Save to disk
        Debug.Log($"Progress saved. Scene: {currentSceneName}, Progress: {currentProgress}");
    }

    private float CalculateProgressForCurrentScene(string sceneName)
    {
        // Chapter 1 scenes
        if (sceneName == "ForestScene") return 0.1f;
        if (sceneName == "RiverScene") return 0.2f;
        if (sceneName == "VillageScene") return 0.3f;
        if (sceneName == "LiwaywayHouse") return 0.4f;
        if (sceneName == "JarAssemble") return 0.5f;
        if (sceneName == "CassavaFields") return 0.6f;
        if (sceneName == "DMhouse") return 0.7f;
        if (sceneName == "insideDMhouse") return 0.8f;

        // Chapter 1 Cutscenes
        if (sceneName == "PasokCompound") return 0.1f;
        if (sceneName == "Stranger") return 0.2f;
        if (sceneName == "ManliligawniDM") return 0.3f;

        // Chapter 2 scenes
        if (sceneName == "DMsuitors") return 0.4f;
        if (sceneName == "AngMgaSuitors") return 0.5f;
        if (sceneName == "PagtugaVisit") return 0.6f;
        if (sceneName == "DMatULAP") return 0.7f;
        if (sceneName == "IlogScene") return 0.8f;

        // Chapter 3 scenes
        if (sceneName == "Chapter3") return 1.0f;

        // Default progress
        return 0f;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeUIReferences();
        InitializeCamera();

        // Check if the current scene is the HomeScreen
        if (scene.name == sceneToHideGameplayMenu)
        {
            Destroy(gameObject); // Destroy the GameplayMenuManager GameObject
            Debug.Log("GameplayMenuManager destroyed on HomeScreen.");
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
}*/

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

    private CinemachineVirtualCamera cinemachineCamera;
    private string sceneToHideGameplayMenu = "Homescreen"; // Name of the scene where this GameObject should be destroyed

    private void Start()
    {
        DontDestroyOnLoad(gameObject); // Persist this GameObject across scenes
        InitializeUIReferences();
        InitializeCamera();

        // Add button listeners
        menuicon.onClick.AddListener(ToggleMenu);
        saveandquitbtn.onClick.AddListener(OpenModal);
        yellowbtn.onClick.AddListener(SaveAndQuit);
        redbtn.onClick.AddListener(CloseModal);
        exitbtn.onClick.AddListener(CloseMenu);
        audiobtn.onClick.AddListener(ShowOnlyAudioTab);
        achievementbtn.onClick.AddListener(ShowOnlyAchievementTab);
        languagebtn.onClick.AddListener(ShowOnlyLanguageTab);
    }

    private void InitializeUIReferences()
    {
        if (menuPanel == null) menuPanel = GameObject.Find("MenuPanel");
        if (audioTab == null) audioTab = GameObject.Find("AudioTab");
        if (achievementTab == null) achievementTab = GameObject.Find("AchievementTab");
        if (languageTab == null) languageTab = GameObject.Find("LanguageTab");
    }

    private void InitializeCamera()
    {
        cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
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

    private void ToggleMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        if (menuPanel.activeSelf) ShowOnlyAudioTab();
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

    public void SaveAndQuit()
    {
        SaveProgress(); // Save the current progress
        SceneManager.LoadScene("Homescreen"); // Load the home screen
    }

    private void SaveProgress()
    {
        string currentSceneName = SceneManager.GetActiveScene().name; // Get the current scene name
        float currentProgress = CalculateProgressForCurrentScene(currentSceneName); // Your logic for calculating progress

        // Save progress based on the chapter
        if (currentSceneName.Contains("Ch1"))
        {
            PlayerPrefs.SetString("LastSavedScene_Ch1", currentSceneName);
            PlayerPrefs.SetFloat("Chapter1Progress", currentProgress);
        }
        else if (currentSceneName.Contains("Ch2"))
        {
            PlayerPrefs.SetString("LastSavedScene_Ch2", currentSceneName);
            PlayerPrefs.SetFloat("Chapter2Progress", currentProgress);
        }
        else
        {
            PlayerPrefs.SetString("LastSavedScene", currentSceneName);  // For scenes not in chapters
        }

        PlayerPrefs.Save(); // Save to disk
        Debug.Log($"Progress saved. Scene: {currentSceneName}, Progress: {currentProgress}");
    }

    private float CalculateProgressForCurrentScene(string sceneName)
    {
        // Chapter 1 scenes
        if (sceneName == "ForestScene") return 0.1f;
        if (sceneName == "RiverScene") return 0.2f;
        if (sceneName == "VillageScene") return 0.3f;
        if (sceneName == "LiwaywayHouse") return 0.4f;
        if (sceneName == "JarAssemble") return 0.5f;
        if (sceneName == "CassavaFields") return 0.6f;
        if (sceneName == "DMhouse") return 0.7f;
        if (sceneName == "insideDMhouse") return 0.8f;

        // Chapter 1 Cutscenes
        if (sceneName == "PasokCompound") return 0.1f;
        if (sceneName == "Stranger") return 0.2f;
        if (sceneName == "ManliligawniDM") return 0.3f;

        // Chapter 2 scenes
        if (sceneName == "DMsuitors") return 0.4f;
        if (sceneName == "AngMgaSuitors") return 0.5f;
        if (sceneName == "PagtugaVisit") return 0.6f;
        if (sceneName == "DMatULAP") return 0.7f;
        if (sceneName == "IlogScene") return 0.8f;

        // Chapter 3 scenes
        if (sceneName == "Chapter3") return 1.0f;

        // Default progress
        return 0f;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeUIReferences();
        InitializeCamera();

        // Ensure the gameplay menu appears if the scene is not "Homescreen"
        if (scene.name != sceneToHideGameplayMenu)
        {
            if (menuicon != null && !menuicon.gameObject.activeSelf)
            {
                menuicon.gameObject.SetActive(true);
            }
        }

        // Check if the current scene is the HomeScreen
        if (scene.name == sceneToHideGameplayMenu)
        {
            Destroy(gameObject); // Destroy the GameplayMenuManager GameObject
            Debug.Log("GameplayMenuManager destroyed on HomeScreen.");
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






