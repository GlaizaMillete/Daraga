using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialoguePanelManager : MonoBehaviour
{
    // UI Elements
    public GameObject dialoguePanel;
    public GameObject riddleBox;
    public GameObject dialogueBeforeRiddle;
    public GameObject dialogueAfterRiddle;

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI riddleQuestionText;

    // NPC button references
    public GameObject neroButton, marinaButton, marisaButton, bagwisButton, dalisayButton;

    // NPC references to keep buttons attached to them
    public Transform nero, marina, marisa, bagwis, dalisay;

    // Character Icons for each NPC
    public Image neroIcon, marinaIcon, marisaIcon, bagwisIcon, dalisayIcon;

    // Current character icon that will be displayed
    private Image currentCharacterIcon;

    public GameObject arrowButton;

    // Riddle options
    public GameObject buttonA, buttonB, buttonC;

    private string correctAnswer;

    private void Start()
    {
        // Initially, hide all UI elements
        dialoguePanel.SetActive(false);
        riddleBox.SetActive(false);
        dialogueBeforeRiddle.SetActive(false);
        dialogueAfterRiddle.SetActive(false);

        // Assign button click listeners
        arrowButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnArrowClicked);
        buttonA.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnAnswerSelected("A"));
        buttonB.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnAnswerSelected("B"));
        buttonC.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnAnswerSelected("C"));

        // Assign NPC buttons
        neroButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ShowDialoguePanel("Nero"));
        marinaButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ShowDialoguePanel("Marina"));
        marisaButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ShowDialoguePanel("Marisa"));
        bagwisButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ShowDialoguePanel("Bagwis"));
        dalisayButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ShowDialoguePanel("Dalisay"));
    }

    private void Update()
    {
        // Keep buttons aligned with their respective NPCs
        KeepButtonPosition(neroButton, nero);
        KeepButtonPosition(marinaButton, marina);
        KeepButtonPosition(marisaButton, marisa);
        KeepButtonPosition(bagwisButton, bagwis);
        KeepButtonPosition(dalisayButton, dalisay);
    }

    // Function to align button positions with NPCs
    public void KeepButtonPosition(GameObject button, Transform npc)
    {
        if (npc != null)
        {
            // Define the offset above the NPC's head in world space
            Vector3 offset = new Vector3(2, 2f, 0); // Adjust the y-value as needed
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(npc.position + offset);
            button.transform.position = screenPosition;
        }
    }

    // Show Dialogue Panel based on the NPC selected
    public void ShowDialoguePanel(string npcName)
    {
        // Activate the Dialogue Panel and set NPC-specific dialogue
        dialoguePanel.SetActive(true);
        dialogueBeforeRiddle.SetActive(true);
        dialogueText.text = $"Are you ready to test your mind?";

        // Display the corresponding Character Icon based on the NPC selected
        DisplayCharacterIcon(npcName);

        // Set up the riddle based on NPC (For demo purposes, we'll assume all NPCs share the same riddle)
        SetRiddle("What is the capital of France?", "A", "B", "C", "A");
    }

    // This function displays the appropriate character icon for the selected NPC
    private void DisplayCharacterIcon(string npcName)
    {
        // Hide all icons first
        neroIcon.gameObject.SetActive(false);
        marinaIcon.gameObject.SetActive(false);
        marisaIcon.gameObject.SetActive(false);
        bagwisIcon.gameObject.SetActive(false);
        dalisayIcon.gameObject.SetActive(false);

        // Set the correct character icon based on the NPC
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
        }
    }

    // Trigger when the arrow button is clicked
    public void OnArrowClicked()
    {
        // Hide the dialogue before the riddle and show the riddle box
        dialogueBeforeRiddle.SetActive(false);
        riddleBox.SetActive(true);
    }

    // Set up the riddle for the player
    public void SetRiddle(string question, string answerA, string answerB, string answerC, string correctAns)
    {
        riddleQuestionText.text = question;
        buttonA.GetComponentInChildren<TextMeshProUGUI>().text = answerA;
        buttonB.GetComponentInChildren<TextMeshProUGUI>().text = answerB;
        buttonC.GetComponentInChildren<TextMeshProUGUI>().text = answerC;

        correctAnswer = correctAns;
    }

    // Handle when the player selects an answer
    public void OnAnswerSelected(string selectedAnswer)
    {
        // Hide the riddle box
        riddleBox.SetActive(false);

        // Show the after-riddle dialogue based on the player's answer
        dialogueAfterRiddle.SetActive(true);

        // Check if the selected answer is correct
        if (selectedAnswer == correctAnswer)
        {
            dialogueText.text = "You got it right!";
        }
        else
        {
            dialogueText.text = "Keep it up, soon you'll know the answer!";
        }

        // Wait for a moment before hiding the after-riddle dialogue
        Invoke("HideDialogueAfterRiddle", 2f); // Hide after 2 seconds
    }

    // Hide the after-riddle dialogue and reset for the next interaction
    private void HideDialogueAfterRiddle()
    {
        dialogueAfterRiddle.SetActive(false);
        dialoguePanel.SetActive(false); // Hide the whole panel after interaction
    }
}
