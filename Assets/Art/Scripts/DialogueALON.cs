using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueALON : MonoBehaviour
{
    public static DialogueALON Instance;
    public TextMeshProUGUI dialogueArea;
    public Image ricoImage; // Rico's image on the left
    public Image alonImage; // Alon's image on the right
    public Animator animator;

    private Queue<DialogueLineALON> lines;
    private bool isTyping = false;
    private string currentSentence;
    public float typingSpeed = 0.05f;

    public bool isDialogueActive = false;

    public PopupController popupController; // Reference to PopupController

    private bool dialogueCompleted = false; // Tracks if the dialogue has been completed

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLineALON>();
    }

    public void StartDialogue(DialogueALONSet dialogue)
    {
        isDialogueActive = true;
        dialogueCompleted = false; // Reset completion flag
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

        // Update the character images based on who is speaking
        if (currentLine.character.icon == ricoImage.sprite) // Assuming Rico's icon is assigned in inspector
        {
            ShowRicoImage();
        }
        else if (currentLine.character.icon == alonImage.sprite) // Assuming Alon's icon is assigned in inspector
        {
            ShowAlonImage();
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));

        // Check if the dialogue contains "Here, take this." and trigger the popup
        if (currentLine.line == "Here, take this.")
        {
            TriggerPopup();
        }
    }

    IEnumerator TypeSentence(DialogueLineALON dialogueLine)
    {
        dialogueArea.text = "";
        currentSentence = dialogueLine.line;
        isTyping = true;

        // Show the popup when typing "Here, take this."
        if (currentSentence == "Here, take this.")
        {
            StartCoroutine(popupController.ShowPopup()); // Show the popup when starting to type
        }

        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;

        // Hide the popup after the line is fully typed
        if (currentSentence == "Here, take this.")
        {
            StartCoroutine(popupController.HidePopup()); // Hide the popup after typing is done
        }
    }


    /*private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Unlock the "Alon" achievement
            gameplayMenuManager.UnlockAchievement("alon");

            
        }

        
    }*/


    void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("hide");
        dialogueCompleted = true; // Mark dialogue as completed
    }

    private void ShowRicoImage()
    {
        ricoImage.gameObject.SetActive(true);
        alonImage.gameObject.SetActive(false); // Hide Alon's image
    }

    private void ShowAlonImage()
    {
        ricoImage.gameObject.SetActive(false); // Hide Rico's image
        alonImage.gameObject.SetActive(true);
    }

    private void TriggerPopup()
    {
        if (popupController != null)
        {
            StartCoroutine(popupController.ShowPopup()); // Start the coroutine for the popup
        }
        else
        {
            Debug.LogWarning("PopupController is not assigned.");
        }
    }
}
