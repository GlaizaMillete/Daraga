using UnityEngine;
using UnityEngine.UI;

public class ArrowTableScript : MonoBehaviour
{
    public GameObject brokenJarAssemblyUI;  // Reference to the UI for assembling the jar
    public GameObject receiveBox;           // Reference to the success notification box
    public Button arrowButton;              // Button to proceed with the assembly

    private bool hasAssembledJar = false;

    void Start()
    {
        if (arrowButton == null)
        {
            Debug.LogError("Arrow Button is not assigned in the inspector!");
            return;
        }

        arrowButton.onClick.AddListener(OnArrowButtonClick);

        if (brokenJarAssemblyUI == null)
        {
            Debug.LogError("Broken Jar Assembly UI is not assigned in the inspector!");
        }

        if (receiveBox == null)
        {
            Debug.LogError("Receive Box is not assigned in the inspector!");
        }
    }

    void OnArrowButtonClick()
    {
        if (brokenJarAssemblyUI != null)
        {
            // Open the assembly UI when the arrow button is clicked
            brokenJarAssemblyUI.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Broken Jar Assembly UI is missing.");
        }

        if (hasAssembledJar)
        {
            ShowReceiveBox();
        }
    }

    public void JarAssembled()
    {
        // Called when the player successfully assembles the jar
        hasAssembledJar = true;
        ShowReceiveBox();
    }

    void ShowReceiveBox()
    {
        if (receiveBox != null)
        {
            // Display the receive box to notify the player they successfully assembled the jar
            receiveBox.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Receive Box is missing.");
        }
    }

    // The new method you're trying to call from JarAssemblyScript
    public void CompleteJarAssembly()
    {
        // Code to handle completing the jar assembly
        Debug.Log("Jar assembly completed!");
        hasAssembledJar = true; // You could update the game state to indicate the jar is assembled
        ShowReceiveBox();       // Show success box when complete
    }
}
