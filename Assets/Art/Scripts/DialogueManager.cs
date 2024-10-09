using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Image characterIcon;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;
    private bool isTyping = false; // Flag to check if the text is currently being typed
    private string currentSentence; // Store the current sentence being typed

    public float typingSpeed = 0.05f;

    public Animator animator;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;

        animator.Play("show");

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

   public void DisplayNextDialogueLine()
{
    Debug.Log("Next button clicked");

    if (isTyping)
    {
        Debug.Log("Currently typing, showing full sentence.");
        StopAllCoroutines();
        dialogueArea.text = currentSentence;
        isTyping = false;
        return;
    }

    if (lines.Count == 0)
    {
        Debug.Log("No more dialogue lines.");
        EndDialogue();
        return;
    }

    DialogueLine currentLine = lines.Dequeue();
    characterIcon.sprite = currentLine.character.icon;

    Debug.Log("Displaying next line: " + currentLine.line);
    StopAllCoroutines();
    StartCoroutine(TypeSentence(currentLine));
}
    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        currentSentence = dialogueLine.line; // Store the current sentence
        isTyping = true; // Set the typing flag to true

        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false; // Reset the typing flag once typing is complete
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("hide");
    }
}