using UnityEngine;
using UnityEngine.UI;

public class AchievementsTab : MonoBehaviour
{
    public GameObject achievementPrefab; // Assign the achievement prefab here
    public Transform contentParent; // Assign the Content object of the Scroll View here

    // This is a sample data structure. Replace with your own achievement data.
    [System.Serializable]
    public class AchievementData
    {
        public Sprite icon;
        public string title;
        public string description;
    }

    public AchievementData[] achievements;

    void Start()
    {
        PopulateAchievements();
    }

    void PopulateAchievements()
    {
        foreach (var achievement in achievements)
        {
            // Instantiate a new achievement entry from the prefab
            GameObject newAchievement = Instantiate(achievementPrefab, contentParent);

            // Set the icon, title, and description
            newAchievement.transform.Find("Icon").GetComponent<Image>().sprite = achievement.icon;
            newAchievement.transform.Find("Title").GetComponent<Text>().text = achievement.title;
            newAchievement.transform.Find("Description").GetComponent<Text>().text = achievement.description;
        }
    }
}
