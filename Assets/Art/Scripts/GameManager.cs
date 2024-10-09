using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Track whether the quest is completed
    public bool questCompleted = false;

    // Store the player's position to move them back to the NPC
    public Vector3 playerPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // This makes the GameManager persist between scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicates
        }
    }

    // Call this method to save the player's current position
    public void SavePlayerPosition(Vector3 position)
    {
        playerPosition = position;
    }

    // Method to mark the quest as completed
    public void CompleteQuest()
    {
        questCompleted = true;
    }
}