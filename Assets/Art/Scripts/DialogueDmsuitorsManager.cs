using UnityEngine;
using UnityEngine.InputSystem; // Input System namespace
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public GameObject dialoguePanel; // Panel for dialogue UI
    public TextMeshProUGUI dialogueText; // Text component for displaying dialogue
    public GameObject arrowButton; // Button to continue dialogue

    // NPC images
    public GameObject guard1Image, guard2Image, dmImage, makusogImage, fangirlImage;
    public GameObject s1Image, s2Image, s3Image, s4Image, s5Image, s6Image, s7Image;
    public GameObject neroImage;

    // NPC GameObjects for raycasting
    public GameObject guard1, guard2, dm, makusog, fangirl;
    public GameObject s1, s2, s3, s4, s5, s6, s7;
    public GameObject nero;

    private Camera mainCamera; // Reference to main camera
    private GameObject currentNpcImage; // Currently active NPC image

    void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
            Debug.LogError("MainCamera not found. Ensure a camera in the scene is tagged 'MainCamera'.");

        dialoguePanel.SetActive(false);
        arrowButton.SetActive(false);
    }

    void Update()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            if (mainCamera == null)
            {
                Debug.LogError("MainCamera is missing or not assigned!");
                return;
            }

            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector2 worldPoint = mainCamera.ScreenToWorldPoint(touchPosition);

            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                GameObject npcTouched = hit.collider.gameObject;
                Debug.Log("Touched GameObject: " + npcTouched.name);

                if (npcTouched == guard1) { StartDialogue("Hey!, don't come here.", guard1Image); }
                else if (npcTouched == guard2) { StartDialogue("Are you also a suitor?", guard2Image); }
                else if (npcTouched == dm) { StartDialogue("The forest is beautiful, isn't it? I love spending time here.", dmImage); }
                else if (npcTouched == makusog) { StartDialogue("I'm so strong, I could lift a mountain... maybe.", makusogImage); }
                else if (npcTouched == fangirl) { StartDialogue("Do you need anything from me?", fangirlImage); }
                else if (npcTouched == s1) { StartDialogue("I know I have what it takes to win her heart.", s1Image); }
                else if (npcTouched == s2) { StartDialogue("I'll treat her like royalty.", s2Image); }
                else if (npcTouched == s3) { StartDialogue("I'll make her laugh, even on the darkest days.", s3Image); }
                else if (npcTouched == s4) { StartDialogue("I'll show her the beauty in every moment.", s4Image); }
                else if (npcTouched == s5) { StartDialogue("She can always count on me.", s5Image); }
                else if (npcTouched == s6) { StartDialogue("I'll protect her from any harm, no matter the cost.", s6Image); }
                else if (npcTouched == s7) { StartDialogue("I'll be her constant companion, through thick and thin.", s7Image); }
                else if (npcTouched == nero) { StartDialogue("Life's too short to be serious all the time.", neroImage); }
            }
            else
            {
                Debug.LogWarning("No collider was hit by the raycast.");
            }
        }
    }

    void StartDialogue(string dialogue, GameObject npcImage)
    {
        DeactivateAllNpcImages();
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogue;

        currentNpcImage = npcImage;
        currentNpcImage?.SetActive(true);

        arrowButton.SetActive(true);
        arrowButton.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
        arrowButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(EndDialogue);
    }

    void DeactivateAllNpcImages()
    {
        guard1Image?.SetActive(false);
        guard2Image?.SetActive(false);
        dmImage?.SetActive(false);
        makusogImage?.SetActive(false);
        fangirlImage?.SetActive(false);
        s1Image?.SetActive(false);
        s2Image?.SetActive(false);
        s3Image?.SetActive(false);
        s4Image?.SetActive(false);
        s5Image?.SetActive(false);
        s6Image?.SetActive(false);
        s7Image?.SetActive(false);
        neroImage?.SetActive(false);
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        currentNpcImage?.SetActive(false);
        arrowButton.SetActive(false);
    }
}
