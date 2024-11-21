/*PANAGLAWAusing UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public Button arrowButton;

    private Queue<string> dialogueLines = new Queue<string>();
    private bool isDialogueActive = false;
    public RiddleDialogue riddleDialogue;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        arrowButton.onClick.AddListener(DisplayNextLine);
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(string[] lines)
    {
        
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        dialogueLines.Clear();

        foreach (var line in lines)
        {
            dialogueLines.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            TriggerRiddle();
            return;
        }

        string currentLine = dialogueLines.Dequeue();
        dialogueText.text = currentLine;
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
    }

    private void TriggerRiddle()
    {
        if (riddleDialogue != null)
        {
            riddleDialogue.TriggerDialogue();
        }
    }
}*/

using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Image characterIcon;
    public TextMeshProUGUI dialogueArea;
    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;
    public bool isTyping = false; // Track if typing is ongoing
    public string currentSentence; // Store the current sentence being typed

    public float typingSpeed = 0.02f; // Adjust typing speed if needed
    public Animator animator;
    public event System.Action OnDialogueEnd;
    public Button arrowButton; // Reference to the arrow button for next dialogue

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
    }

    private void Start()
    {
        arrowButton.onClick.AddListener(DisplayNextDialogueLine);
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

        // Dequeue the next line and display it
        DialogueLine currentLine = lines.Dequeue();
        characterIcon.sprite = currentLine.character.icon; // Display the character's icon
        currentSentence = currentLine.line;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
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

    public void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("hide");

        OnDialogueEnd?.Invoke();
    }
}

