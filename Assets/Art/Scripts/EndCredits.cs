using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Ensure this is included to use IEnumerator

public class EndCredits : MonoBehaviour
{
    [SerializeField] private float creditsDuration = 30f; // Duration of the credits in seconds
    [SerializeField] private string homeScreenScene = "Homescreen"; // Name of the home screen scene

    private void Start()
    {
        // Start the coroutine to load the home screen after the credits duration
        StartCoroutine(EndCreditsCoroutine());
    }

    private IEnumerator EndCreditsCoroutine()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(creditsDuration);
        
        // Load the home screen scene
        SceneManager.LoadScene(homeScreenScene);
    }
}
