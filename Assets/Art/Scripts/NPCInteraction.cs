using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public QuestManager questManager;
    public List<string> expectedItems;  // List of expected items

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    // This method will be called when the player gives an item to the NPC
    public void ReceiveItem(string itemName)
    {
        if (expectedItems.Contains(itemName))
        {
            // Handle the item receipt logic here
            Debug.Log("Received expected item: " + itemName);
            // Additional logic for completing the quest or providing a reward
        }
        else
        {
            Debug.Log("This NPC does not need that item.");
        }
    }

    // Example interaction method when the player interacts with the NPC
    public void OnPlayerInteract(string questName)
    {
        if (questManager != null)
        {
            questManager.TriggerQuest(questName);
        }
    }
}
