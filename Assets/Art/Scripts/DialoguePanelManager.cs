using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.InputSystem; // Add this for the new Input System

public class DialoguePanelManager : MonoBehaviour
{
    // UI Elements
    public GameObject dialoguePanel;
    public GameObject riddleBox;
    public GameObject dialogueBeforeRiddle;
    public GameObject dialogueAfterRiddle;

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI riddleQuestionText;

    // NPC references
    public GameObject nero, marina, marisa, bagwis, dalisay, ramon, domingo, reynaldo, rosita;

    // Character Icons for each NPC
    public Image neroIcon, marinaIcon, marisaIcon, bagwisIcon, dalisayIcon, ramonIcon, domingoIcon, reynaldoIcon, rositaIcon;

    // Riddle options
    public GameObject buttonA, buttonB, buttonC;
    public GameObject arrowButton;

    private string correctAnswer;
    private string currentNPC;

    // Riddle data structure
    private Dictionary<string, (string question, string answerA, string answerB, string answerC, string correctAns)> npcRiddles;

    // State variable to manage dialogue flow
    private enum DialogueState { None, DialogueBeforeRiddle, RiddleActive, DialogueAfterRiddle }
    private DialogueState currentState = DialogueState.None;

    private void Start()
    {
        // Initialize UI
        ResetUI();

        // Initialize riddles
        npcRiddles = new Dictionary<string, (string, string, string, string, string)>()
        {
            { "Nero", ("A warrior brave, a lover true, His heart for Magayon, ever new. Who is this hero, strong and bold?", "Panganoron", "Pagtuga", "Baltog", "A") },
            { "Marina", ("A fiery mount, a tragic sight, A lover’s curse, a mournful plight. What is this place, where legends reside?", "Bulusan Volcano", "Taal Volcano", "Mayon Volcano", "C") },
            { "Marisa", ("A symbol of love, a tragic end,A tale forever, a faithful friend.What is this love story, pure and deep?", "Maria Clara and Ibarra", "Romeo and Juliet", "Magayon and Panganoron", "C") },
            { "Bagwis", ("A tragic fate, a lover’s cry, A mountain’s tears, beneath the sky. What is this sorrow, a heart’s deep sigh?", "The loss of a friend", "A forbidden love", "The death of a hero", "B") },
            { "Dalisay", ("I am a place of beauty, serene and calm.A place where lovers meet, safe from harm", "The forest", "The spring", "The village", "B") },
            { "Ramon", ("A maiden fair, a heart pure and bright,Her beauty unmatched, a dazzling sight.A tragic love, a tale untold, A volcano's birth, a legend bold.", "Daragang Magayon", "Maria Makiling", "Concepcion", "A") },
            { "Domingo", ("A jealous heart, a wicked mind,A villain's plot, of cruelest kind. A tragic fate, a bitter end, A legend's tale, to comprehend. Who is this villain, dark and cold?", "Makusog", "Pagtuga", "Panganoron", "B") },
            { "Reynaldo", ("A father's love, a daughter's pride,A chieftain's heart, a noble guide. A tragic loss, a mournful sigh, A legend's tale, soaring high. Who is Magayon's father, strong and wise?", "Makusog", "Lakas", "Luya", "A") },
            { "Rosita", ("A golden arrow, a deadly sight,A lover's heart, extinguished light. A tragic loss, a mournful sigh,A legend born, beneath the sky. What caused the hero's fatal plight?", "A sword", "A spear", "An arrow", "C") }
        };

        // Assign button click listeners
        arrowButton.GetComponent<Button>().onClick.AddListener(OnArrowClicked);
        buttonA.GetComponent<Button>().onClick.AddListener(() => OnAnswerSelected("A"));
        buttonB.GetComponent<Button>().onClick.AddListener(() => OnAnswerSelected("B"));
        buttonC.GetComponent<Button>().onClick.AddListener(() => OnAnswerSelected("C"));
    }

