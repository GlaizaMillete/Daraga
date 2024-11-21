using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    public GameObject loadingCanvas;  // Reference to the loading canvas
    public Image loadingImage;        // Reference to the loading image

    private void Start()
    {
        // Ensure the loading canvas is disabled initially
        if (loadingCanvas != null)
        {
            loadingCanvas.SetActive(false);
        }
    }

    // Public method to load a scene by name
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // Coroutine to load the scene asynchronously
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Activate the loading canvas
        loadingCanvas.SetActive(true);

        // Start loading the scene asynchronously
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the scene is fully loaded
        while (!operation.isDone)
        {
            // Optionally, you can add a loading progress display here
            // loadingImage.fillAmount = operation.progress;  // (if using a progress image)
            yield return null;
        }

        // Once the loading is done, deactivate the loading canvas
        loadingCanvas.SetActive(false);
    }
}
