using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChapterPopup : MonoBehaviour
{
    public GameObject chapterPopup; // Assign the popup UI element in the inspector

    private void Start()
    {
        ShowChapterPopup();
    }

    public void ShowChapterPopup()
    {
        chapterPopup.SetActive(true);
        StartCoroutine(HidePopupAfterDelay(3f)); // Hide the popup after 3 seconds
    }

    private IEnumerator HidePopupAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        chapterPopup.SetActive(false);
    }
}
