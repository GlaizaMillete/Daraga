using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject arrowBagwisButton;
    public GameObject arrowMarinaButton;
    public GameObject arrowMarisaButton;
    public GameObject arrowDalisayButton;
    public GameObject arrowNeroButton;

    public GameObject dialoguePanel; // Panel that shows the dialogue
    public Text dialogueText; // Text component to show dialogue

    private bool isPlayerNearBagwis = false;
    private bool isPlayerNearMarina = false;
    private bool isPlayerNearMarisa = false;
    private bool isPlayerNearDalisay = false;
    private bool isPlayerNearNero = false;

    // Update checks for player inputs when near NPCs
    void Update()
    {
        // This part can be optional for other interactions
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Use tags or object names to differentiate NPCs
            if (gameObject.name == "Bagwis")
            {
                isPlayerNearBagwis = true;
                arrowBagwisButton.SetActive(true); // Show the Bagwis interaction button
            }
            else if (gameObject.name == "Marina")
            {
                isPlayerNearMarina = true;
                arrowMarinaButton.SetActive(true); // Show the Marina interaction button
            }
            else if (gameObject.name == "Marisa")
            {
                isPlayerNearMarisa = true;
                arrowMarisaButton.SetActive(true); // Show the Marisa interaction button
            }
            else if (gameObject.name == "Dalisay")
            {
                isPlayerNearDalisay = true;
                arrowDalisayButton.SetActive(true); // Show the Dalisay interaction button
            }
            else if (gameObject.name == "Nero")
            {
                isPlayerNearNero = true;
                arrowNeroButton.SetActive(true); // Show the Nero interaction button
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide buttons when player leaves the proximity
            if (gameObject.name == "Bagwis")
            {
                isPlayerNearBagwis = false;
                arrowBagwisButton.SetActive(false); // Hide the Bagwis interaction button
            }
            else if (gameObject.name == "Marina")
            {
                isPlayerNearMarina = false;
                arrowMarinaButton.SetActive(false); // Hide the Marina interaction button
            }
            else if (gameObject.name == "Marisa")
            {
                isPlayerNearMarisa = false;
                arrowMarisaButton.SetActive(false); // Hide the Marisa interaction button
            }
            else if (gameObject.name == "Dalisay")
            {
                isPlayerNearDalisay = false;
                arrowDalisayButton.SetActive(false); // Hide the Dalisay interaction button
            }
            else if (gameObject.name == "Nero")
            {
                isPlayerNearNero = false;
                arrowNeroButton.SetActive(false); // Hide the Nero interaction button
            }
        }
    }

    public void ShowDialogue(string dialogue)
    {
        // Set the dialogue and show the dialogue panel
        dialogueText.text = dialogue;
        dialoguePanel.SetActive(true); // Show the dialogue panel
    }

    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false); // Close the dialogue panel
    }
}
