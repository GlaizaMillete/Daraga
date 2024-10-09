using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupController : MonoBehaviour
{
    public GameObject messagePopup; 
    public float popupDelay = 2f;
    public string nextSceneName = "YourNextScene";

    void Start()
    {
        if (messagePopup != null)
        {
            messagePopup.SetActive(false); // Ensure popup is hidden at the start
        }
    }

    public void OnFishCaught()
    {
        Debug.Log("OnFishCaught called");
        StartCoroutine(ShowPopupAfterDelay());
    }

    // Changed to public to allow access from other scripts
    public IEnumerator ShowPopupAfterDelay()
    {
        Debug.Log("Waiting for " + popupDelay + " seconds before showing the popup.");
        yield return new WaitForSeconds(popupDelay);
        ShowMessagePopup();
    }

    private void ShowMessagePopup()
    {
        if (messagePopup != null)
        {
            Debug.Log("Showing popup message");
            messagePopup.SetActive(true);
            SetPopupToCenter();

            Invoke("GoToNextScene", 3f); // Go to next scene after 3 seconds
        }
        else
        {
            Debug.LogWarning("messagePopup is null! Please assign it in the Inspector.");
        }
    }

   private void SetPopupToCenter()
{
    RectTransform rt = messagePopup.GetComponent<RectTransform>();

    if (rt != null) // Only proceed if there's a RectTransform
    {
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f);
        rt.anchoredPosition = Vector2.zero;

        Debug.Log("Popup position: " + rt.anchoredPosition);
    }
    else
    {
        Debug.LogWarning("messagePopup is not a UI element or doesn't have a RectTransform.");
    }
}
    private void GoToNextScene()
    {
        Debug.Log("Transitioning to the next scene: " + nextSceneName);
        SceneManager.LoadScene(3); 
    }
}
