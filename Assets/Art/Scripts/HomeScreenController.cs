using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenController : MonoBehaviour
{
    // Called when the Play button is clicked
    public void OnPlayButtonClick()
    {
        if (PlayerPrefs.HasKey("HasSeenCutscene") && PlayerPrefs.GetInt("HasSeenCutscene") == 1)
        {
            LoadSavedProgress();
        }
        else
        {
            // Save that the cutscene is being played
            PlayerPrefs.SetInt("HasSeenCutscene", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("OpeningScene");
        }
    }

    public void LoadSavedProgress()
    {
        string savedScene = PlayerPrefs.GetString("LastSavedScene", "ForestScene");
        SceneManager.LoadScene(savedScene);
    }
}
