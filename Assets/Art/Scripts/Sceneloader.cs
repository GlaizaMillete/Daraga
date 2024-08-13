using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("OpeningScene");

    }

    // Method to unload a scene
    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync("OpeningScene");
    }
}
