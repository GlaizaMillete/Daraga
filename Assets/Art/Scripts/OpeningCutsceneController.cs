using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningCutsceneController : MonoBehaviour
{
    public GameObject skipButton;

    void Start()
    {
        // Enable the skip button only for old players who have seen the cutscene
        if (PlayerPrefs.HasKey("HasSeenCutscene") && PlayerPrefs.GetInt("HasSeenCutscene") == 1)
        {
            skipButton.SetActive(true);
        }
        else
        {
            skipButton.SetActive(false);
        }
    }

    // Call this when the Skip button is clicked
    public void OnSkipButtonClick()
    {
        // Mark the cutscene as seen
        PlayerPrefs.SetInt("HasSeenCutscene", 1);

        // Save the progress and load the saved progress scene
        SaveProgress();
        string savedScene = PlayerPrefs.GetString("LastSavedScene", "DefaultScene"); // Default scene
        SceneManager.LoadScene(savedScene);
    }

    // Call this at the end of the cutscene
    public void OnCutsceneEnd()
    {
        // Mark the cutscene as seen for future plays
        PlayerPrefs.SetInt("HasSeenCutscene", 1);

        // Load the next scene after the cutscene (or saved progress)
        string nextScene = "NextScene";  // Replace with the actual next scene after the cutscene
        SaveProgress();
        SceneManager.LoadScene(nextScene);
    }

    private void SaveProgress()
    {
        // Save the progress in PlayerPrefs and mark the cutscene as complete
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastSavedScene", currentScene);
        PlayerPrefs.Save();
    }
}
