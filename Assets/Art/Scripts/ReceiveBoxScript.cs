using UnityEngine;

public class ReceiveBoxScript : MonoBehaviour
{
    private void Start()
    {
        // Initially hide the receive box
        gameObject.SetActive(false);
    }

    public void ShowReceiveBox()
    {
        // Show the success notification box
        gameObject.SetActive(true);

        // Optionally add a delay before hiding or performing other actions
        Invoke("HideReceiveBox", 3f);  // Hide after 3 seconds
    }

    private void HideReceiveBox()
    {
        gameObject.SetActive(false);
    }
}
