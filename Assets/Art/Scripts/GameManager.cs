/*using UnityEngine;
using UnityEngine.SceneManagement; // Add this line


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float chapter1Progress; // Variable to hold Chapter 1 progress
    // You can add more variables for different chapters or data

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps the GameManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        float currentProgress = GameManager.instance.chapter1Progress;
        Debug.Log("Current Chapter 1 Progress: " + currentProgress);

        LoadProgress();
    }

    public void SaveProgress(float progress)
    {
        chapter1Progress = progress;
        PlayerPrefs.SetFloat("Chapter1Progress", chapter1Progress);
        PlayerPrefs.Save();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) // Example key for saving progress
        {
            SaveProgress();
        }
    }

    public void SaveProgress()
    {
        string currentScene = SceneManager.GetActiveScene().name; // Get the name of the active scene
        
        // Implementing scene-specific saving logic
        if (currentScene == "ForestScene")
        {
            // Saving logic specific to ForestScene
            Debug.Log("Saving progress in ForestScene...");
            PlayerPrefs.SetInt("Progress_Forest", 1); // Example saving
        }
        else if (currentScene == "RiverScene")
        {
            // Ensure you have saving logic for RiverScene
            Debug.Log("Saving progress in RiverScene...");
            PlayerPrefs.SetInt("Progress_River", 1); // Example saving
        }

        // General saving logic (if needed)
        PlayerPrefs.Save();
        Debug.Log("Progress saved!");
    }



    public void LoadProgress()
    {
        chapter1Progress = PlayerPrefs.GetFloat("Chapter1Progress", 1); // Default to 0 if not set
    }

    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}*/
