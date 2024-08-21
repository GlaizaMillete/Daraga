using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public SettingsMenu settingsMenu;
    public GameObject audioTab;
    public GameObject achievementsTab;
    public GameObject languageTab;
    public Button closeButton;

    public Button audioTabButton;
    public Button achievementsTabButton;
    public Button languageTabButton;

    void Start()
    {
        // Show the default tab (e.g., AudioTab) on start
        ShowAudioTab();

        // Assign button listeners
        audioTabButton.onClick.AddListener(ShowAudioTab);
        achievementsTabButton.onClick.AddListener(ShowAchievementsTab);
        languageTabButton.onClick.AddListener(ShowLanguageTab);
        closeButton.onClick.AddListener(CloseSettings);
    }

    void ShowAudioTab()
    {
        audioTab.SetActive(true);
        achievementsTab.SetActive(false);
        languageTab.SetActive(false);
    }

    void ShowAchievementsTab()
    {
        audioTab.SetActive(false);
        achievementsTab.SetActive(true);
        languageTab.SetActive(false);
    }

    void ShowLanguageTab()
    {
        audioTab.SetActive(false);
        achievementsTab.SetActive(false);
        languageTab.SetActive(true);
    }

    void CloseSettings()
    {
        gameObject.SetActive(false); // This will hide the entire settings menu
    }

    public void OpenSettings()
    {
        gameObject.SetActive(true); // This can be called to open the settings menu
    }

    void OpenSettingsMenu()
    {
    settingsMenu.OpenSettings();
    }
}
