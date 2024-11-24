using System.Collections.Generic;
using UnityEngine;

public class AchievementManager1 : MonoBehaviour
{
    [System.Serializable]
    public class AchievementUI
    {
        public string questName; // Name of the quest
        public GameObject stampPrefab; // Reference to the stamp prefab
        [HideInInspector] public GameObject stampInstance; // Instance of the stamp in the scene
    }

    [Header("Achievements")]
    public List<Achievements> achievements; // List of all achievements
    public List<AchievementUI> achievementUIs; // UI references for achievements

    public Transform achievementTabParent; // Parent object for achievement tab stamps

    private void Start()
    {
        InitializeUI(); // Ensure all stamps are created and hidden initially
        LoadAchievements();
    }

    private void InitializeUI()
    {
        foreach (var ui in achievementUIs)
        {
            if (ui.stampPrefab != null && achievementTabParent != null)
            {
                if (ui.stampInstance == null) // Only instantiate if not already instantiated
                {
                    ui.stampInstance = Instantiate(ui.stampPrefab, achievementTabParent);
                    ui.stampInstance.SetActive(false); // Hide initially
                }
            }
            else
            {
                Debug.LogWarning($"Missing prefab or parent for {ui.questName}");
            }
        }
    }

    public void CompleteQuest(string questName)
    {
        // Find the achievement by name
        var achievement = achievements.Find(a => a.questName == questName);
        if (achievement != null && !achievement.isCompleted)
        {
            achievement.isCompleted = true;

            // Find and activate the corresponding stamp
            var ui = achievementUIs.Find(a => a.questName == questName);
            if (ui != null && ui.stampInstance != null)
            {
                ui.stampInstance.SetActive(true); // Show the stamp
                Debug.Log($"Stamp activated for quest: {questName}");
            }
            else
            {
                Debug.LogWarning($"Stamp instance not found for quest: {questName}");
            }

            SaveAchievements(); // Save progress
        }
        else
        {
            Debug.LogWarning($"Quest '{questName}' not found or already completed.");
        }
    }

    public void SaveAchievements()
    {
        foreach (var achievement in achievements)
        {
            string key = $"Achievement_{achievement.questName}_Completed";
            PlayerPrefs.SetInt(key, achievement.isCompleted ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    public void LoadAchievements()
    {
        foreach (var achievement in achievements)
        {
            string key = $"Achievement_{achievement.questName}_Completed";
            achievement.isCompleted = PlayerPrefs.GetInt(key, 0) == 1;

            var ui = achievementUIs.Find(a => a.questName == achievement.questName);
            if (ui != null && ui.stampInstance != null)
            {
                ui.stampInstance.SetActive(achievement.isCompleted); // Reflect the saved state
                Debug.Log($"Stamp for {achievement.questName} set to {achievement.isCompleted}");
            }
        }
    }
}
