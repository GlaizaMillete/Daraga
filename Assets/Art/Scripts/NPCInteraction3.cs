/*using UnityEngine;

public class NPCInteraction3 : MonoBehaviour
{
    [SerializeField]
    private string achievementTag;  // Make this editable in the Inspector

    [SerializeField]
    private GameObject parentObject;  // Reference to the parent object in the Inspector

    public void Start()
    {
        // Debug log to track if the achievementTag and parentObject are set correctly
        Debug.Log("Achievement Tag: " + achievementTag);
        Debug.Log("Parent Object: " + parentObject?.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InteractWithNPC();
        }
    }

    public void InteractWithNPC()
    {
        // Check if achievementTag and parentObject are properly set
        if (string.IsNullOrEmpty(achievementTag))
        {
            Debug.LogWarning("Achievement Tag is empty or null!");
            return;
        }

        if (parentObject == null)
        {
            Debug.LogWarning("Parent Object is not set!");
            return;
        }

        // Log for debugging
        Debug.Log($"Interacting with NPC. Achievement Tag: {achievementTag}, Parent Object: {parentObject.name}");

        // Find the GameplayMenuManager component in the scene
        GameplayMenuManager gameplayMenuManager = FindObjectOfType<GameplayMenuManager>();

        // Check if GameplayMenuManager was found
        if (gameplayMenuManager != null)
        {
            // Call UnlockAchievement directly if the parent object and achievement tag are valid
            gameplayMenuManager.UnlockAchievement(achievementTag, parentObject);
        }
        else
        {
            Debug.LogError("GameplayMenuManager not found!");
        }
    }
}*/