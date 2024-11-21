using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;

    public void ShowDialogue(string dialogue)
    {
        // Set the dialogue text and show the dialogue panel
        dialogueText.text = dialogue;
        dialoguePanel.SetActive(true);
    }

    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
