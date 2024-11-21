using UnityEngine;
using UnityEngine.UI;

public class JarAssembleDialogue : MonoBehaviour
{
    public Text dialogueArea;
    public GameObject characterIconLeft;
    public GameObject characterIconRight;
    public Button nextButton;

    private string[] dialogueLines = {
        "Thank you for your help, Rico. As a promise I will give you some important information.",
        "Pagtuga is a clever man. He's been planning something that might disrupt the village's peace. I've seen him wandering in the jungle, maybe looking for something. Keep your eye on him."
    };
    private int currentLine = 0;

    private void Start()
    {
        nextButton.onClick.AddListener(NextLine);
        DisplayDialogue();
    }

    private void DisplayDialogue()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueArea.text = dialogueLines[currentLine];
            // Optionally switch character icons (Rico, Liwayway)
            // characterIconLeft.SetActive(true);
            // characterIconRight.SetActive(false);
        }
        else
        {
            // End of dialogue - can trigger other actions or disable next button
            nextButton.gameObject.SetActive(false);
        }
    }

    private void NextLine()
    {
        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            DisplayDialogue();
        }
        else
        {
            // End of dialogue, disable button or trigger other actions
            nextButton.gameObject.SetActive(false);
        }
    }
}
