using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LiwaywayHouseManager : MonoBehaviour
{
    public GameObject liwayway; // Liwayway GameObject
    public Button arrowTableButton; // Arrow Table Button
    public GameObject receiveBoxNotification; // Notification popup after jar assembly

    private bool talkedToLiwayway = false;

    void Start()
    {
        // Initially disable the arrow table button and receive box notification
        arrowTableButton.interactable = false;
        receiveBoxNotification.SetActive(false);

        // Check if the jar assembly is already complete
        if (PlayerPrefs.GetInt("JarAssemblyComplete", 0) == 1)
        {
            ShowCompletionNotification();
        }
    }

    // Called when talking to Liwayway
    public void TalkToLiwayway()
    {
        Debug.Log("TalkToLiwayway called!");
        talkedToLiwayway = true;
        arrowTableButton.interactable = true;

        // Force Unity to update the button state
        arrowTableButton.GetComponent<Button>().interactable = true;
    }

    // Called when clicking the arrow table button
    public void OpenJarAssembleScene()
    {
        if (talkedToLiwayway)
        {
            Debug.Log("Opening JarAssemble scene.");
            SceneManager.LoadScene("JarAssemble");
        }
        else
        {
            Debug.LogWarning("You must talk to Liwayway first!");
        }
    }

    // Display the completion notification
    private void ShowCompletionNotification()
    {
        Debug.Log("Displaying completion notification.");
        receiveBoxNotification.SetActive(true);
    }
}
