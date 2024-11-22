using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueInsideDmManager : MonoBehaviour
{
    // UI Elements
    public GameObject dialoguePanel;
    public GameObject riddleBox;
    public GameObject dialogueBeforeRiddle;
    public GameObject dialogueAfterRiddle;

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI riddleQuestionText;

    // NPC references
    public GameObject nero, marina, marisa, guard1, guard2, fangirl, dm, makusog;

    // Character Icons for each NPC
    public Image neroIcon, marinaIcon, marisaIcon, guard1Icon, guard2Icon, fangirlIcon, dmIcon, makusogIcon;

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
            { "Nero", ("I am a festival held in Albay, honoring the beauty of a maiden and a volcano. What am I?", "Ibalong Festival", "Magayon Festival", "Pintados Festival", "B") },
            { "Marina", ("What does the Bicolano word MAGAYON mean?", "Brave", "Beautiful", "Noble", "B") },
            { "Marisa", ("What was Pagtuga’s demand to win Magayon’s hand?", "Build a temple", "Bring treasures to her father", "Defeat Panganoron", "B") },
            { "Makusog", ("What does the Bicolano word PANGANORON mean?", "Cloud", "Star", "Rain", "A") },
            { "Guard1", ("What is said to represent Panganoron in Mayon Volcano today?", " The flowing lava", "The smoke from eruptions", "The clouds surrounding the peak", "C") },
            { "Guard2", ("Which river in Albay is said to play a role in the Magayon legend?", "Cagraray River", "Yawa River", "Ticao River", "B") },
            { "DM", ("Who wanted to marry Magayon by force?", "Panganoron", "Pagtuga", "Alon", "B") },
            { "Fangirl", ("I bring sorrow, I bring fear,Yet I shape a beauty so near. What am I?", "A volcanic eruption", "A flood", "An earthquake", "A") }
        };
        

        // Assign button click listeners
        arrowButton.GetComponent<Button>().onClick.AddListener(OnArrowClicked);
        buttonA.GetComponent<Button>().onClick.AddListener(() => OnAnswerSelected("A"));
        buttonB.GetComponent<Button>().onClick.AddListener(() => OnAnswerSelected("B"));
        buttonC.GetComponent<Button>().onClick.AddListener(() => OnAnswerSelected("C"));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleTouch(Input.mousePosition);
        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                HandleTouch(touch.position);
            }
        }
    }

    private void HandleTouch(Vector3 screenPosition)
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
            else if (touchedObject == guard1)
                OpenDialoguePanel("Guard1");
            else if (touchedObject == guard2)
                OpenDialoguePanel("Guard2");
            else if (touchedObject == fangirl)
                OpenDialoguePanel("Fangirl");
            else if (touchedObject == dm)
                OpenDialoguePanel("Dm");
            else if (touchedObject == makusog)
                OpenDialoguePanel("Makusog");   
        }
    }

    private void OpenDialoguePanel(string npcName)
    {
        if (currentState != DialogueState.None) return; // Prevent opening multiple panels

        ResetUI();

        dialoguePanel.SetActive(true);
        dialogueBeforeRiddle.SetActive(true);
        dialogueText.text = $"Hello! Are you ready for a challenge?";
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
        guard1Icon.gameObject.SetActive(false);
        guard2Icon.gameObject.SetActive(false);
        fangirlIcon.gameObject.SetActive(false);
        dmIcon.gameObject.SetActive(false);
        makusogIcon.gameObject.SetActive(false);
        

        switch (npcName)
        {
            case "Nero": neroIcon.gameObject.SetActive(true); break;
            case "Marina": marinaIcon.gameObject.SetActive(true); break;
            case "Marisa": marisaIcon.gameObject.SetActive(true); break;
            case "Guard1": guard1Icon.gameObject.SetActive(true); break;
            case "Guard2": guard2Icon.gameObject.SetActive(true); break;
            case "Fangirl": fangirlIcon.gameObject.SetActive(true); break;
            case "Dm": dmIcon.gameObject.SetActive(true); break;
            case "Makusog": makusogIcon.gameObject.SetActive(true); break;
        }
    }
}
