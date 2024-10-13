using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class DialogueALON : MonoBehaviour
{
    public static DialogueALON Instance;

    public Image characterIcon;
    public TextMeshProUGUI dialogueArea;
    public GameObject Rico;
    public GameObject Joystick;
    public GameObject CMCam;

    private Queue<DialogueLineALON> lines;
    private int totalDialogueLines;
    private int currentLineIndex = 0; // Track the current dialogue line
    private int linesBeforeQuest = 7; // Number of lines before quest starts

    public bool isDialogueActive = false;
    private bool isTyping = false;
    private string currentSentence;

    public float typingSpeed = 0.05f;

    public Animator animator;

    private bool questStarted = false;
    public string questSceneName;

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
        totalDialogueLines = dialogue.dialogueLines.Count; // Track the total number of lines
        currentLineIndex = 0; // Reset the line index

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

        // Check if we've finished all the lines
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        // Check if we need to start the quest before showing the next dialogue line
        if (!questStarted && currentLineIndex == linesBeforeQuest)
        {
            StartQuest();
            return;
        }

        DialogueLineALON currentLine = lines.Dequeue();
        characterIcon.sprite = currentLine.character.icon;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));

        currentLineIndex++; // Increment the dialogue line index after displaying
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

        if (!questStarted && currentLineIndex == linesBeforeQuest)
        {
            StartQuest();
        }
        else if (questStarted && currentLineIndex == totalDialogueLines)
        {
            Debug.Log("Final dialogue complete!");
        }
        else if (currentLineIndex >= totalDialogueLines)
        {
            Debug.Log("Dialogue sequence complete!");
        }
    }

    void StartQuest()
    {
        questStarted = true;
        Debug.Log("Quest is starting.");

        Destroy(Rico);
        Destroy(Joystick);
        Destroy(CMCam);

        SceneManager.LoadScene(questSceneName);  // Transition to the quest scene
    }

    public void CompleteQuest()
    {
        questStarted = true;  // Mark quest as complete
        Debug.Log("Quest complete, resuming post-quest dialogue.");

        StartFinalDialogue();
    }

    void StartFinalDialogue()
    {
        if (lines.Count > 0)
        {
            isDialogueActive = true;
            animator.Play("show");
            DisplayNextDialogueLine();  // Resume post-quest dialogue
        }
        else
        {
            EndDialogue();  // End if no more lines
        }
    }
}
