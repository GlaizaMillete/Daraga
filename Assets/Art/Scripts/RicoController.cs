using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;  // Add this to handle Cinemachine

public class RicoController : MonoBehaviour
{
    private static RicoController instance;

    private void Awake()
    {
        // Ensure only one instance of Rico exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // Prevent Rico from being destroyed when switching scenes
            
            // Find and assign the Cinemachine camera's target at runtime
            CinemachineVirtualCamera vcam = FindObjectOfType<CinemachineVirtualCamera>();
            if (vcam != null)
            {
                vcam.Follow = transform;  // Ensure the camera follows Rico
            }
        }
        else
        {
            Destroy(gameObject);  // Destroy any additional Rico instances
        }
    }

    // This method will reassign the camera to Rico if needed after scene changes
    private void OnSceneLoaded()
    {
        CinemachineVirtualCamera vcam = FindObjectOfType<CinemachineVirtualCamera>();
        if (vcam != null)
        {
            vcam.Follow = transform;  // Reassign the camera to follow Rico
        }
    }
}

