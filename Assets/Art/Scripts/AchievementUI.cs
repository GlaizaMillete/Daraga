using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    public Text achievementText;  // The UI text to display the achievement status
    public string[] npcNames;  // List of NPC names to track

    void Start()
    {
        UpdateAchievementStatus();
    }

    // Update the achievement status in the UI
    public void UpdateAchievementStatus()
    {
        string status = AchievementManager.instance.GetItemStatus();
        achievementText.text = "Item Status: " + status + "\n";

        // Update NPC interaction statuses
        foreach (string npcName in npcNames)
        {
            string npcStatus = AchievementManager.instance.GetNPCStatus(npcName);
            achievementText.text += npcName + ": " + npcStatus + "\n";
        }
    }
}
