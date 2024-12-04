using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoystickController : MonoBehaviour
{
    private static JoystickController instance;

    private void Awake()
    {
        // Ensure only one instance of the joystick exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent the joystick from being destroyed
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
        }
        else
        {
            Destroy(gameObject); // Destroy any additional joystick instances
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Replace "YourSceneName" with the name of the specific scene where you want the joystick destroyed
        if (scene.name == "Chapter3")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
