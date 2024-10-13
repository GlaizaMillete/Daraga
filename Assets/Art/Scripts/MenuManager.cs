/*using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // UI elements
    public GameObject menuPanel;
    public GameObject audioTab;
    public GameObject achievementTab;
    public GameObject languageTab;
    public Button saveandquitbtn;
    public Button exitbtn;
    public GameObject modalnotif; // Modal panel for confirmation
    public Button yellowbtn; // Button to confirm save and quit
    public Button redbtn; // Button to cancel
    public Button menuicon; // Button to open the menu
    private int yourProgressValue;

    // Start is called before the first frame update
    void Start()
    {
        // Hide menu and modal panels at start
        menuPanel.SetActive(false);
        modalnotif.SetActive(false);

        // Button listeners
        menuicon.onClick.AddListener(ToggleMenu);
        saveandquitbtn.GetComponent<Button>().onClick.AddListener(OpenModal);
        yellowbtn.onClick.AddListener(SaveAndQuit);
        redbtn.onClick.AddListener(CloseModal);
        exitbtn.GetComponent<Button>().onClick.AddListener(CloseMenu);
    }

    // Toggle the menu panel
    void ToggleMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
    }

     // Function to save progress based on the current scene
    public void SaveProgress()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "RiverScene")
        {
            // Save progress specific to RiverScene
            PlayerPrefs.SetInt("RiverProgress", yourProgressValue);
            PlayerPrefs.Save();
        }
        else if (currentScene == "ForestScene")
        {
            // Save progress specific to ForestScene
            PlayerPrefs.SetInt("ForestProgress", yourProgressValue);
            PlayerPrefs.Save();
        }
    }


     public void LoadHomeScreen()
    {
        SceneManager.LoadScene("Homescreen");
        SceneManager.LoadScene("Homescreen"); // Change to your actual home screen scene name
        Debug.Log("Loading Home Screen...");
    }

    // Function to load the saved chapter progress
    public void ContinueChapter()
    {
        if (PlayerPrefs.HasKey("Progress_Forest") && PlayerPrefs.GetInt("Progress_Forest") == 1)
        {
            SceneManager.LoadScene("ForestScene"); // Load ForestScene if progress exists
            Debug.Log("Continuing from ForestScene...");
        }
        else if (PlayerPrefs.HasKey("Progress_River") && PlayerPrefs.GetInt("Progress_River") == 1)
        {
            SceneManager.LoadScene("RiverScene"); // Load RiverScene if progress exists
            Debug.Log("Continuing from RiverScene...");
        }
        else
        {
            Debug.Log("No saved progress found.");
            // Optionally, show a message or take another action if no progress exists
        }
    }


    // Open the modal confirmation
    void OpenModal()
    {
        modalnotif.SetActive(true);
    }

    // Close the modal confirmation
    void CloseModal()
    {
        modalnotif.SetActive(false);
    }

    // Save the game and quit to the home screen
    void SaveAndQuit()
    {
        // Implement your save logic here, save to 'Chapter1Button'
        PlayerPrefs.SetInt("CurrentChapter", 1); // Example save logic

        // Load the home screen scene
        SceneManager.LoadScene("Homescreen");
    }

    // Close the menu
    void CloseMenu()
    {
        menuPanel.SetActive(false);
    }
}*/
