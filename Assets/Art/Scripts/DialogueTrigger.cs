using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public RiddleDialogue riddleDialogue; // Reference to the RiddleDialogue script
    public CharacterData npcData; // Reference to the NPC's CharacterData

    private Camera mainCamera;
    private bool isDialogueActive = false;

    private void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Ensure there is a camera with the 'MainCamera' tag.");
        }
    }

    public void TriggerDialogue()
    {
        if (DialogueManager.Instance != null)
        {
            isDialogueActive = true;
            DialogueManager.Instance.StartDialogue(dialogue);
        }
        else
        {
            Debug.LogError("DialogueManager instance is not found.");
        }

        DialogueManager.Instance.StartDialogue(dialogue);

        // Trigger the riddle dialogue after the main dialogue
        if (riddleDialogue != null && npcData != null)
        {
            riddleDialogue.TriggerDialogue(npcData); // Pass the npcData to the riddle dialogue
        }
    }

    public void EndDialogue()
    {
        isDialogueActive = false;

        // Trigger the riddle after the dialogue ends
       if (riddleDialogue != null && npcData != null)
        {
            riddleDialogue.TriggerDialogue(npcData);
        }

    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (mainCamera != null)
            {
                Vector3 touchPosition = Input.GetTouch(0).position;
                touchPosition.z = 10; 
                Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
                worldPosition.z = 0;

                Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

                if (hitCollider != null && hitCollider.gameObject == gameObject && !isDialogueActive)
                {
                    TriggerDialogue();
                }
            }
        }
    }
}
