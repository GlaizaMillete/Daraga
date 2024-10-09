using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;

    // Track if the item is collected
    private bool itemCollected = false;

    // Track which NPCs the player has spoken to (using NPC names as keys)
    private Dictionary<string, bool> npcInteractions = new Dictionary<string, bool>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Ensure the AchievementManager persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this method when the player collects an item
    public void CollectItem()
    {
        itemCollected = true;
        Debug.Log("Item has been collected!");
    }

    // Call this method when the player talks to an NPC for the first time
    public void TalkToNPC(string npcName)
    {
        // Check if the player has already talked to this NPC
        if (!npcInteractions.ContainsKey(npcName))
        {
            npcInteractions[npcName] = true;
            Debug.Log("Talked to NPC: " + npcName);
        }
        else
        {
            Debug.Log("Already talked to NPC: " + npcName);
        }
    }

    // Check if the player has spoken to a specific NPC
    public bool HasTalkedToNPC(string npcName)
    {
        // Return true if the player has talked to the NPC, otherwise false
        return npcInteractions.ContainsKey(npcName) && npcInteractions[npcName];
    }

    // Get the status of the item collection
    public string GetItemStatus()
    {
        // Return a message indicating if the item has been collected or not
        return itemCollected ? "Item Collected" : "This object has not been found";
    }

    // Get the status of talking to a specific NPC
    public string GetNPCStatus(string npcName)
    {
        // Return a message indicating if the player has talked to the NPC or not
        return HasTalkedToNPC(npcName) ? "Talked to " + npcName : "Haven't talked to " + npcName;
    }
}
