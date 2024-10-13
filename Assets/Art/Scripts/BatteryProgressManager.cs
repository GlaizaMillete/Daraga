/*using UnityEngine;
using UnityEngine.UI;

public class BatteryProgressManager : MonoBehaviour
{
    public Image batteryFillImage; 
    public static BatteryProgressManager batteryProgressManager; // Reference to the Battery Fill Image

    void TaskCompleted()
    {
    // Assuming the player completed 50% of Chapter 1
    batteryProgressManager.SaveProgress(50);  // Save and update the progress
    }

    void Awake()
    {
    DontDestroyOnLoad(gameObject);
    }   


    private void Start()
    {
        // Load the saved progress for Chapter 1
        int progress = PlayerPrefs.GetInt("chapter1button", 0);

        // Update the battery fill based on the progress
        UpdateBatteryFill(progress);
    }

    // Function to save progress and update the battery fill
    public void SaveProgress(int newProgress)
    {
        // Save the progress percentage using PlayerPrefs
        PlayerPrefs.SetInt("chapter1button", newProgress);
        PlayerPrefs.Save();

        // Update the battery fill based on the new progress
        UpdateBatteryFill(newProgress);
    }

    private void UpdateBatteryFill(int progress)
    {
        // Assume the progress is between 0 and 100. Normalize it to a 0-1 range for the Image fill amount.
        float fillAmount = Mathf.Clamp01(progress / 100f);

        // Set the battery fill amount based on the progress
        batteryFillImage.fillAmount = fillAmount;

         // Debug log to check the progress
        Debug.Log("Battery fill updated to: " + (progress * 100) + "%");

        // Save progress to GameManager
        GameManager.instance.SaveProgress(progress);
    }

    public void CompleteChapter1()
    {
        batteryProgressManager.SaveProgress(100);  // Save and show 100% battery when Chapter 1 is finished
    }

}*/
