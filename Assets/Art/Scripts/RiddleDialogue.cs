/*using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RiddleDialogue : MonoBehaviour
{
    public string riddleQuestion;
    public string[] options;
    public int correctOptionIndex;
    public TextMeshProUGUI riddleText;
    public Button[] optionButtons;

    private void Start()
    {
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i;
            optionButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    public void TriggerDialogue()
    {
        gameObject.SetActive(true);
        riddleText.text = riddleQuestion;

        for (int i = 0; i < options.Length; i++)
        {
            optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = options[i];
        }
    }

    private void CheckAnswer(int selectedIndex)
    {
        if (selectedIndex == correctOptionIndex)
        {
            Debug.Log("Correct Answer!");
        }
        else
        {
            Debug.Log("Wrong Answer. Try Again!");
        }
        gameObject.SetActive(false);
    }
}*/

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RiddleDialogue : MonoBehaviour
{
    public CharacterData[] npcData; // Holds data for each NPC

    private CharacterData currentNpc; // The NPC whose riddle is being shown

    public TextMeshProUGUI dialogueText;
    public GameObject riddleBox;
    public TextMeshProUGUI riddleQuestionText;
    public Button optionA, optionB, optionC;

    private int dialogueIndex = 0;
    private bool isRiddleActive = false;

    private void Start()
    {
        riddleBox.SetActive(false);

        // Add listeners for each option
        optionA.onClick.AddListener(() => CheckAnswer(0));
        optionB.onClick.AddListener(() => CheckAnswer(1));
        optionC.onClick.AddListener(() => CheckAnswer(2));
    }

    public void TriggerDialogue(CharacterData npc)
    {
        currentNpc = npc;
        dialogueIndex = 0;
        ShowDialogueBeforeRiddle();
    }
    

    private void ShowDialogueBeforeRiddle()
    {
        if (dialogueIndex < currentNpc.DialogueBeforeRiddle.Length)
        {
            dialogueText.text = currentNpc.DialogueBeforeRiddle[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            ShowRiddle();
        }
    }

    private void ShowRiddle()
    {
        isRiddleActive = true;
        riddleBox.SetActive(true);

        riddleQuestionText.text = currentNpc.RiddleQuestion;
        optionA.GetComponentInChildren<TextMeshProUGUI>().text = "A) " + currentNpc.Options[0];
        optionB.GetComponentInChildren<TextMeshProUGUI>().text = "B) " + currentNpc.Options[1];
        optionC.GetComponentInChildren<TextMeshProUGUI>().text = "C) " + currentNpc.Options[2];
    }

    private void CheckAnswer(int selectedAnswer)
    {
        riddleBox.SetActive(false);

        if (selectedAnswer == currentNpc.CorrectAnswerIndex)
        {
            dialogueText.text = currentNpc.CorrectDialogue;
            TriggerDialogueAfterRiddle(true);
        }
        else
        {
            dialogueText.text = currentNpc.IncorrectDialogue;
            TriggerDialogueAfterRiddle(false);
        }

        isRiddleActive = false;
    }

    private void TriggerDialogueAfterRiddle(bool isCorrect)
    {
        if (currentNpc.DialogueAfterRiddle != null)
        {
            DialogueManager.Instance.StartDialogue(currentNpc.DialogueAfterRiddle);
        }
    }
}
