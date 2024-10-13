using UnityEngine;

public class ArrowLiwaywayTrigger : MonoBehaviour
{
    public DialogueTrigger liwaywayDialogueTrigger;  // Reference to the DialogueTrigger for Liwayway's dialogue
    public GameObject rico;  // Reference to Rico's character

    private void Start()
    {
        // Make sure the DialogueTrigger is assigned
        if (liwaywayDialogueTrigger == null)
        {
            Debug.LogError("DialogueTrigger for Liwayway is not assigned.");
        }

        if (rico == null)
        {
            Debug.LogError("Rico's GameObject is not assigned.");
        }
    }

    // Detect collision with Rico's character
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == rico)
        {
            // When Rico touches the arrow, trigger Liwayway's dialogue
            Debug.Log("Rico touched the arrow to Liwayway's house!");
            liwaywayDialogueTrigger.TriggerDialogue();
        }
    }
}
