using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string lastSceneName;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLastScene(string sceneName)
    {
        lastSceneName = sceneName;
    }
}
