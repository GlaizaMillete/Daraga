using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistCamera : MonoBehaviour
{
    private static PersistCamera instance;

    void Awake()
    {
        // Ensure that only one instance of the camera exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Prevent this GameObject from being destroyed between scenes
        }
        else
        {
            Destroy(gameObject);  // If another instance exists, destroy this one
        }
    }

    void Start()
    {
        // Ensure the camera is following the player in the new scene
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Cinemachine.CinemachineVirtualCamera vcam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
            vcam.Follow = player.transform;
        }
    }

    // Optional: Automatically find and follow Rico after scene load
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Cinemachine.CinemachineVirtualCamera vcam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
            vcam.Follow = player.transform;
        }
    }
}
