using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class DialogueCharacter
{
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private Camera mainCamera;

    private void Start()
    {
        // Assign the main camera and check if it's found
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Ensure there is a camera with the 'MainCamera' tag.");
        }

        // Check if EventSystem is in the scene
        if (EventSystem.current == null)
        {
            Debug.LogError("No EventSystem found. Add an EventSystem to the scene.");
        }
    }

    public void TriggerDialogue()
    {
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.StartDialogue(dialogue);
        }
        else
        {
            Debug.LogError("DialogueManager instance is not found.");
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("Touch detected!");

            // Ensure the touch is not on a UI element
            if (EventSystem.current != null && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                if (mainCamera != null)
                {
                    Vector3 touchPosition = Input.GetTouch(0).position;
                    touchPosition.z = 10; // Adjust as necessary for your camera setup
                    Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
                    worldPosition.z = 0;  // Set Z position to 0 for 2D

                    Debug.Log("World Position: " + worldPosition);

                    Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

                    if (hitCollider != null && hitCollider.gameObject == gameObject)
                    {
                        Debug.Log("NPC Touched!");
                        TriggerDialogue();  // Trigger the dialogue if NPC was clicked
                    }
                    else
                    {
                        Debug.Log("No collider detected or not on the correct GameObject.");
                    }
                }
                else
                {
                    Debug.LogError("Main camera is not assigned!");
                }
            }
            else
            {
                Debug.LogError("Touch input is over a UI element or EventSystem is missing.");
            }
        }
    }
}
