using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // For the new Input System
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
    public DialogueALONSet dialogue; // Ensure this is properly assigned in the inspector
    private Camera mainCamera;


    private void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Ensure there is a camera with the 'MainCamera' tag.");
        }
    }

    public void TriggerDialogueALON()
    {
        if (DialogueALON.Instance != null)
        {
            Debug.Log("Triggering DialogueALON...");
            DialogueALON.Instance.StartDialogue(dialogue);
        }
        else
        {
            Debug.LogError("DialogueALON instance is not found.");
        }
    }

    private void Update()
    {
        if (Touchscreen.current != null) // Check if a touchscreen is present
        {
            foreach (var touch in Touchscreen.current.touches)
            {
                if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
                {
                    HandleTouch(touch.position.ReadValue());
                }
            }
        }
        else if (Mouse.current != null) // Fallback to mouse input for testing in the editor
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                HandleTouch(Mouse.current.position.ReadValue());
            }
        }
    }

    private void HandleTouch(Vector2 screenPosition)
    {
        // Convert screen position to world position
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 10));
        worldPosition.z = 0; // Ensures it's at the correct z-position for 2D interaction

        // Detect if the touch/click hit the NPC
        Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);
        if (hitCollider != null && hitCollider.gameObject == gameObject)
        {
            Debug.Log("NPC Touched (ALON)!");
            TriggerDialogueALON();
        }
    }
}
