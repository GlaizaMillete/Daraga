using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel; // The entire menu panel
    public Button menuIconButton; // Button to open the menu
    public Button closeButton; // Button to close the menu

    public Button audioTabButton; // Button to open the Audio tab
    public Button achievementsTabButton; // Button to open the Achievements tab
    public Button languageTabButton; // Button to open the Language tab

    public GameObject audioTabContent; // Content for the Audio tab
    public GameObject achievementsTabContent; // Content for the Achievements tab
    public GameObject languageTabContent; // Content for the Language tab

    public Button saveAndQuitButton; // Button to trigger save and quit
    public GameObject confirmationModal; // Modal for confirming save and quit
    public Button yesButton; // Button to confirm save and quit
    public Button noButton; // Button to cancel save and quit

    private void Start()
    {
        menuPanel.SetActive(false);
        confirmationModal.SetActive(false);

        menuIconButton.onClick.AddListener(OpenMenu);
        closeButton.onClick.AddListener(CloseMenu);

        audioTabButton.onClick.AddListener(OpenAudioTab);
        achievementsTabButton.onClick.AddListener(OpenAchievementsTab);
        languageTabButton.onClick.AddListener(OpenLanguageTab);

        saveAndQuitButton.onClick.AddListener(ShowConfirmationModal);
        yesButton.onClick.AddListener(ConfirmSaveAndQuit);
        noButton.onClick.AddListener(CancelSaveAndQuit);

        // Default to the Audio tab
        OpenAudioTab();
    }

    private void OpenMenu()
    {
        menuPanel.SetActive(true);
    }

    private void CloseMenu()
    {
        menuPanel.SetActive(false);
    }

    private void OpenAudioTab()
    {
        audioTabContent.SetActive(true);
        achievementsTabContent.SetActive(false);
        languageTabContent.SetActive(false);
    }

    private void OpenAchievementsTab()
    {
        audioTabContent.SetActive(false);
        achievementsTabContent.SetActive(true);
        languageTabContent.SetActive(false);
    }

    private void OpenLanguageTab()
    {
        audioTabContent.SetActive(false);
        achievementsTabContent.SetActive(false);
        languageTabContent.SetActive(true);
    }

    private void ShowConfirmationModal()
    {
        confirmationModal.SetActive(true); // Show the confirmation modal
    }

    private void ConfirmSaveAndQuit()
    {
        SaveGameProgress(); // Save the game progress
        SceneManager.LoadScene("HomeScreen"); // Load the HomeScreen scene
    }

    private void CancelSaveAndQuit()
    {
        confirmationModal.SetActive(false); // Hide the confirmation modal and return to the game
    }

    private void SaveGameProgress()
    {
        // Save progress specific to Chapter 1
        PlayerPrefs.SetInt("ContinueChapter", 1); // Example saving progress as Chapter 1
        PlayerPrefs.Save(); // Save PlayerPrefs to disk

        // Add any other necessary data saving here
    }
}
