using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SickleController : MonoBehaviour
{
    public GameObject messagePopup;      // Reference to the message popup
    public GameObject sicklePrefabPopup; // Reference to the sickle prefab that will pop up
    public float popupDelay = 1f;
    public string nextSceneName = "YourNextScene"; // Set this to the scene you want to load
    public string targetTag = "Sickle"; // The tag for the SICKLE 1 object

    private bool objectFound = false;

    void Start()
    {
        // Ensure popup and sickle are hidden at the start
        if (messagePopup != null)
        {
            messagePopup.SetActive(false); 
        }

        if (sicklePrefabPopup != null)
        {
            sicklePrefabPopup.SetActive(false); 
        }
    }

    void Update()
    {
        // Detect object based on touch input (for mobile)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

                // If the player touches SICKLE 1 and it has the correct tag
                if (hit.collider != null && hit.collider.CompareTag(targetTag) && !objectFound)
                {
                    objectFound = true; // Ensure this only triggers once
                    Debug.Log(targetTag + " found!");
                    OnSickleFound(); // Call the popup logic
                }
            }
        }
    }

    public void OnSickleFound()
    {
        Debug.Log("OnSickleFound called");

        StartCoroutine(ShowPopupAfterDelay());
    }

    public IEnumerator ShowPopupAfterDelay()
    {
        Debug.Log("Waiting for " + popupDelay + " seconds before showing the popup.");
        yield return new WaitForSeconds(popupDelay);
        Debug.Log("Delay finished, showing popup now.");
        ShowMessagePopup();
    }

    private void ShowMessagePopup()
    {
        // Show the sickle prefab and the message popup
        if (messagePopup != null && sicklePrefabPopup != null)
        {
            Debug.Log("Showing popup message and sickle prefab");  
            messagePopup.SetActive(true);  // Show the message box
            sicklePrefabPopup.SetActive(true);  // Show the sickle prefab (pop-up visual)
            SetPopupToCenter(messagePopup);
            SetPopupToCenter(sicklePrefabPopup);

            Invoke("GoToNextScene", 3f);  // Go to the next scene after 3 seconds
        }
        else
        {
            Debug.LogWarning("Either messagePopup or sicklePrefabPopup is null! Please assign them in the Inspector.");
        }
    }

    // Helper function to center the popup elements (message and sickle)
    private void SetPopupToCenter(GameObject popup)
    {
        RectTransform rt = popup.GetComponent<RectTransform>();

        if (rt != null) // Only proceed if there's a RectTransform (for UI elements)
        {
            rt.anchorMin = new Vector2(0.5f, 0.5f);
            rt.anchorMax = new Vector2(0.5f, 0.5f);
            rt.pivot = new Vector2(0.5f, 0.5f);
            rt.anchoredPosition = Vector2.zero;

            Debug.Log("Popup position: " + rt.anchoredPosition);
        }
        else
        {
            Debug.LogWarning("Popup is not a UI element or doesn't have a RectTransform.");
        }
    }

    private void GoToNextScene()
    {
        Debug.Log("Transitioning to the next scene: " + nextSceneName);
        SceneManager.LoadScene(nextSceneName); // Load scene by name
    }
}