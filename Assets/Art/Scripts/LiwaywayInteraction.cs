using UnityEngine;

public class LiwaywayInteraction : MonoBehaviour
{
    public bool hasTalked = false;

    public void TalkToLiwayway()
    {
        // Trigger conversation logic here.
        Debug.Log("Talking to Liwayway...");
        hasTalked = true; // Mark conversation as completed.
    }
}
