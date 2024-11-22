using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AchievementManager1 : MonoBehaviour
{
    [System.Serializable]
    public class AchievementUI
    {
        public string questName; // Name of the quest
        public GameObject stamp; // Stamp GameObject (UI element)
    }

    public List<Achievements> achievements; // List of achievements (Scriptable Objects)
    public List<AchievementUI> achievementUIs; // UI mapping for quests and their stamps

    // Initialize the achievement system
    private void Start()
    {
        foreach (var ui in achievementUIs)
        {
            // Hide all stamps initially
            if (ui.stamp != null)
            {
                ui.stamp.SetActive(false);
            }
        }
    }

    // Mark a quest as completed and update the UI
    public void CompleteQuest(string questName)
    {
        // Find the achievement in the list
        Achievements achievement = achievements.Find(a => a.questName == questName);

        if (achievement != null && !achievement.isCompleted)
        {
            achievement.isCompleted = true; // Mark as completed

            // Find the UI component associated with this quest
            AchievementUI ui = achievementUIs.Find(a => a.questName == questName);
            if (ui != null && ui.stamp != null)
            {
                ui.stamp.SetActive(true); // Show the stamp
                Debug.Log($"Quest '{questName}' completed! Stamp revealed.");
            }
        }
        else
        {
            Debug.LogWarning($"Quest '{questName}' not found or already completed.");
        }
    }
}
