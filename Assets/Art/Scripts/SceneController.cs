using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSpecificScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1); // Adjust this to match the animation length
        SceneManager.LoadSceneAsync(sceneName);
        transitionAnim.SetTrigger("Start");

        // Reinitialize the joystick if needed
        Joystick movementJoystick = FindObjectOfType<Joystick>();
        if (movementJoystick != null)
        {
            movementJoystick.gameObject.SetActive(true);
        }
    }
}