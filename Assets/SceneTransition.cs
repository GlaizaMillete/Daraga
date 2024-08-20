using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public string nextSceneName = "ForestScene"; // Set this to the name of the scene you want to load next

    void Start()
    {
        // Subscribe to the timeline's end event
        if (playableDirector != null)
        {
            playableDirector.stopped += OnPlayableDirectorStopped;
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector director)
    {
        // Check if the timeline that finished is the one we're interested in
        if (director == playableDirector)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    void OnDestroy()
    {
        // Unsubscribe from the event when this object is destroyed
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnPlayableDirectorStopped;
        }
    }
}
