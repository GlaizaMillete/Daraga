using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TabController : MonoBehaviour
{
    public GameObject audioPanel;
    public GameObject achievementsPanel;
    public GameObject languagePanel;

    public UnityEngine.UI.Button audioTabButton;
    public UnityEngine.UI.Button achievementsTabButton;
    public UnityEngine.UI.Button languageTabButton;

    void Start()
    {
        // Add listeners to the buttons
        audioTabButton.onClick.AddListener(ShowAudioPanel);
        achievementsTabButton.onClick.AddListener(ShowAchievementsPanel);
        languageTabButton.onClick.AddListener(ShowLanguagePanel);

        // Show the default panel (audio)
        ShowAudioPanel();
    }

    void ShowAudioPanel()
    {
        audioPanel.SetActive(true);
        achievementsPanel.SetActive(false);
        languagePanel.SetActive(false);
    }

    void ShowAchievementsPanel()
    {
        audioPanel.SetActive(false);
        achievementsPanel.SetActive(true);
        languagePanel.SetActive(false);
    }

    void ShowLanguagePanel()
    {
        audioPanel.SetActive(false);
        achievementsPanel.SetActive(false);
        languagePanel.SetActive(true);
    }
}
