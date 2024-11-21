using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterHouseTrigger : MonoBehaviour
{
    public GameObject rico;  // Reference to Rico
    public string houseSceneName = "LiwaywayHouse";  // The scene to load when Rico enters the house
    public Button arrowhouseButton;  // The arrow button (UI) for entrance
    public GameObject door;  // Reference to the door GameObject for alignment
    public float offsetY = 50f;  // Vertical offset for the button position above the door
    
    private Vector3 ricoInitialPosition;  // Stores Rico's initial position
    private RectTransform buttonRectTransform;  // Reference to the button's RectTransform
    private bool isNearDoor = false;  // To check if Rico is near the door

    void Start()
    {
        // Ensure references are set and objects exist
        if (arrowhouseButton != null)
        {
            arrowhouseButton.gameObject.SetActive(false);  // Initially hide the button
            arrowhouseButton.onClick.AddListener(OnArrowButtonClicked);  // Add click listener

            // Get RectTransform for adjusting position
            buttonRectTransform = arrowhouseButton.GetComponent<RectTransform>();
        }
    }

    void Update()
    {
        // Update the button position if Rico is near the door
        if (isNearDoor && buttonRectTransform != null && door != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(door.transform.position);
            screenPosition.y += offsetY;  // Apply offset to position the button above the door
            buttonRectTransform.position = screenPosition;
        }
    }

    // Trigger when Rico enters the door zone
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearDoor = true;
            if (arrowhouseButton != null)
            {
                arrowhouseButton.gameObject.SetActive(true);  // Show the button
            }
        }
    }

    // Trigger when Rico exits the door zone
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearDoor = false;
            if (arrowhouseButton != null)
            {
                arrowhouseButton.gameObject.SetActive(false);  // Hide the button
            }
        }
    }

    // Called when the arrow button is clicked
    void OnArrowButtonClicked()
    {
        // Store Rico's current position
        if (rico != null)
        {
            ricoInitialPosition = rico.transform.position;
            PlayerPrefs.SetFloat("RicoX", ricoInitialPosition.x);
            PlayerPrefs.SetFloat("RicoY", ricoInitialPosition.y);
            PlayerPrefs.SetFloat("RicoZ", ricoInitialPosition.z);
        }

        // Load the specified house scene
        SceneManager.LoadScene(houseSceneName);
    }
}
