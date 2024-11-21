using UnityEngine;

public class TalktoLiwayway : MonoBehaviour
{
    public bool hasTalkedToLiwayway = false; // Tracks if the player has talked to Liwayway

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Here you can show dialog or trigger the conversation with Liwayway
            Debug.Log("Player is talking to Liwayway.");

            // Set flag to true after talking
            hasTalkedToLiwayway = true;
        }
    }
}
