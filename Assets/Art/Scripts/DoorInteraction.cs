using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load when the door is clicked

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found. Ensure the scene has a camera tagged as 'MainCamera'.");
        }
    }

    private void Update()
    {
        // Detect a click or tap
        Vector3 inputPosition = Vector3.zero;

        if (Input.GetMouseButtonDown(0))
        {
            inputPosition = Input.mousePosition;
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            inputPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        // Convert the input position to world space
        inputPosition.z = 10f; // Adjust for 2D setup
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(inputPosition);
        worldPosition.z = 0f; // For 2D, ensure the z-axis is zero

        // Check if the player clicked on the door's collider
        Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

        if (hitCollider != null && hitCollider.gameObject == gameObject)
        {
            Debug.Log("Door clicked!");
            GoBackToScene();  // Load the target scene
        }
    }

    // Function to load the specified scene
    private void GoBackToScene()
    {
        Debug.Log("Returning to scene: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}