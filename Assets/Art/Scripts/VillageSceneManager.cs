using UnityEngine;

public class VillageSceneManager : MonoBehaviour
{
    private void Start()
    {
        // Check if PlayerPrefs has the position keys
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY") && PlayerPrefs.HasKey("PlayerPosZ"))
        {
            Vector3 playerPosition = new Vector3(
                PlayerPrefs.GetFloat("PlayerPosX"),
                PlayerPrefs.GetFloat("PlayerPosY"),
                PlayerPrefs.GetFloat("PlayerPosZ")
            );

            // Set the player's position
            GameObject player = GameObject.Find("Player");
            if (player != null)
            {
                player.transform.position = playerPosition;
            }
            else
            {
                Debug.LogError("Player GameObject not found!");
            }
        }
    }
}
