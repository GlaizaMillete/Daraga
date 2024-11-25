using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementManagerTrack : MonoBehaviour
{
    public static AchievementManagerTrack Instance { get; private set; } // Singleton instance

    // UI Elements
    public GameObject popupAchievement;
    public TextMeshProUGUI popupText;
    public GameObject achievementContent;

    // Achievement Sprites
    public GameObject cphouse;
    public GameObject alon;
    public GameObject riddletalim;
    public GameObject riddlemarina;
    public GameObject riddlemarisa;
    public GameObject riddlebagwis;
    public GameObject riddledalisay;
    public GameObject helpliwayway;
    public GameObject liwayway;
    public GameObject magayon;
    public GameObject tilapia;
    public GameObject makusog;

    // Achievement state tracking
    private HashSet<string> unlockedAchievements = new HashSet<string>();

    // Popup duration
    public float popupDuration = 2f;

    // For initialization
    private bool initialized = false;

    private void Awake()
    {
        // Implement Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (!initialized)
        {
            HideAllAchievements();
            popupAchievement.SetActive(false); // Ensure the popup is hidden at the start
            initialized = true;
        }
        else
        {
            RestoreAchievementState(); // Only restore the achievement state without unlocking
        }
    }

    // Called when an achievement is unlocked
    public void UnlockAchievement(string achievementName)
    {
        if (unlockedAchievements.Contains(achievementName)) return;

        unlockedAchievements.Add(achievementName);
        PlayerPrefs.SetInt(achievementName, 1); // Save achievement
        PlayerPrefs.Save();

        ShowPopup(achievementName);
        UpdateAchievementContent(achievementName);
    }

    // Show popup
    private void ShowPopup(string achievementName)
    {
        popupText.text = $"Achievement Unlocked: {achievementName}!";
        popupAchievement.SetActive(true);
        StartCoroutine(HidePopupAfterDelay());
    }

    private IEnumerator HidePopupAfterDelay()
    {
        yield return new WaitForSeconds(popupDuration);
        popupAchievement.SetActive(false);
    }

    // Update content
    private void UpdateAchievementContent(string achievementName)
    {
        switch (achievementName)
        {
            case "cphouse": cphouse.SetActive(true); break;
            case "alon": alon.SetActive(true); break;
            case "riddletalim": riddletalim.SetActive(true); break;
            case "riddlemarina": riddlemarina.SetActive(true); break;
            case "riddlemarisa": riddlemarisa.SetActive(true); break;
            case "riddlebagwis": riddlebagwis.SetActive(true); break;
            case "riddledalisay": riddledalisay.SetActive(true); break;
            case "helpliwayway": helpliwayway.SetActive(true); break;
            case "liwayway": liwayway.SetActive(true); break;
            case "magayon": magayon.SetActive(true); break;
            case "makusog": makusog.SetActive(true); break;
        }
    }

    // Restore achievement state after a scene load
    private void RestoreAchievementState()
    {
        foreach (string achievementName in unlockedAchievements)
        {
            if (PlayerPrefs.GetInt(achievementName, 0) == 1 && !unlockedAchievements.Contains(achievementName))
            {
                unlockedAchievements.Add(achievementName);
                UpdateAchievementContent(achievementName);
            }
        }
    }

    public void OnTalkToNPC(string npcName)
    {
        if (!unlockedAchievements.Contains(npcName)) 
        {
            UnlockAchievement(npcName);
        }
    }

    public void OnCollectItem(string itemName)
    {
        if (!unlockedAchievements.Contains(itemName))
        {
            UnlockAchievement(itemName);
        }
    }

    // Hide all achievements initially
    private void HideAllAchievements()
    {
        cphouse.SetActive(false);
        alon.SetActive(false);
        riddletalim.SetActive(false);
        riddlemarina.SetActive(false);
        riddlemarisa.SetActive(false);
        riddlebagwis.SetActive(false);
        riddledalisay.SetActive(false);
        helpliwayway.SetActive(false);
        liwayway.SetActive(false);
        magayon.SetActive(false);
        makusog.SetActive(false);
    }
}
