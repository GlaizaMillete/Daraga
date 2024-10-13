using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private void Start()
    {
        // Hide menu and modal panels at start
        menuPanel.SetActive(false);
        modalnotif.SetActive(false);

        // Button listeners
        menuicon.onClick.AddListener(ToggleMenu);
        saveandquitbtn.onClick.AddListener(OpenModal);
        yellowbtn.onClick.AddListener(SaveAndQuit);
        redbtn.onClick.AddListener(CloseModal);
        exitbtn.onClick.AddListener(CloseMenu);
    }

    void ToggleMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
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
}
