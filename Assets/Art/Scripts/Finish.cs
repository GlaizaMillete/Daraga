using System.Collections;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private string targetSceneName; // Assign this in the inspector
    [SerializeField] private Vector3 playerSpawnPosition; // Assign the player spawn position
    [SerializeField] private Vector3 cameraPosition; // Assign the camera position

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Transition to the target scene
            SceneController.instance.LoadSpecificScene(targetSceneName, playerSpawnPosition, cameraPosition);

            // Ensure the player's sorting layer is updated in the new scene
            StartCoroutine(UpdatePlayerSortingLayerAfterTransition());
        }
    }

    private IEnumerator UpdatePlayerSortingLayerAfterTransition()
    {
        // Wait for a frame to ensure the scene loads
        yield return null;

        // Call the sorting layer update
        PlayerSortingLayerManager sortingLayerManager = FindObjectOfType<PlayerSortingLayerManager>();
        if (sortingLayerManager != null)
        {
            sortingLayerManager.UpdatePlayerSortingLayer();
        }
    }
}
