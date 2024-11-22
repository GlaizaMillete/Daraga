using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public GameObject dialoguePanel; // DialoguePanel GameObject
    public TextMeshProUGUI dialogueText; // TextMeshPro text component for the dialogue
    public GameObject arrowButton; // Arrow button to continue to next dialogue

    // NPC Image GameObjects
    public GameObject guard1Image, guard2Image, dmImage, makusogImage, fangirlImage;
    public GameObject s1Image, s2Image, s3Image, s4Image, s5Image, s6Image, s7Image;
    public GameObject neroImage;

    // NPC GameObjects for detecting touch
    public GameObject guard1, guard2, dm, makusog, fangirl;
    public GameObject s1, s2, s3, s4, s5, s6, s7;
    public GameObject nero;

    private string currentDialogue; // Current NPC dialogue text
    private GameObject currentNpcImage; // Current NPC image to display

    void Start()
    {
        // Hide the dialogue panel at the start
        dialoguePanel.SetActive(false);
        arrowButton.SetActive(false);
    }

    void Update()
    {
        // Detect touch or click on NPCs
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

            if (hit.collider != null)
            {
                // Check which NPC was touched and trigger dialogue accordingly
                GameObject npcTouched = hit.collider.gameObject;

                if (npcTouched == guard1) { StartDialogue("Hey!, don't come here.", guard1Image); }
                else if (npcTouched == guard2) { StartDialogue("Are you also a suitor?.", guard2Image); }
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
        }
    }

    void StartDialogue(string dialogue, GameObject npcImage)
    {
        // Deactivate all NPC images before displaying the selected one
        DeactivateAllNpcImages();

        // Activate the dialogue panel and display the NPC's image and text
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogue;
        currentNpcImage = npcImage;
        currentNpcImage.SetActive(true); // Show the correct NPC image

        // Show the arrow button to move to the next dialogue or hide the panel
        arrowButton.SetActive(true);
        arrowButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(EndDialogue);
    }

    void DeactivateAllNpcImages()
    {
        // Deactivate all NPC images
        guard1Image.SetActive(false);
        guard2Image.SetActive(false);
        dmImage.SetActive(false);
        makusogImage.SetActive(false);
        fangirlImage.SetActive(false);
        s1Image.SetActive(false);
        s2Image.SetActive(false);
        s3Image.SetActive(false);
        s4Image.SetActive(false);
        s5Image.SetActive(false);
        s6Image.SetActive(false);
        s7Image.SetActive(false);
        neroImage.SetActive(false);
        
    }

    void EndDialogue()
    {
        // Hide the dialogue panel and NPC image after the dialogue is done
        dialoguePanel.SetActive(false);
        if (currentNpcImage != null)
        {
            currentNpcImage.SetActive(false);
        }
        arrowButton.SetActive(false);
    }
}
