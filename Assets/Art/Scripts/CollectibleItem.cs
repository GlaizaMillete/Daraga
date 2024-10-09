using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private bool hasCollected = false;

    public string itemName;  // The name of the item for identification in achievements and saving
    public GameObject achievementPopup;  // A UI popup for achievements (optional)

    void Start()
    {
        // Check if the item has been collected before
        if (PlayerPrefs.GetInt(itemName, 0) == 1)
        {
            hasCollected = true;
            gameObject.SetActive(false);  // Hide the item if already collected
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasCollected)
        {
            Collect();
        }
    }

    void Collect()
    {
        // Mark the object as collected
        hasCollected = true;

        // Perform actions upon collecting the item
        Debug.Log("Object Collected!");

        // Save collected item status
        PlayerPrefs.SetInt(itemName, 1);  // Save the collected item status
        PlayerPrefs.Save();

        // Trigger the achievement system
        AchievementManager.instance.CollectItem();  // No arguments needed

        // Optionally disable or destroy the object
        gameObject.SetActive(false);  // Or Destroy(gameObject);
    }
}
