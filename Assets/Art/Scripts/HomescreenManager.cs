/*using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScreenManager : MonoBehaviour
{
    public Button continueButton;          // Button to open continue content
    public Button chapter1Button;         // Button to load Chapter 1 progress
    public Button chapter2Button;         // Button to load Chapter 2 progress
    public Text chapter1ProgressText;     // Text to display Chapter 1 progress
    public Text chapter2ProgressText;     // Text to display Chapter 2 progress
    public GameObject continuePanel;      // Panel shown when continue button is clicked

    private void Start()
    {
        LoadProgress();

        // Add listeners for buttons
        continueButton.onClick.AddListener(OpenContinueContent);
        chapter1Button.onClick.AddListener(() => LoadChapter("Ch1"));
        chapter2Button.onClick.AddListener(() => LoadChapter("Ch2"));
    }

    private void LoadProgress()
    {
        // Load and display Chapter 1 progress
        float chapter1Progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);
        chapter1ProgressText.text = "Progress: " + chapter1Progress.ToString("F1") + "%";

        // Enable Chapter 1 button if progress exists
        chapter1Button.interactable = chapter1Progress > 0;

        // Load and display Chapter 2 progress
        float chapter2Progress = PlayerPrefs.GetFloat("Chapter2Progress", 0f);
        chapter2ProgressText.text = "Progress: " + chapter2Progress.ToString("F1") + "%";

        // Enable Chapter 2 button only if Chapter 1 is completed and there is Chapter 2 progress
        chapter2Button.interactable = (chapter1Progress >= 100f && chapter2Progress > 0);
    }

    private void OpenContinueContent()
    {
        // Show the continue panel
        if (continuePanel != null)
        {
            continuePanel.SetActive(true);
        }
    }

    private void LoadChapter(string chapter)
    {
        string lastSavedScene = "";

        if (chapter == "Ch1")
        {
            // Load the last saved scene for Chapter 1
            lastSavedScene = PlayerPrefs.GetString("LastSavedScene_Ch1", "ForestScene");
        }
        else if (chapter == "Ch2")
        {
            // Load the last saved scene for Chapter 2
            lastSavedScene = PlayerPrefs.GetString("LastSavedScene_Ch2", "DMsuitors");
        }

        if (!string.IsNullOrEmpty(lastSavedScene))
        {
            SceneManager.LoadScene(lastSavedScene);
        }
    }

    // Save chapter progress and current scene
    public void SaveChapterProgress(string chapter, string currentScene, float progress)
    {
        if (chapter == "Ch1")
        {
            PlayerPrefs.SetFloat("Chapter1Progress", progress);
            PlayerPrefs.SetString("LastSavedScene_Ch1", currentScene);
        }
        else if (chapter == "Ch2")
        {
            PlayerPrefs.SetFloat("Chapter2Progress", progress);
            PlayerPrefs.SetString("LastSavedScene_Ch2", currentScene);
        }

        PlayerPrefs.Save();
    }
}*/

