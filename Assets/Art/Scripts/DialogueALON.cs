using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueALON : MonoBehaviour
{
    public static DialogueALON Instance;

    public TextMeshProUGUI dialogueArea;
    public Image characterIcon;
    public Animator animator;

    private Queue<DialogueLineALON> lines;
    private bool isTyping = false;
    private string currentSentence;
    public float typingSpeed = 0.05f;

    public bool isDialogueActive = false;

    public PopupController popupController; // Reference to PopupController

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLineALON>();
    }

    public void StartDialogue(DialogueALONSet dialogue)
    {
        isDialogueActive = true;
        animator.Play("show");
        lines.Clear();

        foreach (DialogueLineALON dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueArea.text = currentSentence;
            isTyping = false;
            return;
        }

        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLineALON currentLine = lines.Dequeue();
        characterIcon.sprite = currentLine.character.icon;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLineALON dialogueLine)
    {
        dialogueArea.text = "";
        currentSentence = dialogueLine.line;
        isTyping = true;

        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void EndDialogue()
{
    isDialogueActive = false;
    animator.Play("hide");

    // After the dialogue ends, show the popup message
    if (popupController != null)
    {
        StartCoroutine(popupController.ShowPopupAfterDelay()); // Trigger the popup after the dialogue ends
    }
    else
    {
        Debug.LogWarning("PopupController is not assigned in the inspector.");
    }
}

}
