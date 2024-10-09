using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScreenController : MonoBehaviour
{
    public Button chapter1Button;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SavedGame"))
        {
            chapter1Button.onClick.AddListener(ContinueChapter1);
        }
        else
        {
            chapter1Button.onClick.AddListener(StartNewChapter1);
        }
    }

    private void ContinueChapter1()
    {
        // Load the scene or progress saved for Chapter 1
        SceneManager.LoadScene("ForestScene"); // Replace with your scene name
    }

    private void StartNewChapter1()
    {
        // Start a new game from the beginning of Chapter 1
        PlayerPrefs.DeleteKey("SavedGame"); // Clear any existing save
        SceneManager.LoadScene("ForestScene"); // Replace with your scene name
    }
}
