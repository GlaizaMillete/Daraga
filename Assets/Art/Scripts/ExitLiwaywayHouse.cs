using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLiwaywayHouse : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Set a flag to indicate the player exited from LiwaywayHouse
            PlayerPrefs.SetInt("ExitingLiwaywayHouse", 1);

            // Save the player position in VillageScene (optional, if more locations exist)
            PlayerPrefs.SetFloat("RespawnX", 21.28f); // Set this to FrontDoorSpawnPoint's X position
            PlayerPrefs.SetFloat("RespawnY", -2.45f); // Set this to FrontDoorSpawnPoint's Y position
            
            // Load the VillageScene
            SceneManager.LoadScene("VillageScene");
        }
    }
}
