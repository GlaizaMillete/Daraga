/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DialogueLiwayway : MonoBehaviour
{
    public static DialogueLiwayway Instance;

    [System.Serializable]
    public class DialogueCharacter
    {
        public string characterName;
        public Sprite icon;
    }

    [System.Serializable]
    public class DialogueLine
    {
        public DialogueCharacter character;
        [TextArea(3, 10)]
        public string line;
    }

    [System.Serializable]
    public class Dialogue
    {
        public List<DialogueLine> dialogueLines = new List<DialogueLine>();
    }

    public Image characterIconRight; // For Liwayway's icon
    public Image characterIconLeft; // For Rico's icon

    public TextMeshProUGUI dialogueArea;
    public Button arrowButton; // Next dialogue button
    public Animator animator;

    private Queue<DialogueLine> lines;
    private Camera mainCamera;
    private bool isDialogueActive = false;
    private bool isTyping = false;
    private string currentSentence;

    public float typingSpeed = 0.02f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
    }

    private void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
            Debug.LogError("Main camera not found. Ensure a camera is tagged as 'MainCamera'.");

        if (EventSystem.current == null)
            Debug.LogError("No EventSystem found. Add one to the scene.");

        if (arrowButton != null)
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

        DialogueLine currentLine = lines.Dequeue();
        UpdateCharacterIcons(currentLine.character);
        currentSentence = currentLine.line;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    private IEnumerator TypeSentence(DialogueLine dialogueLine)
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

    private void UpdateCharacterIcons(DialogueCharacter character)
    {
        // Hide both icons first
        characterIconLeft.gameObject.SetActive(false);
        characterIconRight.gameObject.SetActive(false);

        // Show the character's icon based on the character name
        if (character.characterName == "Liwayway")
        {
            characterIconRight.sprite = character.icon;
            characterIconRight.gameObject.SetActive(true); // Liwayway's icon is shown
        }
        else if (character.characterName == "Rico")
        {
            characterIconLeft.sprite = character.icon;
            characterIconLeft.gameObject.SetActive(true); // Rico's icon is shown
        }
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("hide");
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DialogueLiwayway : MonoBehaviour
{
    public static DialogueLiwayway Instance;

    [System.Serializable]
    public class DialogueCharacter
    {
        public string characterName;
        public Sprite icon;
    }

    [System.Serializable]
    public class DialogueLine
    {
        public DialogueCharacter character;
        [TextArea(3, 10)]
        public string line;
    }

    [System.Serializable]
    public class Dialogue
    {
        public List<DialogueLine> dialogueLines = new List<DialogueLine>();
    }

    public delegate void DialogueEndHandler();
    public event DialogueEndHandler OnDialogueEnd;

    [Header("UI References")]
    public Image characterIconRight; // Liwayway's icon
    public Image characterIconLeft;  // Rico's icon
    public TextMeshProUGUI dialogueArea;
    public Button arrowButton; // Next dialogue button
    public Animator animator;

    [Header("Dialogue Settings")]
    public float typingSpeed = 0.02f;

    private Queue<DialogueLine> lines = new Queue<DialogueLine>();
    private bool isDialogueActive = false;
    private bool isTyping = false;
    private string currentSentence;
    private Camera mainCamera;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        mainCamera = Camera.main;

        if (arrowButton != null)
            arrowButton.onClick.AddListener(DisplayNextDialogueLine);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (dialogue == null || dialogue.dialogueLines.Count == 0)
        {
            Debug.LogWarning("Dialogue is empty or null.");
            return;
        }

        isDialogueActive = true;
        animator?.Play("show");

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

        DialogueLine currentLine = lines.Dequeue();
        UpdateCharacterIcons(currentLine.character);
        currentSentence = currentLine.line;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine.line));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueArea.text = "";
        isTyping = true;

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    private void UpdateCharacterIcons(DialogueCharacter character)
    {
        if (character == null)
        {
            Debug.LogWarning("DialogueCharacter is null.");
            return;
        }

        // Hide both icons
        characterIconLeft.gameObject.SetActive(false);
        characterIconRight.gameObject.SetActive(false);

        // Show appropriate icon based on the character
        if (character.characterName == "Liwayway")
        {
            characterIconRight.sprite = character.icon;
            characterIconRight.gameObject.SetActive(true);
        }
        else if (character.characterName == "Rico")
        {
            characterIconLeft.sprite = character.icon;
            characterIconLeft.gameObject.SetActive(true);
        }
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        animator?.Play("hide");
        OnDialogueEnd?.Invoke();
    }

    private void OnMouseDown()
    {
        // Detect mouse click or touch input
        if (!isDialogueActive)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // Trigger dialogue start (if needed)
                    Debug.Log("Liwayway clicked.");
                }
            }
        }
    }

    public void Update()
    {
        // Mobile touch detection
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Liwayway touched.");
                }
            }
        }
    }
}

