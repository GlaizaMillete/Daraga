using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueLiwaywayTrigger : MonoBehaviour
{
    public DialogueLiwayway.Dialogue dialogue;

    private Camera mainCamera;

    private void Start()
    {
        // Get the main camera and check if it is valid
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Ensure there is a camera tagged 'MainCamera'.");
        }

        // Ensure there is an EventSystem in the scene
        if (EventSystem.current == null)
        {
            Debug.LogError("No EventSystem found. Add one to the scene.");
        }
    }

    public void TriggerDialogue()
    {
        // Check if the DialogueLiwayway instance is available and trigger the dialogue
        if (DialogueLiwayway.Instance != null)
        {
            DialogueLiwayway.Instance.StartDialogue(dialogue);
        }
        else
        {
            Debug.LogError("DialogueLiwayway instance not found.");
        }
    }

    private void Update()
    {
        // Check for touch input (mobile devices)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Check if the touch is not over a UI element (EventSystem)
            if (EventSystem.current != null && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                // Log touch position and camera details for debugging
                Debug.Log("Touch detected at: " + Input.GetTouch(0).position);

                // Convert touch position to world space
                if (mainCamera != null)
                {
                    Vector3 touchPosition = Input.GetTouch(0).position;
                    touchPosition.z = 10; // Set the distance from the camera
                    Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
                    worldPosition.z = 0; // Ensure the z-axis is set to 0 for 2D world

                    Debug.Log("Converted world position: " + worldPosition);

                    // Check if the touch position overlaps with the collider of the object
                    Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

                    // Log the hit collider for debugging
                    if (hitCollider != null)
                    {
                        Debug.Log("Hit collider: " + hitCollider.gameObject.name);

                        // Trigger the dialogue if the correct object is touched
                        if (hitCollider.gameObject == gameObject)
                        {
                            TriggerDialogue();
                        }
                    }
                    else
                    {
                        Debug.Log("No collider hit at the touched position.");
                    }
                }
            }
            else
            {
                Debug.Log("Touch is over a UI element, ignoring.");
            }
        }
    }
}