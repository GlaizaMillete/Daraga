using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class RiddleInteraction01 : MonoBehaviour
{
    [System.Serializable]
    public class NPC
    {
        public string name;
        public GameObject npcObject; // Attach NPC GameObject here
        public string dialogue; // Initial dialogue
        public string correctResponse = "You got it right!";
        public string incorrectResponse = "Keep it up, soon you'll know the answer.";
    }

    public List<NPC> npcs = new List<NPC>(); // List of NPCs (Bagwis, Nero, etc.)
    public GameObject riddleBox; // UI Panel for riddle question
    public TextMeshProUGUI riddleQuestionText; // Text for displaying riddle question
    public TextMeshProUGUI  npcDialogueText; // Text for displaying NPC dialogue
    public Button optionAButton, optionBButton, optionCButton; // Buttons for options

    private NPC currentNPC;
    private string correctAnswer;

    void Start()
    {
        riddleBox.SetActive(false); // Hide riddle box initially
        SelectRandomNPC(); // Start with a random NPC
    }

    void SelectRandomNPC()
    {
        int randomIndex = Random.Range(0, npcs.Count);
        currentNPC = npcs[randomIndex];
        npcDialogueText.text = currentNPC.dialogue;

        // Show dialogue and then wait before showing riddle
        Invoke(nameof(ShowRiddle), 2f); // Show riddle after dialogue delay
    }

    void ShowRiddle()
    {
        riddleBox.SetActive(true);
        DisplayRiddle();
    }

    void DisplayRiddle()
    {
        riddleQuestionText.text = "What has keys but can't open locks?"; // Example riddle
        optionAButton.GetComponentInChildren<TextMeshProUGUI>().text = "A) A piano";
        optionBButton.GetComponentInChildren<TextMeshProUGUI>().text = "B) A map";
        optionCButton.GetComponentInChildren<TextMeshProUGUI>().text = "C) A door";
        
        correctAnswer = "A"; // Correct answer is option A

        optionAButton.onClick.AddListener(() => CheckAnswer("A"));
        optionBButton.onClick.AddListener(() => CheckAnswer("B"));
        optionCButton.onClick.AddListener(() => CheckAnswer("C"));
    }

    void CheckAnswer(string selectedAnswer)
    {
        riddleBox.SetActive(false); // Hide riddle box

        if (selectedAnswer == correctAnswer)
        {
            npcDialogueText.text = currentNPC.correctResponse;
        }
        else
        {
            npcDialogueText.text = currentNPC.incorrectResponse;
        }

        Invoke(nameof(ResetRiddle), 2f); // Wait before resetting
    }

    void ResetRiddle()
    {
        npcDialogueText.text = "";
        SelectRandomNPC(); // Pick another random NPC for the next interaction
    }
}
