using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistAcrossScenes : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsOfType<PersistAcrossScenes>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reassign references here if necessary
        Debug.Log("Scene loaded: " + scene.name);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
