using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArrowExitDoor : MonoBehaviour
{
    public string villageSceneName = "VillageScene";  // The scene to load when exiting the house
    public Button arrowExitButton;  // The arrow exit button (UI) for exiting
    public GameObject door;  // Reference to the door GameObject for alignment
    public float offsetY = 50f;  // Vertical offset for the button position above the door

    private RectTransform buttonRectTransform;  // Reference to the button's RectTransform

    void Start()
    {
        // Ensure references are set and objects exist
        if (arrowExitButton != null)
        {
            arrowExitButton.gameObject.SetActive(true);  // Keep the button visible
            arrowExitButton.onClick.AddListener(OnArrowExitButtonClicked);  // Add click listener

            // Get RectTransform for adjusting position
            buttonRectTransform = arrowExitButton.GetComponent<RectTransform>();
        }
    }

    void Update()
    {
        // Update the button position to stay above the door
        if (buttonRectTransform != null && door != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(door.transform.position);
            screenPosition.y += offsetY;  // Apply offset to position the button above the door
            buttonRectTransform.position = screenPosition;
        }
    }

    // Called when the arrow exit button is clicked
    void OnArrowExitButtonClicked()
    {
        // Load the specified village scene
        SceneManager.LoadScene(villageSceneName);
    }
}
