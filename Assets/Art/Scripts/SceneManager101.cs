using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager101 : MonoBehaviour
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
    
    public Button continueButton; // Continue button on Home screen
    public Button chapter1Button; // Chapter 1 button on Home screen
    public Text chapter1ProgressText; // Text to show save progress percentage

    private string currentScene;
    private float progress;
    
    // List of scenes in Chapter 1
    private List<string> chapter1Scenes = new List<string> { "ForestScene", "RiverScene", "VillageScene", "LiwaywayScene", "CassavaFieldsScene", "DMhouse", "InsideDMHouse" };

    private void Start()
    {
        menuPanel.SetActive(false);
        modalnotif.SetActive(false);

        menuicon.onClick.AddListener(ToggleMenu);
        saveandquitbtn.GetComponent<Button>().onClick.AddListener(OpenModal);
        yellowbtn.onClick.AddListener(SaveAndQuit);
        redbtn.onClick.AddListener(CloseModal);
        exitbtn.GetComponent<Button>().onClick.AddListener(CloseMenu);

        LoadProgress();
    }

    // Open the modal confirmation
    void OpenModal()
    {
        modalnotif.SetActive(true);
    }

    // Close the modal confirmation
    void CloseModal()
    {
        modalnotif.SetActive(false);
    }

    // Close the menu
    void CloseMenu()
    {
        menuPanel.SetActive(false);
    }

    void ToggleMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
    }

    private void SaveAndQuit()
    {
        currentScene = SceneManager.GetActiveScene().name;
        SaveProgress();
        modalnotif.SetActive(false); 
        SceneManager.LoadScene("Homescreen"); // Go back to home screen
    }

    private void SaveProgress()
    {
        // Calculate the progress based on the current scene
        int sceneIndex = chapter1Scenes.IndexOf(currentScene);
        if (sceneIndex != -1)
        {
            progress = ((float)(sceneIndex + 1) / chapter1Scenes.Count) * 100f;
        }

        // Save progress and the current scene to PlayerPrefs
        PlayerPrefs.SetFloat("Chapter1Progress", progress);
        PlayerPrefs.SetString("LastSavedScene", currentScene);
        PlayerPrefs.Save(); // Ensure data is saved
    }

    private void LoadProgress()
    {
        // Load saved progress from PlayerPrefs
        progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);
        chapter1ProgressText.text = "Progress: " + progress.ToString("F1") + "%";

        // Update Chapter 1 button status based on progress
        if (progress > 0)
        {
            chapter1Button.interactable = true; // Enable button if progress exists
        }
    }

    public void LoadSavedProgress()
    {
        // Load the last saved scene and continue from there
        string lastSavedScene = PlayerPrefs.GetString("LastSavedScene", chapter1Scenes[0]); // Default to the first scene if no save exists
        SceneManager.LoadScene(lastSavedScene);
    }
}
