/*using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HomeScreenManager : MonoBehaviour
{
    public Button continueButton;
    public Button chapter1Button;
    public Button chapter2Button;
    public Text chapter1ProgressText;
    public Text chapter2ProgressText;

    private List<string> chapter1Scenes = new List<string>
    {
        "ForestScene", "RiverScene", "VillageScene", "CassavaFields", "DMhouse", "InsideDMHouse"
    };

    private List<string> chapter2Scenes = new List<string>
    {
        "DMsuitors", "IlogScene"
    };

    private void Start()
    {
        LoadProgress();
        
        continueButton.onClick.AddListener(LoadSavedProgress);
        chapter1Button.onClick.AddListener(() => LoadChapterScene("Ch1"));
        chapter2Button.onClick.AddListener(() => LoadChapterScene("Ch2"));
    }

    private void LoadProgress()
    {
        // Load Chapter 1 progress
        float chapter1Progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);
        chapter1ProgressText.text = $"Progress: {chapter1Progress:F1}%";

        // Load Chapter 2 progress
        float chapter2Progress = PlayerPrefs.GetFloat("Chapter2Progress", 0f);
        chapter2ProgressText.text = $"Progress: {chapter2Progress:F1}%";

        // Unlock buttons based on progress
        if (chapter1Progress > 0) continueButton.interactable = true;

        // Chapter 2 unlocks only if Chapter 1 is complete
        if (chapter1Progress >= 100f) chapter2Button.interactable = true;
    }

    private void LoadChapterScene(string chapter)
    {
        string sceneToLoad = chapter == "Ch1"
            ? PlayerPrefs.GetString("LastSavedScene_Ch1", "ForestScene")
            : PlayerPrefs.GetString("LastSavedScene_Ch2", "DMsuitors");

        SceneManager.LoadScene(sceneToLoad);
    }

    private void LoadSavedProgress()
    {
        string savedScene = PlayerPrefs.GetString("LastSavedScene", "ForestScene");
        SceneManager.LoadScene(savedScene);
    }
}*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScreenManager : MonoBehaviour
{
    public Button continueButton;          // Button to open continue content
    public Button chapter1Button;         // Button to load Chapter 1 progress
    public Button chapter2Button;         // Button to load Chapter 2 progress
    public Text chapter1ProgressText;     // Text to display Chapter 1 progress
    public Text chapter2ProgressText;     // Text to display Chapter 2 progress
    public GameObject continuePanel;      // Panel shown when continue button is clicked

    private void Start()
    {
        LoadProgress();

        // Add listeners for buttons
        continueButton.onClick.AddListener(OpenContinueContent);
        chapter1Button.onClick.AddListener(() => LoadChapter("Ch1"));
        chapter2Button.onClick.AddListener(() => LoadChapter("Ch2"));
    }

    private void LoadProgress()
    {
        // Load and display Chapter 1 progress
        float chapter1Progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);
        chapter1ProgressText.text = "Progress: " + chapter1Progress.ToString("F1") + "%";

        // Enable Chapter 1 button if progress exists
        chapter1Button.interactable = chapter1Progress > 0;

        // Load and display Chapter 2 progress
        float chapter2Progress = PlayerPrefs.GetFloat("Chapter2Progress", 0f);
        chapter2ProgressText.text = "Progress: " + chapter2Progress.ToString("F1") + "%";

        // Enable Chapter 2 button only if progress exists
        chapter2Button.interactable = chapter2Progress > 0;

        // Disable Chapter 2 button until Chapter 1 is completed
        if (chapter1Progress < 100f)
        {
            chapter2Button.interactable = false;
        }
    }

    private void OpenContinueContent()
    {
        // Show the continue panel
        if (continuePanel != null)
        {
            continuePanel.SetActive(true);
        }
    }

    private void LoadChapter(string chapter)
    {
        string lastSavedScene = "";
        
        if (chapter == "Ch1")
        {
            // Load the last saved scene for Chapter 1
            lastSavedScene = PlayerPrefs.GetString("LastSavedScene_Ch1", "ForestScene");
        }
        else if (chapter == "Ch2")
        {
            // Load the last saved scene for Chapter 2
            lastSavedScene = PlayerPrefs.GetString("LastSavedScene_Ch2", "DMsuitors");
        }

        if (!string.IsNullOrEmpty(lastSavedScene))
        {
            SceneManager.LoadScene(lastSavedScene);
        }
    }

    // Save chapter progress and current scene
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
}
