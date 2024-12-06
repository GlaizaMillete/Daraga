using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditButtonHandler : MonoBehaviour
{
    // This function is called when the button is clicked
    public void LoadCreditsScene()
    {
        Debug.Log("Loading Credits Scene");
        SceneManager.LoadScene("CREDITS"); // Replace "CreditsScene" with your actual scene name
    }
}
