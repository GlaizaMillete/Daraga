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

            // Allow duplicated GameplayMenuManager to handle its state independently
            StartCoroutine(HandleGameplayMenuManager());
        }
    }

    private IEnumerator HandleGameplayMenuManager()
    {
        // Wait for the new scene to load
        yield return null;

        // Ensure any new GameplayMenuManager instance initializes itself correctly
        GameplayMenuManager[] menuManagers = FindObjectsOfType<GameplayMenuManager>();
        foreach (var menuManager in menuManagers)
        {
            if (menuManager.menuPanel == null)
            {
                menuManager.menuPanel = GameObject.Find("MenuPanel");
            }
        }
    }
}