/*using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScreenManager : MonoBehaviour
{
    public Button continueButton;          // Button to open continue content
    public Button chapter1Button;         // Button to load Chapter 1 progress
    public Button chapter2Button;         // Button to load Chapter 2 progress
    public Text chapter1ProgressText;     // Text to display Chapter 1 progress
    public Text chapter2ProgressText;     // Text to display Chapter 2 progress
    public GameObject continuePanel;      // Panel shown when continue button is clicked

    private void Start()
    {
        LoadProgress();

        // Add listeners for buttons
        continueButton.onClick.AddListener(OpenContinueContent);
        chapter1Button.onClick.AddListener(() => LoadChapter("Ch1"));
        chapter2Button.onClick.AddListener(() => LoadChapter("Ch2"));
    }

    private void LoadProgress()
    {
        // Load and display Chapter 1 progress
        float chapter1Progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);
        chapter1ProgressText.text = "Progress: " + chapter1Progress.ToString("F1") + "%";

        // Enable Chapter 1 button if progress exists
        chapter1Button.interactable = chapter1Progress > 0;

        // Load and display Chapter 2 progress
        float chapter2Progress = PlayerPrefs.GetFloat("Chapter2Progress", 0f);
        chapter2ProgressText.text = "Progress: " + chapter2Progress.ToString("F1") + "%";

        // Enable Chapter 2 button only if Chapter 1 is completed and there is Chapter 2 progress
        chapter2Button.interactable = (chapter1Progress >= 100f && chapter2Progress > 0);
    }

    private void OpenContinueContent()
    {
        // Show the continue panel
        if (continuePanel != null)
        {
            continuePanel.SetActive(true);
        }
    }

    private void LoadChapter(string chapter)
    {
        string lastSavedScene = "";

        if (chapter == "Ch1")
        {
            lastSavedScene = PlayerPrefs.GetString("LastSavedScene_Ch1", "ForestScene");
        }
        else if (chapter == "Ch2")
        {
            lastSavedScene = PlayerPrefs.GetString("LastSavedScene_Ch2", "DMsuitors");
        }

        if (!string.IsNullOrEmpty(lastSavedScene))
        {
            SceneManager.LoadScene(lastSavedScene);
        }
        else
        {
            Debug.LogWarning("No saved scene found for this chapter.");
        }
    }


    private void LoadPlayerPosition(string scene)
    {
        Vector3 defaultPosition = Vector3.zero;

        // Set the default position based on the scene
        switch (scene)
        {
            case "ForestScene":
                defaultPosition = new Vector3(-7.57f, -2, 0); // Example position
                break;
            case "RiverScene":
                defaultPosition = new Vector3(-6, -2, 0); // Example position
                break;
            case "VillageScene":
                defaultPosition = new Vector3(26, -2, 0); // Example position
                break;
            case "LiwaywayHouse":
                defaultPosition = new Vector3(17.68f, -2.61f, 0); // Example position
                break;
            case "CassavaFields":
                defaultPosition = new Vector3(-29.4f, -1.35f, 0); // Example position
                break;
            case "DMhouse":
                defaultPosition = new Vector3(-5.16f, 0.43f, 1); // Example position
                break;
            case "InsideDMhouse":
                defaultPosition = new Vector3(19.25f, -2.18f, 0); // Example position
                break;
            case "DMsuitors":
                defaultPosition = new Vector3(32.67f, -0.6f, 0); // Example position
                break;
            case "IlogScene":
                defaultPosition = new Vector3(-1.45f, -2, 0); // Example position
                break;
        }

        // Set the player's position in the scene
        // Assuming you have a player GameObject with a tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = defaultPosition;
        }
    }

    // Save chapter progress and current scene
    public void SaveChapterProgress(string chapter, string currentScene, float progress)
    {
        if (chapter == "Ch1")
        {
            PlayerPrefs.SetFloat("Chapter1Progress", progress);
            PlayerPrefs.SetString("LastSavedScene_Ch1", currentScene);
        }
        else if (chapter == "Ch2")
        {
            PlayerPrefs.SetFloat("Chapter2Progress", progress);
            PlayerPrefs.SetString("LastSavedScene_Ch2", currentScene);
        }

        PlayerPrefs.Save();
    }
}*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScreenManager : MonoBehaviour
{
    public Button continueButton;          // Button to open continue content
    public Button chapter1Button;         // Button to load Chapter 1 progress
    public Button chapter2Button;         // Button to load Chapter 2 progress
    public Button chapter3Button;         // Button to load Chapter 3 progress
    public Text chapter1ProgressText;     // Text to display Chapter 1 progress
    public Text chapter2ProgressText;     // Text to display Chapter 2 progress
    public Text chapter3ProgressText;     // Text to display Chapter 3 progress
    public GameObject continuePanel;      // Panel shown when continue button is clicked

    private void Start()
    {
        LoadProgress();

        // Add listeners for buttons
        continueButton.onClick.AddListener(OpenContinueContent);
        chapter1Button.onClick.AddListener(() => LoadChapter("Ch1"));
        chapter2Button.onClick.AddListener(() => LoadChapter("Ch2"));
        chapter3Button.onClick.AddListener(() => LoadChapter("Ch3"));
    }

    private void LoadProgress()
    {
        // Load and display Chapter 1 progress
        float chapter1Progress = PlayerPrefs.GetFloat("Chapter1Progress", 0f);
        chapter1ProgressText.text = "Progress: " + chapter1Progress.ToString("F1") + "%";
        chapter1Button.interactable = chapter1Progress > 0;

        // Load and display Chapter 2 progress
        float chapter2Progress = PlayerPrefs.GetFloat("Chapter2Progress", 0f);
        chapter2ProgressText.text = "Progress: " + chapter2Progress.ToString("F1") + "%";
        chapter2Button.interactable = (chapter1Progress >= 100f && chapter2Progress > 0);

        // Load and display Chapter 3 progress
        float chapter3Progress = PlayerPrefs.GetFloat("Chapter3Progress", 0f);
        chapter3ProgressText.text = "Progress: " + chapter3Progress.ToString("F1") + "%";
        chapter3Button.interactable = (chapter2Progress >= 100f && chapter3Progress > 0);
    }

    private void OpenContinueContent()
    {
        if (continuePanel != null)
        {
            continuePanel.SetActive(true);
        }
    }

    private void LoadChapter(string chapter)
    {
        string lastSavedScene = "";

        if (chapter == "Ch1")
        {
            lastSavedScene = PlayerPrefs.GetString("LastSavedScene_Ch1", "ForestScene");
        }
        else if (chapter == "Ch2")
        {
            lastSavedScene = PlayerPrefs.GetString("LastSavedScene_Ch2", "DMsuitors");
        }
        else if (chapter == "Ch3")
        {
            lastSavedScene = PlayerPrefs.GetString("LastSavedScene_Ch3", "Chapter3StartScene");
        }

        if (!string.IsNullOrEmpty(lastSavedScene))
        {
            SceneManager.LoadScene(lastSavedScene);
        }
        else
        {
            Debug.LogWarning("No saved scene found for this chapter.");
        }
    }

    public void SaveChapterProgress(string chapter, string currentScene, float progress)
    {
        if (chapter == "Ch1")
        {
            PlayerPrefs.SetFloat("Chapter1Progress", progress);
            PlayerPrefs.SetString("LastSavedScene_Ch1", currentScene);
        }
        else if (chapter == "Ch2")
        {
            PlayerPrefs.SetFloat("Chapter2Progress", progress);
            PlayerPrefs.SetString("LastSavedScene_Ch2", currentScene);
        }
        else if (chapter == "Ch3")
        {
            PlayerPrefs.SetFloat("Chapter3Progress", progress);
            PlayerPrefs.SetString("LastSavedScene_Ch3", currentScene);
        }

        PlayerPrefs.Save();
    }
}

