using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForestScene : MonoBehaviour
{
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        if (DialogueManager.Instance == null)
        {
            Debug.LogError("DialogueManager instance is not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the collider has the player tag (adjust if needed)
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger area!");
            TriggerDialogue();
        }
    }

    private void TriggerDialogue()
    {
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.StartDialogue(dialogue);
        }
        else
        {
            Debug.LogError("DialogueManager instance is not found.");
        }
    }
}