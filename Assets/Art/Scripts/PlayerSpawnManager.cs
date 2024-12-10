using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public GameObject player;  // Reference to the player GameObject

    void Start()
    {
        // Ensure the player exists
        if (player != null)
        {
            // Check if there is a saved position
            if (PlayerPrefs.HasKey("RespawnX") && PlayerPrefs.HasKey("RespawnY"))
            {
                // Retrieve the saved position
                float respawnX = PlayerPrefs.GetFloat("RespawnX");
                float respawnY = PlayerPrefs.GetFloat("RespawnY");

                // Set the player's position
                player.transform.position = new Vector2(respawnX, respawnY);
            }
        }
        else
        {
            Debug.LogError("Player GameObject is not assigned in PlayerSpawnManager.");
        }
    }
}
