/*using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenController : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        // Check if the user has seen the cutscene
        if (PlayerPrefs.GetInt("HasSeenCutscene", 0) == 0)
        {
            PlayerPrefs.SetInt("HasSeenCutscene", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("OpeningScene"); // Start with the opening scene
        }
        else
        {
            LoadSavedProgress(); // Resume saved progress
        }
    }

    public void LoadSavedProgress()
    {
        // Check if there is progress saved for Chapter 1 or Chapter 2
        float chapter1Progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);
        float chapter2Progress = PlayerPrefs.GetFloat("Chapter2Progress", 0f);

        // If both chapter progress is 0, we consider this as the first-time play, so we load the opening scene
        if (chapter1Progress <= 0f && chapter2Progress <= 0f)
        {
            SceneManager.LoadScene("OpeningScene");
            return;
        }

        // If there is progress for either chapter, load the corresponding last saved scene
        string sceneToLoad = "ForestScene"; // Default to the first scene if no saved data

        if (chapter1Progress > 0f)
        {
            sceneToLoad = PlayerPrefs.GetString("LastSavedScene_Ch1", "ForestScene");
        }
        else if (chapter2Progress > 0f)
        {
            sceneToLoad = PlayerPrefs.GetString("LastSavedScene_Ch2", "DMsuitors");
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenController : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        // Check if the user has seen the cutscene
        if (PlayerPrefs.GetInt("HasSeenCutscene", 0) == 0)
        {
            PlayerPrefs.SetInt("HasSeenCutscene", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("OpeningScene"); // Start with the opening scene
        }
        else
        {
            LoadSavedProgress(); // Resume saved progress
        }
    }

    public void LoadSavedProgress()
    {
        float chapter1Progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);
        float chapter2Progress = PlayerPrefs.GetFloat("Chapter2Progress", 0f);

        // If no progress, load the opening scene
        if (chapter1Progress <= 0f && chapter2Progress <= 0f)
        {
            SceneManager.LoadScene("OpeningScene");
            return;
        }

        string sceneToLoad = "ForestScene"; // Default if no progress
        if (chapter1Progress > 0f)
        {
            sceneToLoad = PlayerPrefs.GetString("LastSavedScene_Ch1", "ForestScene");
        }
        else if (chapter2Progress > 0f)
        {
            sceneToLoad = PlayerPrefs.GetString("LastSavedScene_Ch2", "DMsuitors");
        }

        SceneManager.LoadScene(sceneToLoad);
    }

}



