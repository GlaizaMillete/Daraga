using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LiwaywayHouseScript : MonoBehaviour
{
    public Button arrowTableButton;     // The button (arrowtable image)
    public GameObject receiveBox;       // The receive box for success
    public GameObject liwayway;         // Liwayway character object
    public GameObject player;           // Player object
    public GameObject popupNotification;

    private bool hasTalkedToLiwayway = false;
    private bool isPlayerNearLiwayway = false;

    private void Start()
    {
        // Initially disable the button
        arrowTableButton.interactable = false; 
        receiveBox.SetActive(false);
        popupNotification.SetActive(false);

        // Add listener to arrow table button (mobile touch will click)
        arrowTableButton.onClick.AddListener(OnArrowTableClicked);
    }

    private void Update()
    {
        // Check if the player is near Liwayway and presses 'E' (for desktop)
        if (isPlayerNearLiwayway && Input.GetKeyDown(KeyCode.E))
        {
            hasTalkedToLiwayway = true;
            arrowTableButton.interactable = true;
            Debug.Log("Player has talked to Liwayway.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isPlayerNearLiwayway = true;
            Debug.Log("Player is near Liwayway. Tap to talk.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isPlayerNearLiwayway = false;
            Debug.Log("Player left the interaction area.");
        }
    }

    public void OnArrowTableClicked()
    {
        if (hasTalkedToLiwayway)
        {
            Debug.Log("Loading JarAssemble scene...");
            SceneManager.LoadScene("JarAssemble");
        }
        else
        {
            Debug.Log("Player has not talked to Liwayway yet.");
        }
    }

    public void OnJarAssembleSuccess()
    {
        receiveBox.SetActive(true);
        popupNotification.SetActive(true);
        Invoke("ReturnToLiwaywayHouse", 2f); // Wait for 2 seconds before returning
    }

    private void ReturnToLiwaywayHouse()
    {
        SceneManager.LoadScene("LiwaywayHouse");
    }
}
