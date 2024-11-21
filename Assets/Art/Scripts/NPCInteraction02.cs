using UnityEngine;
using TMPro;
using System.Collections;

public class NPCInteraction02 : MonoBehaviour
{
    public RiddleManager currentNPCInteraction;
    public RiddleManager riddleManager;
    
    public string npcName; // Name of the NPC (Bagwis, Nero, Marina, or Marisa)
    public int riddleIndex; // Index of the riddle from RiddleManager

    public TextMeshProUGUI dialogueText; // Reference to dialogue text UI
    public GameObject dialogueBox; // Reference to dialogue box UI

    private bool hasAnsweredRiddle = false;

    private void OnMouseDown() // This will trigger when NPC is clicked
    {
        if (!hasAnsweredRiddle)
        {
            StartConversation();
        }
    }

    private void StartConversation()
    {
        dialogueBox.SetActive(true);
        dialogueText.text = $"{npcName}: I have a riddle for you!";

        // Wait for a moment before showing the riddle
        Invoke("ShowRiddle", 3f); // Simulate conversation delay
    }

    public void ShowRiddle()
    {
        if (riddleManager == null)
        {
            Debug.LogError("RiddleManager is not assigned!");
            return;
        }

        // Set the current NPC interaction
        riddleManager.currentNPCInteraction = this; 

        // Log the riddle being used
        Debug.Log("Showing riddle with index: " + riddleIndex);

        riddleManager.StartRiddle(riddleManager.riddles[riddleIndex]); // Start the riddle from RiddleManager
    }

    private IEnumerator WaitForRiddleFeedback()
    {
        yield return new WaitUntil(() => !riddleManager.feedbackText.gameObject.activeSelf); // Wait until feedback is not active

        // Show NPC dialogue after feedback
        dialogueBox.SetActive(true);
        dialogueText.text = $"{npcName}: What do you think of that?";
    }

    public void ShowNextDialogue()
    {
        dialogueBox.SetActive(true);
        dialogueText.text = $"{npcName}: What do you think of that?"; // Change this line based on what you want to say
    }
}
