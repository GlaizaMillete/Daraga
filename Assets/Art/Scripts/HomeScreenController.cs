using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenController : MonoBehaviour
{
    // Call this when the Play button is clicked
    public void OnPlayButtonClick()
    {
        // Check if the player has seen the cutscene
        if (PlayerPrefs.HasKey("HasSeenCutscene") && PlayerPrefs.GetInt("HasSeenCutscene") == 1)
        {
            // If they've seen the cutscene, load the saved progress scene
            LoadSavedProgress();
        }
        else
        {
            // If they haven't seen the cutscene, load the opening scene
            SceneManager.LoadScene("OpeningScene");
        }
    }

    private void LoadSavedProgress()
    {
        // Load the player's saved progress
        string savedScene = PlayerPrefs.GetString("LastSavedScene", "DefaultScene");  // Default scene if no save
        SceneManager.LoadScene(savedScene);
    }
}
