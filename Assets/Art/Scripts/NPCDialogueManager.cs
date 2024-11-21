using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCDialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class NPC
    {
        public string name;
        public string dialogue;
        public string riddle;
        public string correctAnswer;
        public Sprite npcIcon;
    }

    public NPC[] npcs;

    // UI References
    public Animator dialoguePanelAnimator;
    public Animator riddleBoxAnimator;
    public Image npcIcon;
    public TMP_Text dialogueText;
    public TMP_Text riddleQuestionText;

    public Button neroButton, bagwisButton, marinaButton, marisaButton, dalisayButton;
    public Button aButton, bButton, cButton;

    private NPC currentNPC;
    private bool isAnsweringRiddle = false;

    private void Start()
    {
        // Assign button listeners for NPC buttons
        neroButton.onClick.AddListener(() => OpenDialoguePanel(npcs[0]));
        bagwisButton.onClick.AddListener(() => OpenDialoguePanel(npcs[1]));
        marinaButton.onClick.AddListener(() => OpenDialoguePanel(npcs[2]));
        marisaButton.onClick.AddListener(() => OpenDialoguePanel(npcs[3]));
        dalisayButton.onClick.AddListener(() => OpenDialoguePanel(npcs[4]));

        // Assign button listeners for multiple-choice answers
        aButton.onClick.AddListener(() => CheckAnswer("a"));
        bButton.onClick.AddListener(() => CheckAnswer("b"));
        cButton.onClick.AddListener(() => CheckAnswer("c"));
    }

    public void OpenDialoguePanel(NPC npc)
    {
        currentNPC = npc;

        // Set NPC icon and dialogue
        npcIcon.sprite = npc.npcIcon;
        dialogueText.text = $"{npc.dialogue}\nAre you ready to test your mind?";

        // Show dialogue panel
        dialoguePanelAnimator.SetTrigger("Open");

        // Delay to show riddle box
        Invoke("OpenRiddleBox", 2f); // Adjust delay if necessary
    }

    public void OpenRiddleBox()
    {
        if (currentNPC != null)
        {
            riddleQuestionText.text = currentNPC.riddle;
            riddleBoxAnimator.SetTrigger("Open");
            isAnsweringRiddle = true;
        }
    }

    private void CheckAnswer(string playerAnswer)
    {
        if (!isAnsweringRiddle || currentNPC == null) return;

        isAnsweringRiddle = false;

        // Check the answer
        string feedback = playerAnswer == currentNPC.correctAnswer ? "You got it right!" : "Keep it up, soon you'll know the answer.";
        dialogueText.text = feedback;

        // Close riddle box
        riddleBoxAnimator.SetTrigger("Close");

        // Show feedback in dialogue panel
        Invoke("CloseDialoguePanel", 2f); // Adjust delay if necessary
    }

    private void CloseDialoguePanel()
    {
        dialoguePanelAnimator.SetTrigger("Close");
        currentNPC = null; // Clear current NPC
    }
}
