using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // For scene loading
using UnityEngine.UI; 

public class skipcontroller : MonoBehaviour
{
    public Button skipButton;  // Reference to your skip button

    void Start()
    {
        // Ensure the button is assigned in the Inspector
        if (skipButton != null)
        {
            // Add a listener to call the SkipToGame method when the button is clicked
            skipButton.onClick.AddListener(SkipToGame);
        }
    }

    // This method will be called when the button is clicked
    void SkipToGame()
    {
        // Replace "FirstSceneName" with the actual name of your game's first scene
        SceneManager.LoadScene("ForestScene");
    }
}
