using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject popup;
    public GameplayMenuManager gameplayMenuManager;

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false); // Ensure the popup is hidden at the start
    }

    public IEnumerator ShowPopup()
    {
        popup.SetActive(true); // Show the popup
        yield return null; // You can add a delay here if needed
    }

    public IEnumerator HidePopup()
    {
        popup.SetActive(false); // Hide the popup
        yield return null;
    }

    /* private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Unlock the "Alon" achievement
            gameplayMenuManager.UnlockAchievement("tilapia");
        }
    }*/
}


