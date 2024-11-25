using UnityEngine;

public class NPCItemCollector : MonoBehaviour
{
    public string npcName; // Name of the NPC
    public string itemName; // Name of the item being collected
    private bool isInteractionComplete = false; // Ensure interaction happens only once

    private AchievementManagerTrack achievementManager;

    public void Start()
    {
        // Reference the AchievementManagerTrack in the scene
        achievementManager = FindObjectOfType<AchievementManagerTrack>();
    }

    // Triggered when the player interacts with the NPC
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isInteractionComplete)
        {
            CompleteInteraction();
        }
    }

    public void CompleteInteraction()
    {
        isInteractionComplete = true; // Prevent duplicate interactions
        Debug.Log($"Interaction completed with {npcName}, item: {itemName}!");

        // Unlock achievements for NPC interaction and item collection
        if (!string.IsNullOrEmpty(npcName))
        {
            achievementManager.OnTalkToNPC(npcName);
        }
        if (!string.IsNullOrEmpty(itemName))
        {
            achievementManager.OnCollectItem(itemName);
        }
    }
}
