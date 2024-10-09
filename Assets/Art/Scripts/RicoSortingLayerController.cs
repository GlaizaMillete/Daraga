using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneSortingLayer
{
    public string sceneName;
    public string sortingLayerName;
    public int sortingOrder;
}

public class RicoSortingLayerController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [Header("Scene-Specific Sorting Layers")]
    public List<SceneSortingLayer> sceneSortingLayers;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if spriteRenderer is null
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject.");
            return; // Exit early to prevent further errors
        }

        UpdateSortingLayer();
    }

    void OnEnable()
    {
        // Subscribe to the scene change event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe from the event when object is disabled
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Method to update Rico's sorting layer based on the scene
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateSortingLayer();
    }

    private void UpdateSortingLayer()
    {
        if (spriteRenderer == null) return; // Check if spriteRenderer is still valid

        string currentScene = SceneManager.GetActiveScene().name;

        foreach (var sceneSortingLayer in sceneSortingLayers)
        {
            if (sceneSortingLayer.sceneName == currentScene)
            {
                spriteRenderer.sortingLayerName = sceneSortingLayer.sortingLayerName;
                spriteRenderer.sortingOrder = sceneSortingLayer.sortingOrder;
                return;  // Exit once we've found and applied the correct settings
            }
        }

        // Fallback if no scene match is found
        spriteRenderer.sortingLayerName = "Default"; // Change this to your default layer
        spriteRenderer.sortingOrder = 0;
    }
}