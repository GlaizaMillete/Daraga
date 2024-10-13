using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipCutsceneScript : MonoBehaviour
{
    public GameObject skipSprite; // The skip button sprite
    public string sceneToLoad = "NextScene"; // The scene to load if the player skips
    public Button skipButton;

    private bool hasProgress;

    private void Start()
    {
        // Check if the player has made progress in the game
        hasProgress = PlayerPrefs.GetFloat("Chapter1Progress", 0f) > 0;

        // Show skip sprite if the player has progress
        if (hasProgress)
        {
            skipSprite.SetActive(true); // Enable the skip sprite
        }
        else
        {
            skipSprite.SetActive(false); // Hide the skip sprite if no progress
        }

        // Set up skip button functionality
        skipButton.onClick.AddListener(SkipCutscene);
    }

    // Method to skip the cutscene and load the next scene
    private void SkipCutscene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
