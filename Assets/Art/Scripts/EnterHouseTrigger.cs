using UnityEngine;
using UnityEngine.SceneManagement;  // For scene loading
using UnityEngine.UI;  // For UI components

public class EnterHouseTrigger : MonoBehaviour
{
    public string houseSceneName = "LiwaywayHouse";  // The scene name to load when Rico enters the house
    public GameObject arrowhouseImage;  // The arrow image to indicate the entrance
    private bool isNearDoor = false;  // To check if Rico is near the door

    // Start is called before the first frame update
    void Start()
    {
        if (arrowhouseImage != null)
        {
            // Ensure the arrow is hidden at the start
            arrowhouseImage.SetActive(false);
        }
    }

    // Detect when Rico enters the trigger zone (door area)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Ensure the player is tagged as "Player"
        {
            isNearDoor = true;
            if (arrowhouseImage != null)
            {
                arrowhouseImage.SetActive(true);  // Show the arrow image when near the door
            }
        }
    }

    // Detect when Rico exits the trigger zone
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearDoor = false;
            if (arrowhouseImage != null)
            {
                arrowhouseImage.SetActive(false);  // Hide the arrow when leaving the door area
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Rico is near the door and the player touches the arrowhouse image
        if (isNearDoor && Input.GetMouseButtonDown(0))  // Left mouse button or touch input
        {
            Vector3 mousePos = Input.mousePosition;
            RectTransform arrowRect = arrowhouseImage.GetComponent<RectTransform>();

            if (RectTransformUtility.RectangleContainsScreenPoint(arrowRect, mousePos, null))
            {
                // Load the house scene or perform the house entry action
                SceneManager.LoadScene(houseSceneName);  // Transition to Liwayway's house
            }
        }
    }
}
