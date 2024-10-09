using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class DialogueCharacterALON
{
    public Sprite icon;
}

[System.Serializable]
public class DialogueLineALON
{
    public DialogueCharacterALON character;
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class DialogueALONSet
{
    public List<DialogueLineALON> dialogueLines = new List<DialogueLineALON>();
}

public class DialogueTriggerALON : MonoBehaviour
{
    // The dialogue set containing the lines for this specific NPC
    public DialogueALONSet dialogue; // Ensure this is properly assigned in the inspector
    private Camera mainCamera;

    // The quest scene name for triggering scene change after dialogue
    public string questSceneName;

    private void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Ensure there is a camera with the 'MainCamera' tag.");
        }
    }

    // This function triggers the dialogue using DialogueALON class
    public void TriggerDialogueALON()
    {
        // Ensure that the dialogue system instance exists
        if (DialogueALON.Instance != null)
        {
            Debug.Log("Triggering DialogueALON...");
            DialogueALON.Instance.StartDialogue(dialogue); // Use the proper DialogueALONSet
        }
        else
        {
            Debug.LogError("DialogueALON instance is not found.");
        }
    }

    private void Update()
    {
        Vector3 inputPosition = Vector3.zero;
        bool isInputDetected = false;

        // Detect mouse click or touch input
        if (Input.GetMouseButtonDown(0))
        {
            inputPosition = Input.mousePosition;
            isInputDetected = true;
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            inputPosition = Input.GetTouch(0).position;
            isInputDetected = true;
        }

        // If no input is detected, return early
        if (!isInputDetected)
            return;

        // Check if the input is over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Pointer is over a UI element.");
            return;
        }

        // Convert screen position to world position
        inputPosition.z = 10; // Adjust based on camera setup
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(inputPosition);
        worldPosition.z = 0; // For 2D setup

        // Detect if the touch/click hit the NPC
        Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);
        if (hitCollider != null && hitCollider.gameObject == gameObject)
        {
            Debug.Log("NPC Touched (ALON)!");
            TriggerDialogueALON();  // Trigger the dialogue for ALON NPC
        }
        else
        {
            Debug.Log("No NPC hit detected.");
        }
    }
}
