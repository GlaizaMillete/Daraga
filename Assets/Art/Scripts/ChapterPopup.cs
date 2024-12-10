using System.Collections;
using UnityEngine;

public class ChapterPopup : MonoBehaviour
{
    public GameObject chapterPopup; // Assign the popup UI element in the inspector
    public string chapterPopupKey = "ChapterPopupShown"; // Unique key for this scene's popup state

    private void Start()
    {
        // Check if the popup for this scene has been shown before
        if (!PlayerPrefs.HasKey(chapterPopupKey) || PlayerPrefs.GetInt(chapterPopupKey) == 0)
        {
            ShowChapterPopup();
            PlayerPrefs.SetInt(chapterPopupKey, 1); // Mark as shown
            PlayerPrefs.Save(); // Save the state
        }
    }

    public void ShowChapterPopup()
    {
        if (chapterPopup != null)
        {
            chapterPopup.SetActive(true);
            StartCoroutine(HidePopupAfterDelay(1f)); // Hide the popup after 3 seconds
        }
    }

    private IEnumerator HidePopupAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (chapterPopup != null)
        {
            chapterPopup.SetActive(false);
        }
    }

    public void SaveProgress()
    {
        // Save progress without resetting the popup state
        PlayerPrefs.Save();
    }

    public void ResetPopup()
    {
        // Optional: Use this method if you want to reset the popup state for debugging or testing
        PlayerPrefs.SetInt(chapterPopupKey, 0);
        PlayerPrefs.Save();
    }
}
