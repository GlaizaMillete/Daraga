using UnityEngine;
using UnityEngine.UI;

public class TableInteraction : MonoBehaviour
{
    public GameObject arrowTable; // Assign the arrowTable UI button here
    public GameObject receiveBox; // Assign the receiveBox UI element here
    public Text receiveBoxText; // Text component inside the receiveBox to display messages

    private bool isPlayerNearTable = false;

    void Start()
    {
        // Initially hide the arrowTable and receiveBox
        arrowTable.SetActive(false);
        receiveBox.SetActive(false);
    }

    void Update()
    {
        // Check if the player is near the table and clicks the arrowTable
        if (isPlayerNearTable && Input.GetMouseButtonDown(0) && arrowTable.activeSelf)
        {
            DisplayNotification();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger area
        if (other.CompareTag("Player"))
        {
            isPlayerNearTable = true;
            arrowTable.SetActive(true); // Show the arrowTable button
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player exits the trigger area
        if (other.CompareTag("Player"))
        {
            isPlayerNearTable = false;
            arrowTable.SetActive(false); // Hide the arrowTable button
            receiveBox.SetActive(false); // Hide the receiveBox if it’s still active
        }
    }

    public void DisplayNotification()
    {
        // Show the receiveBox and display the notification text
        receiveBox.SetActive(true);
        receiveBoxText.text = "You receive clothes!";
        arrowTable.SetActive(false); // Hide the arrowTable after clicking
    }
}
