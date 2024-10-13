using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject popupMessage; // Reference to the popup message GameObject

    private void Start()
    {
        // Ensure the popup is hidden at the start
        popupMessage.SetActive(false);
    }

    public IEnumerator ShowPopupAfterDelay()
    {
        // Activate the popup
        popupMessage.SetActive(true);

        // Wait for a few seconds
        yield return new WaitForSeconds(3f); // Adjust delay as necessary

        // Deactivate the popup after the delay
        popupMessage.SetActive(false);
    }
}
