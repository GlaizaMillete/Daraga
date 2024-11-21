using UnityEngine;

public class ArrowButton : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;

    private bool hasTriggeredDialogue = false;

    public void OnArrowButtonClick()
    {
        if (!hasTriggeredDialogue && dialogueTrigger != null)
        {
            dialogueTrigger.TriggerDialogue();
            hasTriggeredDialogue = true;
        }
        else if (dialogueManager != null)
        {
            DialogueManager.Instance.DisplayNextDialogueLine();

        }
    }
}