    private void Update()
    {
        // Touch input handling via the new Input System
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            HandleTouch(Touchscreen.current.primaryTouch.position.ReadValue());
        }
    }

    private void HandleTouch(Vector2 screenPosition)
    {
        if (currentState != DialogueState.None) return; // Block new touches during interactions

        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject touchedObject = hit.collider.gameObject;

            if (touchedObject == nero)
                OpenDialoguePanel("Nero");
            else if (touchedObject == marina)
                OpenDialoguePanel("Marina");
            else if (touchedObject == marisa)
                OpenDialoguePanel("Marisa");
            else if (touchedObject == bagwis)
                OpenDialoguePanel("Bagwis");
            else if (touchedObject == dalisay)
                OpenDialoguePanel("Dalisay");
            else if (touchedObject == ramon)
                OpenDialoguePanel("Ramon");
            else if (touchedObject == domingo)
                OpenDialoguePanel("Domingo");
            else if (touchedObject == reynaldo)
                OpenDialoguePanel("Reynaldo");
            else if (touchedObject == rosita)
                OpenDialoguePanel("Rosita");
        }
    }

    private void OpenDialoguePanel(string npcName)
    {
        if (currentState != DialogueState.None) return; // Prevent opening multiple panels

        ResetUI();

        dialoguePanel.SetActive(true);
        dialogueBeforeRiddle.SetActive(true);
        dialogueText.text = $"Hello! I am {npcName}. Are you ready for a challenge?";
        DisplayCharacterIcon(npcName);

        currentNPC = npcName;

        // Assign riddle based on the NPC
        if (npcRiddles.TryGetValue(npcName, out var riddle))
        {
            SetRiddle(riddle.question, riddle.answerA, riddle.answerB, riddle.answerC, riddle.correctAns);
        }

        currentState = DialogueState.DialogueBeforeRiddle;
    }

    public void OnArrowClicked()
    {
        if (currentState != DialogueState.DialogueBeforeRiddle) return;

        dialogueBeforeRiddle.SetActive(false);
        riddleBox.SetActive(true);
        currentState = DialogueState.RiddleActive;
    }

    private void SetRiddle(string question, string answerA, string answerB, string answerC, string correctAns)
    {
        riddleQuestionText.text = question;
        buttonA.GetComponentInChildren<TextMeshProUGUI>().text = answerA;
        buttonB.GetComponentInChildren<TextMeshProUGUI>().text = answerB;
        buttonC.GetComponentInChildren<TextMeshProUGUI>().text = answerC;
        correctAnswer = correctAns;
    }

    public void OnAnswerSelected(string selectedAnswer)
    {
        if (currentState != DialogueState.RiddleActive) return;

        riddleBox.SetActive(false);
        dialogueAfterRiddle.SetActive(true);

        if (selectedAnswer == correctAnswer)
        {
            dialogueText.text = "Correct! Well done.";
        }
        else
        {
            dialogueText.text = "Incorrect. Better luck next time.";
        }

        currentState = DialogueState.DialogueAfterRiddle;

        Invoke("HideDialogueAfterRiddle", 2f);
    }

    private void HideDialogueAfterRiddle()
    {
        ResetUI();
        currentState = DialogueState.None; // Reset state
    }

    private void ResetUI()
    {
        dialoguePanel.SetActive(false);
        riddleBox.SetActive(false);
        dialogueBeforeRiddle.SetActive(false);
        dialogueAfterRiddle.SetActive(false);
    }

    private void DisplayCharacterIcon(string npcName)
    {
        neroIcon.gameObject.SetActive(false);
        marinaIcon.gameObject.SetActive(false);
        marisaIcon.gameObject.SetActive(false);
        bagwisIcon.gameObject.SetActive(false);
        dalisayIcon.gameObject.SetActive(false);
        ramonIcon.gameObject.SetActive(false);
        domingoIcon.gameObject.SetActive(false);
        reynaldoIcon.gameObject.SetActive(false);
        rositaIcon.gameObject.SetActive(false);

        switch (npcName)
        {
            case "Nero":
                neroIcon.gameObject.SetActive(true);
                break;
            case "Marina":
                marinaIcon.gameObject.SetActive(true);
                break;
            case "Marisa":
                marisaIcon.gameObject.SetActive(true);
                break;
            case "Bagwis":
                bagwisIcon.gameObject.SetActive(true);
                break;
            case "Dalisay":
                dalisayIcon.gameObject.SetActive(true);
                break;
            case "Ramon":
                ramonIcon.gameObject.SetActive(true);
                break;
            case "Domingo":
                domingoIcon.gameObject.SetActive(true);
                break;
            case "Reynaldo":
                reynaldoIcon.gameObject.SetActive(true);
                break;
            case "Rosita":
                rositaIcon.gameObject.SetActive(true);
                break;
        }
    }
}
