using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScreenManager : MonoBehaviour
{
    public Button continueButton;
    public Button chapter1Button;
    public Text chapter1ProgressText;

    private void Start()
    {
        LoadProgress();

        // Add listener to the continue button
        continueButton.onClick.AddListener(LoadSavedProgress);
    }

    private void LoadProgress()
    {
        // Load the saved progress from PlayerPrefs
        float progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);

        // Update the Chapter 1 progress text
        chapter1ProgressText.text = "Progress: " + progress.ToString("F1") + "%";

        // Enable the continue button if progress exists
        if (progress > 0)
        {
            continueButton.interactable = true;
        }
    }

    private void LoadSavedProgress()
    {
        // Load the last saved scene from PlayerPrefs
        string lastSavedScene = PlayerPrefs.GetString("LastSavedScene", "ForestScene");

        // Load the saved scene to continue the game
        SceneManager.LoadScene(lastSavedScene);
    }
}
