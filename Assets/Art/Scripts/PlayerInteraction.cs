using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject[] itemPrefabs;  // Array of item prefab references
    private NPCInteraction npc;
    private bool nearNPC = false;
    private string npcName = "";

    // This will store Rico's last position before being destroyed
    private Vector3 ricoPosition;

    // Dictionary to map NPC names to corresponding quest scene names
    private Dictionary<string, string> npcQuestScenes = new Dictionary<string, string>()
    {
        { "ALON-NPC", "Fishing" },
        // Add more NPC and their quest scene mappings here...
    };

    void Update()
    {
        if (nearNPC && Input.touchCount > 0)  // Mobile touch input for interacting
        {
            foreach (var itemPrefab in itemPrefabs)
            {
                if (itemPrefab.activeSelf && PlayerPrefs.GetInt(itemPrefab.name, 0) == 1)  // Check if the item is collected
                {
                    GiveItemToNPC(itemPrefab);
                    break;  // Exit loop after giving the item
                }
            }
        }
    }

    void GiveItemToNPC(GameObject item)
    {
        if (npc != null)
        {
            npc.ReceiveItem(item.name);
            Debug.Log("Item given to NPC: " + item.name);
            SaveCollectedItem(item.name);  // Save the item to PlayerPrefs
            
            // Check if this NPC has a quest and transition to their corresponding quest scene
            if (npcQuestScenes.ContainsKey(npcName))
            {
                // Save Rico's position before destroying him
                ricoPosition = transform.position;  
                
                StartCoroutine(CompleteNPCQuest(npcName));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            npc = other.GetComponent<NPCInteraction>();
            npcName = other.gameObject.name;
            nearNPC = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            nearNPC = false;
            npc = null;
            npcName = "";
        }
    }

    void SaveCollectedItem(string itemName)
    {
        PlayerPrefs.SetInt(itemName, 1);  // Mark the item as collected
        PlayerPrefs.Save();
    }

    // Coroutine to handle quest after dialogue with any NPC
    IEnumerator CompleteNPCQuest(string npcName)
    {
        yield return new WaitForSeconds(2);  // Wait for dialogue completion
        Debug.Log($"Transitioning to {npcQuestScenes[npcName]} for NPC: {npcName}.");
        
        // Destroy Rico when entering the Fishing quest scene
        Destroy(gameObject);  // Destroy Rico only for ALON-NPC
        
        SceneManager.LoadScene(npcQuestScenes[npcName]);  // Load the corresponding quest scene
    }
}
