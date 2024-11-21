using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RiddleManager : MonoBehaviour
{
    public NPCInteraction02 currentNPCInteraction; 
    public static RiddleManager Instance;
    public TextMeshProUGUI riddleText; // Reference to the text component

    [System.Serializable]
    public class Riddle
    {
        public string question;
        public string[] options; // A, B, C options
        public int correctAnswerIndex; // Index of the correct answer
        public string npcName; // The NPC who asked the riddle
    }

    public Riddle[] riddles; // List of riddles for different NPCs

    public GameObject riddleBox; // UI panel for the riddle box
    public TextMeshProUGUI riddleQuestionText;
    public Button optionAButton, optionBButton, optionCButton;
    public TextMeshProUGUI feedbackText; // Text to display feedback

    private Riddle currentRiddle;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartRiddle(Riddle riddle)
    {
        if (riddleBox == null || riddle == null)
        {
            Debug.LogError("RiddleBox or riddle is null!");
            return;
        }

        // Ensure the RiddleBox is enabled
        riddleBox.SetActive(true);
        
        currentRiddle = riddle;
        riddleQuestionText.text = riddle.question;

        // Set options for buttons dynamically
        optionAButton.GetComponentInChildren<TextMeshProUGUI>().text = riddle.options[0];
        optionBButton.GetComponentInChildren<TextMeshProUGUI>().text = riddle.options[1];
        optionCButton.GetComponentInChildren<TextMeshProUGUI>().text = riddle.options[2];

        riddleBox.SetActive(true);
    }

     public void SelectAnswer(int index)
    {
        if (currentRiddle == null)
            return;

        // Show feedback based on the answer selected
        if (index == currentRiddle.correctAnswerIndex)
        {
            feedbackText.text = "You got it right!"; // Correct answer feedback
        }
        else
        {
            feedbackText.text = "Keep trying! You’ll get the hang of it soon enough!"; // Wrong answer feedback
        }

        // Hide the riddle box and show feedback
        riddleBox.SetActive(false);
        StartCoroutine(ShowFeedback());
    }

    private IEnumerator ShowFeedback()
    {
        feedbackText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        feedbackText.gameObject.SetActive(false);
        
        // Call method to show NPC dialogue after feedback is displayed
        if (currentNPCInteraction != null) // Check if it's not null to avoid errors
        {
            currentNPCInteraction.ShowNextDialogue(); 
        }
    }


    public void EndRiddle()
    {
        if (riddleBox != null)
        {
            riddleBox.SetActive(false);
        }
    }
}
