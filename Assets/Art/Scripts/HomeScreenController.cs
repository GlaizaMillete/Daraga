using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenController : MonoBehaviour
{
    // Called when the Play button is clicked
    public void OnPlayButtonClick()
    {
        float chapter1Progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);
        float chapter2Progress = PlayerPrefs.GetFloat("Chapter2Progress", 0f);

        // Compare Chapter 1 and Chapter 2 progress
        string savedScene = "";
        if (chapter2Progress > chapter1Progress)
        {
            // If Chapter 2 has more progress, load from Chapter 2's last saved scene
            savedScene = PlayerPrefs.GetString("LastSavedScene_Ch2", "DMsuitors");
        }
        else
        {
            // Otherwise, load from Chapter 1's last saved scene
            savedScene = PlayerPrefs.GetString("LastSavedScene_Ch1", "ForestScene");
        }

        // Check if the user has seen the cutscene, then load the appropriate scene
        if (PlayerPrefs.GetInt("HasSeenCutscene", 0) == 1)
        {
            SceneManager.LoadScene(savedScene);
        }
        else
        {
            PlayerPrefs.SetInt("HasSeenCutscene", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("OpeningScene");
        }
    }

    public void LoadSavedProgress()
    {
        float chapter1Progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);
        float chapter2Progress = PlayerPrefs.GetFloat("Chapter2Progress", 0f);

        string savedScene;

        // Compare the progress of both chapters
        if (chapter2Progress > chapter1Progress)
        {
            savedScene = PlayerPrefs.GetString("LastSavedScene_Ch2", "DMsuitors");
        }
        else
        {
            savedScene = PlayerPrefs.GetString("LastSavedScene_Ch1", "ForestScene");
        }

        SceneManager.LoadScene(savedScene);
    }
}
